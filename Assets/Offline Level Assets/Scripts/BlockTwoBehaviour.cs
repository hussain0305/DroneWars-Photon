using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockTwoBehaviour : MonoBehaviour
{

    // Use this for initialization rotate y
    private GameObject Player, Monitor;
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        ApplyTextures();
    }

    // Update is called once per frame
    void Update()
    {
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
