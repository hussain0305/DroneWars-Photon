﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System;

public class MMBStart : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    // Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnPointerDown(PointerEventData eventData)
    {
        //SceneManager.LoadScene("MultiMatch");
        SceneManager.LoadScene("Lobby");
    }
    public void OnPointerUp(PointerEventData eventData)
    {
    }
}