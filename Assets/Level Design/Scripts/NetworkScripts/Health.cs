using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour {

	public float hitPoints = 100f;
    public float radius;
	float currentHitPoints, timeSinceDeath;
    public RectTransform healthBar;
    private bool alive;
    private Vector3 p;
    private Quaternion r;
    Animator anim;
    private bool matchStarted;

    void Start () {
        radius = 20;
        anim = GameObject.FindWithTag("MultiCanvas").GetComponent<Animator>();
		currentHitPoints = hitPoints;
        timeSinceDeath = 0;
        alive = true;
        matchStarted = false;
    }

    void Update()
    {
        if(matchStarted == false && PhotonNetwork.playerList.Length == 2)
        {
            matchStarted = true;
        }
        if (matchStarted == true && PhotonNetwork.playerList.Length == 1)
        {
            multiWin();
        }
        if (!alive)
        {
            timeSinceDeath += Time.deltaTime;
        }
        if (timeSinceDeath > 0.5f)
            this.GetComponent<PhotonView>().RPC("removeBody", PhotonTargets.All);
    }

	[PunRPC]
	public void TakeDamage(float amt) {
		currentHitPoints -= amt;
        healthBar.sizeDelta = new Vector2(currentHitPoints, healthBar.sizeDelta.y);
        if (currentHitPoints <= 0 && GetComponent<PhotonView>().isMine) {
            Die();
            //this.GetComponent<PhotonView>().RPC("Die", PhotonTargets.All);
        }
	}
    
    void Die() {
		if( GetComponent<PhotonView>().instantiationId==0 ) {
            PhotonNetwork.Instantiate("ExplosionMissile", transform.position, transform.rotation, 0);
            Destroy(gameObject);
		}
		else {
            if (gameObject.tag=="Barrel")
            {
                p = transform.position;
                r = transform.rotation;
                PhotonNetwork.Destroy(gameObject);
                PhotonNetwork.Instantiate("BarrelExplosion", p, r, 0);
                PhotonNetwork.Instantiate("ExplosionEffect", p, r, 0);
                alive = false;                                
            }
            else
            {
                if (GetComponent<PhotonView>().isMine)
                {
                    PhotonNetwork.Instantiate("ExplosionBig", transform.FindChild("DroneRed").position, transform.FindChild("DroneRed").rotation, 0);
                    PhotonNetwork.Destroy(this.gameObject.transform.Find("DroneRed").gameObject);
                    Debug.Log("Set to False");
                    alive = false;
                }
            }
		}
	}
    [PunRPC]
    void removeBody()
    {
        if (GetComponent<PhotonView>().isMine) { 
            PhotonNetwork.Destroy(gameObject);
            multiGameOver();
        }
    }
    public void multiGameOver()
    {
        GameControl.control.Losses++;
        GameControl.control.WriteStats();
        anim.SetTrigger("MultiGameOver");
        PhotonNetwork.Disconnect();
    }
    public void multiWin()
    {
        GameControl.control.Wins++;
        GameControl.control.WriteStats();
        anim.SetTrigger("MultiWin");
    }
}
