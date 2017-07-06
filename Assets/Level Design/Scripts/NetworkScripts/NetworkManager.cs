using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour
{

    public GameObject standbyCamera;
    SpawnSpot[] spawnSpots;
    GameObject myPlayerGO;

    void Start()
    {
        spawnSpots = GameObject.FindObjectsOfType<SpawnSpot>();
        PhotonNetwork.JoinRandomRoom();
        //Connect();
    }
    /*
    void Connect()
    {
        PhotonNetwork.ConnectUsingSettings("DroneWars v1");
    }

    void OnGUI()
    {
        GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
    }

    void OnJoinedLobby()
    {
        Debug.Log("OnJoinedLobby");
        PhotonNetwork.JoinRandomRoom();
    }
    */
    void OnPhotonRandomJoinFailed()
    {
        Debug.Log("OnPhotonRandomJoinFailed");
        PhotonNetwork.CreateRoom(null);
    }

    void OnJoinedRoom()
    {
        Debug.Log("OnJoinedRoom");
        GameObject.Find("PickupManager").GetComponent<PickupManager>().startPickupRoutine();
        SpawnMyPlayer();
    }
    
    void SpawnMyPlayer()
    {
        GameControl.control.TotalMatches++;
        GameControl.control.WriteStats();
        if (spawnSpots == null)
        {
            Debug.LogError("WTF?!?!?");
            return;
        }

        SpawnSpot mySpawnSpot = spawnSpots[Random.Range(0, spawnSpots.Length)];
        myPlayerGO = (GameObject)PhotonNetwork.Instantiate("TheDrone", mySpawnSpot.transform.position, mySpawnSpot.transform.rotation, 0);
        standbyCamera.SetActive(false);
        Debug.Log("Spawned");
        enableSpawnedPlayerComponents();
    }
    void enableSpawnedPlayerComponents()
    {
        ((MonoBehaviour)myPlayerGO.GetComponent("Movement")).enabled = true;
        ((MonoBehaviour)myPlayerGO.GetComponent("Rotation")).enabled = true;
        ((MonoBehaviour)myPlayerGO.GetComponent("PlayerShooting")).enabled = true;
        myPlayerGO.transform.FindChild("Main Camera").gameObject.SetActive(true);
    }
}
