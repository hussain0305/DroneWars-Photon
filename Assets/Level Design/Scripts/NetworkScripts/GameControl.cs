using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameControl : MonoBehaviour {

    // Use this for initialization
    public static GameControl control;

    public string Username= "executioner.";
    public int TotalMatches = 1;
    public int Wins = 0;
    public int Losses = 0;
    public int EndlessRunScore = 0;

    void Awake()
    {
        
        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if(control != this)
        {
            Destroy(gameObject);
        }
    }

    void Start () {
        ReadStats();
        if (Username == "executioner.")
        {
            askUsername();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void WriteStats()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/Stats.dat");

        Stats stat = new Stats();
        stat.Username = Username;
        stat.TotalMatches = TotalMatches;
        stat.Wins = Wins;
        stat.Losses = Losses;
        stat.EndlessRunScore = EndlessRunScore;
        bf.Serialize(file, stat);
        file.Close();
    }
    public void ReadStats()
    {
        if(File.Exists(Application.persistentDataPath + "/Stats.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/Stats.dat", FileMode.Open);
            Stats stat = (Stats)bf.Deserialize(file);
            file.Close();

            Username = stat.Username;
            TotalMatches = stat.TotalMatches;
            Wins = stat.Wins;
            Losses = stat.Losses;
            EndlessRunScore = stat.EndlessRunScore;
        }
    }
    public void askUsername()
    {
        SceneManager.LoadScene("username");
    }
}

[Serializable]
class Stats
{
    public string Username;
    public int TotalMatches;
    public int Wins;
    public int Losses;
    public int EndlessRunScore;
}
