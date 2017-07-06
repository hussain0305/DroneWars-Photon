using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour {

    private GameObject Player;
    // Use this for initialization
	void Start () {
        Player = GameObject.FindWithTag("Player");
        ApplyTextures();
    }

    // Update is called once per frame
    void Update () {
        transform.Rotate(0, 3, 0);
        if (Player.transform.position.z > transform.position.z + 15)
        {
            Destroy(this.gameObject);
        }
    }
    void ApplyTextures()
    {
        GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    }
}
