using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class PrefabShoot : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    private int flag;
    private GameObject CamParent;
    void Start () {
        flag = -1;
        CamParent = GameObject.FindWithTag("CamParent");
    }

    void Update () {
        if (CamParent == null)
            CamParent = GameObject.FindWithTag("CamParent");
        if (flag > 0)
        {
            CamParent.GetComponent<PlayerShooting>().LaunchProjectile();
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
