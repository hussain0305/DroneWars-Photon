using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEffect : MonoBehaviour {

    public float lifetime;
    public float hitpoints;
    private float age;
    public float missileSpeed;
    public float fireRate;
    public float radius;
    // Use this for initialization
    void Start()
    {
        age = 0;
        lifetime = 2.0f;
        radius = 20;
        foreach (Collider col in Physics.OverlapSphere(transform.position, radius))
        {
            if (col.gameObject.GetComponent<PhotonView>() != null)
            {
                Debug.Log(col.name);
                col.GetComponent<PhotonView>().RPC("TakeDamage", PhotonTargets.All, 10.0f);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        age += Time.deltaTime;
        if (age > lifetime)
        {
            PhotonNetwork.Destroy(this.gameObject);
        }
    }
}
