using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricFence : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        col.gameObject.GetComponent<PhotonView>().RPC("TakeDamage", PhotonTargets.All, 20.0f);
        PhotonNetwork.Instantiate("ExplosionMissile", transform.position, transform.rotation, 0);
    }
}
