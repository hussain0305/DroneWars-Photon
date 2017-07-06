using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionScript : MonoBehaviour {

    public GameObject can,Player;
    // Use this for initialization
	void Start () {
        can = GameObject.Find("Canvas");
        Player = GameObject.FindWithTag("Player");

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        can.GetComponent<GameOverManager>().gameOver();
        Player.GetComponent<AutoMotion>().alive = false;
        //SceneManager.LoadScene("OfflineSelection");
    }
}
