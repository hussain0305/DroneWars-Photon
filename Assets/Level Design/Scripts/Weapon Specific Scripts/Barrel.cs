using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour {

    public float lifetime;
    public float age;
    public float barrelSpeed;
    public float hitpoints;
    public float fireRate;

    // Use this for initialization
    void Start()
    {
        age = 0;
        lifetime = 25.0f;
        barrelSpeed = 5.0f;
        hitpoints = 50;
        fireRate = 1.0f;
        var rb = this.GetComponent<Rigidbody>();
        rb.velocity = barrelSpeed * transform.InverseTransformDirection(Vector3.forward);
    }

    // Update is called once per frame
    void Update()
    {
        age += Time.deltaTime;
        if (age > lifetime)
            PhotonNetwork.Destroy(this.gameObject);
    }
}
