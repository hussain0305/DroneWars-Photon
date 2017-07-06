using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupManager : MonoBehaviour {

    public PickupSpawn[] pickupspots;
    public GameObject[] pickups;
    private Text FlashMessages;
    private float time;
    private bool hasStarted;


    // Use this for initialization
	void Start () {
        FlashMessages = GameObject.Find("FlashMessages").GetComponent<Text>(); ;
        FlashMessages.enabled = false;
        pickupspots = GameObject.FindObjectsOfType<PickupSpawn>();
        time = 0;
        hasStarted = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (hasStarted)
        {
            time += Time.deltaTime;
            if (time > 60)
            {
                time = 0;
                placePickups();
            }
        }
    }
    public void startPickupRoutine() {
        hasStarted = true;
    }
    public void placePickups()
    {
        PhotonNetwork.Instantiate(pickups[Random.Range(0, pickups.Length)].name, pickupspots[0].transform.position, pickupspots[0].transform.rotation, 0);
        PhotonNetwork.Instantiate(pickups[Random.Range(0, pickups.Length)].name, pickupspots[1].transform.position, pickupspots[1].transform.rotation, 0);
        PhotonNetwork.Instantiate(pickups[Random.Range(0, pickups.Length)].name, pickupspots[2].transform.position, pickupspots[2].transform.rotation, 0);
    }
}
