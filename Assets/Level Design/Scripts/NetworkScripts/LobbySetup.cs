using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LobbySetup : MonoBehaviour {

    private int LobbyCount, RoomCount;
    private Text LobbyMsg, RoomMsg;
    void Start()
    {
        LobbyMsg = GameObject.Find("LobbyInfo").GetComponent<Text>();
        RoomMsg = GameObject.Find("RoomInfo").GetComponent<Text>();
        LobbyMsg.enabled = true;
        LobbyMsg.text = "Players currently Looking for Games: "+ LobbyCount;
        RoomMsg.enabled = true;
        RoomMsg.text = "Active Rooms: " + RoomCount;
        Connect();
    }

    void Update()
    {
        LobbyCount = PhotonNetwork.countOfPlayersOnMaster;
        RoomCount = PhotonNetwork.countOfRooms;
        LobbyMsg.text = "Players currently Looking for Games: " + LobbyCount;
        RoomMsg.text = "Active Rooms: " + RoomCount;
    }

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
        Debug.Log("In Lobby");
        //PhotonNetwork.JoinRandomRoom();
    }
}
