using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Floor : MonoBehaviour {

    public GameObject lookAtObj;
    private bool isAtValidPos;
    private GameObject player;
    private int flag = -1;
    private Text FlashMessages;
    // Use this for initialization
    void Start () {
        FlashMessages = GameObject.Find("FlashMessages").GetComponent<Text>();
        lookAtObj = GameObject.Find("LookAtObject");
        isAtValidPos = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (!isAtValidPos)
        {
            if(player!=null)
                movePlayerToCenter();
        }
        else if(flag==1)
        {
            player.transform.FindChild("Main Camera").gameObject.GetComponent<GyroController>().enabled = true;
            flag = -1;
        }
    }
    void OnTriggerEnter(Collider col)
    {
        flag = 1;
        player = col.gameObject;
        player.transform.FindChild("Main Camera").gameObject.GetComponent<GyroController>().enabled = false;
        isAtValidPos = false;
        StartCoroutine(ShowMessage("Crash!!! Returning To Base. Weapons System and Navigation temporarily Down!!!", 5));

        //col.gameObject.transform.Translate(0, 20, -160);
        //SmoothLook(lookAtObj.transform.position, col);//lookAtObj.transform.position-col.gameObject.transform.position
    }
    void SmoothLook(Vector3 newDirection, Collider col)
    {
        player.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(transform.TransformDirection(newDirection)), Time.deltaTime*.4f);
    }
    void movePlayerToCenter()
    {
        player.transform.LookAt(lookAtObj.transform.position);
        player.transform.Translate(0, 0, 1);
        if (Vector3.Distance(player.transform.position, lookAtObj.transform.position)<1)
            isAtValidPos = true;
    }
    IEnumerator ShowMessage(string message, float delay)
    {
        FlashMessages.enabled = true;
        FlashMessages.text = message;
        yield return new WaitForSeconds(delay);
        FlashMessages.enabled = false;
    }
}
