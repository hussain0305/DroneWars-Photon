using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockThreeBehaviour : MonoBehaviour {

    private GameObject Player;
    // Use this for initialization
    void Start () {
        Player = GameObject.FindWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        if (Player.transform.position.z > transform.position.z + 15)
        {
            Destroy(this.gameObject);
        }
        transform.Rotate(2, 0, 0);
    }
}
