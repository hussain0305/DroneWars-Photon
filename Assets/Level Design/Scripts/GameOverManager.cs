using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour {

    public float restartDelay = 5.0f;
    Animator anim;
    float restartTimer;
    // Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void gameOver()
    {
        anim.SetTrigger("GameOver");
    }
}
