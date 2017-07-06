using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : MonoBehaviour {

    public float lifetime;
    public float hitpoints;
    private float age;
    public float missileSpeed;
    public float fireRate;
    private Vector3 temp;
    // Use this for initialization
    void Start()
    {
        age = 0;
        lifetime = 2.0f;
        hitpoints = 25;
        fireRate = 0.50f;
        missileSpeed = 100;
        
        var rb = this.GetComponent<Rigidbody>();
        rb.velocity = missileSpeed* transform.InverseTransformDirection(Vector3.forward);
    }

    // Update is called once per frame
    void Update()
    {
        age += Time.deltaTime;
        if (age > lifetime)
        {
            PhotonNetwork.Instantiate("ExplosionMissile", transform.position, transform.rotation, 0);
            PhotonNetwork.Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter(Collider col)
    {
        col.gameObject.GetComponent<PhotonView>().RPC("TakeDamage", PhotonTargets.All, hitpoints);
        PhotonNetwork.Instantiate("ExplosionMissile", transform.position, transform.rotation, 0);
        PhotonNetwork.Destroy(this.gameObject);
    }
}
