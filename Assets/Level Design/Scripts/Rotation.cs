using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {

    private GameObject Cam;
    private Vector3 camrot;

    void Start () {
        Cam = GameObject.FindWithTag("MainCamera");
	}
	
	void Update () {
        if(Cam == null)
            Cam = GameObject.FindWithTag("MainCamera");
        transform.rotation = Quaternion.Lerp(transform.rotation, Cam.transform.rotation, Time.deltaTime);
    }

    public void rotateRight()
    {
        camrot = Cam.GetComponent<GyroController>().cameraBase.eulerAngles;
        Quaternion toQ = Cam.GetComponent<GyroController>().cameraBase * Quaternion.Euler(0, +45, 0);
        StopCoroutine("rotToPosition");
        StartCoroutine("rotToPosition", (toQ));
    }
    public void rotateLeft()
    {
        camrot = Cam.GetComponent<GyroController>().cameraBase.eulerAngles;
        Quaternion toQ = Cam.GetComponent<GyroController>().cameraBase * Quaternion.Euler(0, -45, 0);
        StopCoroutine("rotToPosition");
        StartCoroutine("rotToPosition",(toQ));
    }

    IEnumerator rotToPosition(Quaternion to)
    {
        float time = Time.time;
        while (time + 1 > Time.time )
        {
            Cam.GetComponent<GyroController>().cameraBase = Quaternion.Lerp(Cam.GetComponent<GyroController>().cameraBase, to, .04f);
            yield return null;
        }
        Cam.GetComponent<GyroController>().cameraBase = to;
        yield return null;
    }
    public void LookUpwards()
    {
        camrot = Cam.GetComponent<GyroController>().cameraBase.eulerAngles;
        Quaternion toQ = Cam.GetComponent<GyroController>().cameraBase * Quaternion.Euler(-30, 0, 0);
        //Quaternion toQ = Cam.GetComponent<GyroController>().cameraBase * Quaternion.Euler(new Vector3(Vector3.up) * 30);
        StopCoroutine("rotToPosition");
        StartCoroutine("rotToPosition", (toQ));
    }
    public void LookDownwards()
    {
        camrot = Cam.GetComponent<GyroController>().cameraBase.eulerAngles;
        Quaternion toQ = Cam.GetComponent<GyroController>().cameraBase * Quaternion.Euler(+30, 0, 0);
        StopCoroutine("rotToPosition");
        StartCoroutine("rotToPosition", (toQ));
    }
}
