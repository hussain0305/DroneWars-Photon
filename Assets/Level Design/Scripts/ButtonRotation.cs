﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class ButtonRotation : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // Use this for initialization
    private int flag;
    private GameObject CamParent;
    void Start () {
        flag = -1;
        CamParent = GameObject.FindWithTag("CamParent");
	}
	
	// Update is called once per frame
	void Update () {
        if (flag > 0)
        {
            CamParent.GetComponent<Movement>().moveForward();
        }
	}

    public void OnPointerDown(PointerEventData eventData)
    {
        flag *= -1;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        flag *= -1;
    }
}