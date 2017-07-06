using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateStats : MonoBehaviour {

    // Use this for initialization
    public GameObject NoMatchesPlayed;
    public GameObject NoWins;
    public GameObject NoLosses;
    public GameObject ERScore;
    public GameObject Username;

    void Start () {
        Username.GetComponent<Text>().text = "" + GameControl.control.Username;
        NoMatchesPlayed.GetComponent<Text>().text = ""+GameControl.control.TotalMatches;
        NoWins.GetComponent<Text>().text = "" + GameControl.control.Wins;
        NoLosses.GetComponent<Text>().text = "" + GameControl.control.Losses;
        ERScore.GetComponent<Text>().text = "" + GameControl.control.EndlessRunScore;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
