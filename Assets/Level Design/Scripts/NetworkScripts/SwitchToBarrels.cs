using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchToBarrels : MonoBehaviour {

    // Use this for initialization
    private float age;
    private Text FlashMessages;
    // Use this for initialization
    void Start()
    {
        FlashMessages = GameObject.Find("FlashMessages").GetComponent<Text>();
        age = 0;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0.0f, 0.2f, 0.2f);
        age += Time.deltaTime;
        if (age > 25)
            PhotonNetwork.Destroy(this.gameObject);
    }
    void OnTriggerEnter(Collider col)
    {
        col.gameObject.GetComponent<PlayerShooting>().currentPrefab = "Barrel";
        int temp = Array.IndexOf(col.gameObject.GetComponent<PlayerShooting>().weapons, "Barrel");
        col.gameObject.GetComponent<PlayerShooting>().unlockedWeapons[temp] = true;
        PhotonNetwork.Destroy(this.gameObject);
        StartCoroutine(ShowMessage("Active Weapon: Explosive Barrels", 3));
    }
    IEnumerator ShowMessage(string message, float delay)
    {
        FlashMessages.enabled = true;
        FlashMessages.text = message;
        yield return new WaitForSeconds(delay);
        FlashMessages.enabled = false;
    }
}
