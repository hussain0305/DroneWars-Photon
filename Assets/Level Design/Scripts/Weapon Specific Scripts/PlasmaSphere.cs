using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaSphere : MonoBehaviour {

    private float age;
    // Use this for initialization
    void Start () {
        age = 0;
    }
	
	// Update is called once per frame
	void Update () {
        age += Time.deltaTime;
        if (age > 1)
            PhotonNetwork.Destroy(this.gameObject);
    }
}
