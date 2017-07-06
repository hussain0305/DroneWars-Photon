using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSight : MonoBehaviour {

    private LineRenderer line;
	void Start () {
        line = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider)
                line.SetPosition(1, new Vector3(0, 0, hit.distance));
        }
        else
            line.SetPosition(1, new Vector3(0, 0, 1000));


	}
    [PunRPC]
    public void toggle()
    {
        //var LR = GameObject.FindWithTag("FlashSocket").GetComponent<LineRenderer>();
        line.enabled = !line.enabled;
    }
}
