using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockOneBehaviour : MonoBehaviour {

    // Use this for initialization
    private Rigidbody Wall1, Wall2;
    private GameObject Player, Monitor;
    public float wallSpeed = 5;
    void Start () {
        Monitor = transform.Find("LeftWall").gameObject;
        Player = GameObject.FindWithTag("Player");
        Wall1 = transform.Find("LeftWall").gameObject.GetComponent<Rigidbody>();
        Wall2 = transform.Find("RightWall").gameObject.GetComponent<Rigidbody>();
        ApplyTextures();
        GoUp();
    }
	
	// Update is called once per frame
	void Update () {
        if (Monitor.transform.position.y > 2)
        {
            GoDown();
        }
        if (Monitor.transform.position.y < -4)
        {
            GoUp();
        }
        if(Player.transform.position.z > transform.position.z+15)
        {
            Destroy(this.gameObject);
        }

    }
    void GoUp()
    {
        Wall1.velocity = new Vector3(0, wallSpeed, 0);
        Wall2.velocity = new Vector3(0, wallSpeed, 0);
    }
    void GoDown()
    {
        Wall1.velocity = new Vector3(0, -wallSpeed, 0);
        Wall2.velocity = new Vector3(0, -wallSpeed, 0);
    }
    void ApplyTextures()
    {
        foreach (Transform child in transform)
        {      
            child.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        }
    }
}
