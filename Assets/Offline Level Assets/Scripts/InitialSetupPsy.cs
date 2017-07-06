using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialSetupPsy : MonoBehaviour {

    private float timeSinceInstantiate;
    private float instantiateDuration;
    private float instantiateAt;
    private float[] height=new float[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
    private float[] width = new float[] { -6, -5, -3, -1, 1, 3, 5, 6 };
    private GameObject Player;
    public GameObject[] blocks;

    public GameObject roof,obstacleH,obstacleV;
    // Use this for initialization
    void Start () {
        Player = GameObject.FindWithTag("Player");
        timeSinceInstantiate = 0;
        instantiateDuration = 0;
        instantiateAt = 0;
        createblocks();
	}
	
	// Update is called once per frame
	void Update () {
        timeSinceInstantiate += Time.deltaTime;
        if ((timeSinceInstantiate > instantiateDuration) && (instantiateAt < 100 + Player.transform.position.z))
            createblocks();
    }
    void createblocks()
    {
        Instantiate(blocks[Random.Range(0, blocks.Length)], new Vector3(0, 0, instantiateAt), Quaternion.identity);
        ceiling();
        
    }
    void ceiling()
    {
        if (Random.Range(0,10) > 5)
        {
            Instantiate(roof, new Vector3(0, 7, instantiateAt), Quaternion.identity);
        }

        instantiateAt += 15;
        timeSinceInstantiate = 0;
        Obstacle();
    } 
    void Obstacle()
    {
        if (Random.Range(0, 10) > 3)
        {
            Instantiate(obstacleH, new Vector3(0, height[Random.Range(0, height.Length)], instantiateAt + Random.Range(-4,4)), Quaternion.identity);
            Instantiate(obstacleV, new Vector3(width[Random.Range(0, width.Length)], 0, instantiateAt + Random.Range(-4, 4)), Quaternion.identity);
        }
    }
}
