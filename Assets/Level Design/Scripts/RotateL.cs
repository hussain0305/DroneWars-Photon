using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class RotateL : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // Use this for initialization
    private int flag;
    private GameObject CamParent;
    void Start()
    {
        flag = -1;
        CamParent = GameObject.FindWithTag("CamParent");
    }

    // Update is called once per frame
    void Update()
    {
        if (CamParent == null)
            CamParent = GameObject.FindWithTag("CamParent");
        if (flag > 0)
        {
            CamParent.GetComponent<Rotation>().rotateLeft();
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
