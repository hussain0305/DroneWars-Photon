using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float droneSpeed;
    public bool allowMovement;
    void Start()
    {
        droneSpeed = 1;
        allowMovement = true;
    }

    void Update()
    {
        
    }
    public bool canMove()
    {
        //if (transform.position.y >= 110)
            //allowMovement = false;
        //else
            //allowMovement = true;
        return allowMovement;
    }
    public void moveForward()
    {
        if(canMove())
            this.transform.Translate(0, 0, droneSpeed);
    }
    public void moveBackward()
    {
        if (canMove())
            this.transform.Translate(0, 0, -droneSpeed);
    }
    public void moveRight()
    {
        if (canMove())
            this.transform.Translate(droneSpeed, 0,  0 );
    }
    public void moveLeft()
    {
        if (canMove())
            this.transform.Translate(-droneSpeed, 0,  0);
    }
    
}
