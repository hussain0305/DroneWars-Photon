using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipes : MonoBehaviour {

    Vector2 firstPressPos;
    Vector2 secondPressPos;
    float x, y;
    private Camera cam;
    private GameObject Player;
    private float cushion;

    private GameObject CamParent;
    // Use this for initialization
    void Start () {
        cam = GetComponent<Camera>();
        Player=cam.transform.root.gameObject;
        cushion = 40.0f;

        CamParent = GameObject.FindWithTag("CamParent");
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.touches.Length > 0)
        {
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began)
            {
                //save began touch 2d point
                firstPressPos = new Vector2(t.position.x, t.position.y);
            }
            if (t.phase == TouchPhase.Ended)
            {
                //save ended touch 2d point
                secondPressPos = new Vector2(t.position.x, t.position.y);

                //create vector from the two points
                x = secondPressPos.x - firstPressPos.x;
                y = secondPressPos.y - firstPressPos.y;
                if (getMag(y) > getMag(x) ) // Vertical Swipe
                {
                    if (y > cushion) //Upward Swipe
                    {
                        CamParent.GetComponent<Rotation>().LookUpwards();                 
                    }
                    else if(y < -cushion) //DOwnward Swipe
                    {
                        CamParent.GetComponent<Rotation>().LookDownwards();
                    }
                }
                else //Horizontal Swipe
                {
                    if (x > cushion)//Right Swipe
                    {
                        Player.GetComponent<PlayerShooting>().prefabDetails();
                    }
                    else if (x < -cushion)//Left Swipe
                    {
                        Player.GetComponent<PlayerShooting>().laserDetails();
                    }
                }
            }
        }
        
    }
    private float getMag(float x)
    {
        if (x >= 0)
            return x;
        else
            return (-1 * x);
    }
}
