using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour {

	public float fireRate = 0.5f;
    private int weaponNumber, laserNumber;
	float cooldown = 0;
	public float damage = 15f;
    public float additionalDamage;
    public float flametime;
    public string currentPrefab, currentLaser;
    public string[] weapons;
    public string[] lasers;
    public bool[] unlockedWeapons, unlockedLasers;
    private GameObject Flame,launcher,temp;
    private PhotonView pview;
    private Text FlashMessages;
    private bool HBDStatus;
    private float HBDTimer;

    void Start()
    {
        HBDTimer = 0;
        HBDStatus = false;
        FlashMessages = GameObject.Find("FlashMessages").GetComponent<Text>();
        weapons = new string[] { "Pellets", "Missile", "Barrel", "Flamethrower", "Fireball"};
        lasers = new string[] { "Default", "PlasmaSphere", "Shrapnels", "Disruptor" };
        unlockedWeapons = new bool[] { true, false, false, false, false };
        unlockedLasers = new bool[] { true, false, false, false };
        weaponNumber = 0;
        laserNumber = 0;
        additionalDamage = 0;
        currentPrefab = "Pellets";
        currentLaser = "Default";
        flametime = 0;
        Flame = this.gameObject.transform.Find("DroneRed").Find("Tube003").Find("PrefabLaunch").Find("Flamethrower").gameObject;
        pview = this.gameObject.GetComponent<PhotonView>();
        launcher = GameObject.FindWithTag("PrefabLauncher");
    }
    void Update () {
		cooldown -= Time.deltaTime;
        if (HBDStatus)
        {
            HBDTimer += Time.deltaTime;
        }
        if (HBDTimer > 5)
        {
            HBDTimer = 0;
            this.GetComponent<PhotonView>().RPC("hitByDisruptor", PhotonTargets.All);
        }
            
	}

	public void Fire() {
		if(cooldown > 0) {
			return;
		}

		Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
		Transform hitTransform;
		Vector3   hitPoint;

		hitTransform = FindClosestHitObject(ray, out hitPoint);

		if(hitTransform != null) {

            // We could do a special effect at the hit location
            // DoRicochetEffectAt( hitPoint );

            Health h = hitTransform.GetComponent<Health>();

			while(h == null && hitTransform.parent) {
				hitTransform = hitTransform.parent;
				h = hitTransform.GetComponent<Health>();
			}
            if (hitTransform.gameObject.name == "TheDrone(Clone)")
            {
                if(currentLaser == "PlasmaSphere")
                    PhotonNetwork.Instantiate(currentLaser, hitTransform.FindChild("DroneRed").position, hitTransform.FindChild("DroneRed").rotation, 0);
                if (currentLaser == "Shrapnels")
                    PhotonNetwork.Instantiate(currentLaser, hitTransform.position, hitTransform.rotation, 0);
                if (currentLaser == "Disruptor")
                    hitTransform.GetComponent<PhotonView>().RPC("hitByDisruptor", PhotonTargets.All);
            }

			// Once we reach here, hitTransform may not be the hitTransform we started with!

			if(h != null) {
				PhotonView pv = h.GetComponent<PhotonView>();
				if(pv==null) {
					Debug.LogError("Freak out!");
				}
				else {
					pv.RPC ("TakeDamage", PhotonTargets.All, damage+additionalDamage);
                }
            }
		}

		cooldown = fireRate;
	}

	Transform FindClosestHitObject(Ray ray, out Vector3 hitPoint) {

		RaycastHit[] hits = Physics.RaycastAll(ray);

		Transform closestHit = null;
		float distance = 0;
		hitPoint = Vector3.zero;

		foreach(RaycastHit hit in hits) {
			if(hit.transform != this.transform && ( closestHit==null || hit.distance < distance ) ) {
                // We have hit something that is:
                // a) not us
                // b) the first thing we hit (that is not us)
                // c) or, if not b, is at least closer than the previous closest thing
                closestHit = hit.transform;
				distance = hit.distance;
				hitPoint = hit.point;
			}
		}

		// closestHit is now either still null (i.e. we hit nothing) OR it contains the closest thing that is a valid thing to hit

		return closestHit;

	}

    public void LaunchProjectile()
    {        
        if (cooldown <= 0 && currentPrefab != "Flamethrower")
        {
            PhotonNetwork.Instantiate(currentPrefab, launcher.transform.position, launcher.transform.rotation, 0);
            cooldown = fireRate;
        }
        else if (cooldown <= 0 && currentPrefab == "Flamethrower")
        {
            Flame.GetComponent<Flamethrower>().SwitchFlame();
            cooldown = fireRate;
        }
    }

    public void prefabDetails()
    {
        int c = ++weaponNumber % weapons.Length;
        if (unlockedWeapons[c]) { 
               
        }
        else
        {
            while(!unlockedWeapons[c])
                c= ++weaponNumber % weapons.Length;
        }
        Flame.GetComponent<Flamethrower>().TurnOffFlame();
        currentPrefab = weapons[c];
        if (currentPrefab == "Barrel")
            fireRate = 1;
        if (currentPrefab == "Pellets")
            fireRate = 0.25f;
        if (currentPrefab == "Missile")
            fireRate = 0.5f;
        if (currentPrefab == "Flamethrower")
            fireRate = 1.0f;
        if (currentPrefab == "Fireball")
            fireRate = 1.0f;
        StartCoroutine(ShowMessage("Active Weapon: "+currentPrefab, 1));
    }
    public void laserDetails()
    {
        int c = ++laserNumber % lasers.Length;
        if (unlockedLasers[c])
        {

        }
        else
        {
            while (!unlockedLasers[c])
                c = ++laserNumber % lasers.Length;
        }
        currentLaser = lasers[c];
        if (currentLaser == "Default")
            additionalDamage = 0;
        if (currentLaser == "PlasmaSphere")
            additionalDamage = 10;
        if (currentLaser == "Shrapnels")
            additionalDamage = 15;
        if (currentLaser == "Disruptor")
            additionalDamage = -15;
        StartCoroutine(ShowMessage("Active Laser: " + currentLaser, 1));
    }
    IEnumerator ShowMessage(string message, float delay)
    {
        FlashMessages.enabled = true;
        FlashMessages.text = message;
        yield return new WaitForSeconds(delay);
        FlashMessages.enabled = false;
    }
    [PunRPC]
    public void hitByDisruptor()
    {
        gameObject.GetComponent<Movement>().allowMovement = !(gameObject.GetComponent<Movement>().allowMovement);
        HBDStatus = !HBDStatus;
        Debug.Log("Disruptor");
    }
}
