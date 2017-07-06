using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoMotion : MonoBehaviour {

    // Use this for initialization
    private float duration;
    private float vel,dist;
    private double scr;
    private CharacterController cc;
    public Text Score;
    public bool alive;
    public GameObject Cube;
	void Start () {
        Cube = GameObject.Find("Cube");
        alive = true;
        dist = 0;
        cc = GetComponent<CharacterController>();
        duration = 0;
        vel = 10;
    }
	
	// Update is called once per frame
	void Update () {
        if (alive)
        {
            dist += Time.deltaTime * vel;
            cc.Move(Vector3.forward * vel * Time.deltaTime);
        }
        else
        {
            Cube.GetComponent<Rigidbody>().useGravity = true;
            if((int)scr> GameControl.control.EndlessRunScore)
                GameControl.control.EndlessRunScore = (int)scr;
            GameControl.control.WriteStats();
        }
        duration += Time.deltaTime;
        if (duration > 3 && vel < 80)
        {
            duration = 0;
            vel+=2;
        }
        scr = System.Math.Ceiling(dist);
        Score.text = "" + scr;
    }
    public void goRight()
    {
        if(transform.position.x<6)
            cc.Move(Vector3.right * 15 * Time.deltaTime);
    }
    public void goLeft()
    {
        if (transform.position.x > -6)
            cc.Move(Vector3.left * 15 * Time.deltaTime);
    }
    public void goUp()
    {
        if (transform.position.y < 15)
            cc.Move(Vector3.up * 15 * Time.deltaTime);
    }
    public void goDown()
    {
        if (transform.position.y > 1.5)
            cc.Move(Vector3.down * 15 * Time.deltaTime);
    }
}
