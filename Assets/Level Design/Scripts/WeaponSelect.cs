using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class WeaponSelect : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private GameObject CamParent;
    // Use this for initialization
    void Start () {
        CamParent = GameObject.FindWithTag("CamParent");
    }
	
	// Update is called once per frame
	void Update () {
        if (CamParent == null)
            CamParent = GameObject.FindWithTag("CamParent");
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        CamParent.GetComponent<PlayerShooting>().prefabDetails();
    }
    public void OnPointerUp(PointerEventData eventData)
    {
     
    }
}
