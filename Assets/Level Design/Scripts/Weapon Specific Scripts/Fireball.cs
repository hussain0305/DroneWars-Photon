using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {

    public float lifetime;
    public float hitpoints;
    private float age;
    public float fireRate;
    
    // Use this for initialization
    void Start () {
        age = 0;
        lifetime = 1;
        hitpoints = 10;
        fireRate = 0.25f;
        var rb = this.GetComponent<Rigidbody>();
        rb.AddRelativeForce(0, 0, 750);
    }
	
	// Update is called once per frame
	void Update () {
        age += Time.deltaTime;
        if (age > lifetime)
            PhotonNetwork.Destroy(this.gameObject);
    }
    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Shot with pellet");
        col.gameObject.GetComponent<PhotonView>().RPC("TakeDamage", PhotonTargets.All, hitpoints);
    }
}
