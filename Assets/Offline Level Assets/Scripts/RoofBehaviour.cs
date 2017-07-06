using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoofBehaviour : MonoBehaviour {

    private GameObject Player;
    private Texture texture;
    // Use this for initialization
    void Start () {
        Player = GameObject.FindWithTag("Player");
        ApplyTextures();
    }
	
	// Update is called once per frame
	void Update () {
        if (Player.transform.position.z > transform.position.z + 15)
        {
            Destroy(this.gameObject);
        }
    }
    void ApplyTextures()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        }
    }
}
