using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class RayShoot : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    // Use this for initialization
    private int flag;
    private GameObject CamParent;
    private Component Script;
    void Start()
    {
        flag = -1;
        CamParent = GameObject.FindWithTag("CamParent");
        Script= GameObject.FindWithTag("FlashSocket").GetComponent<LaserSight>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (flag > 0)
        {
            CamParent.GetComponent<PlayerShooting>().Fire();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (CamParent == null)
            CamParent = GameObject.FindWithTag("CamParent");
        if (Script == null)
            Script = GameObject.FindWithTag("FlashSocket").GetComponent<LaserSight>();
        flag *= -1;
        Script.GetComponent<PhotonView>().RPC("toggle",PhotonTargets.All);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        flag *= -1;
        Script.GetComponent<PhotonView>().RPC("toggle", PhotonTargets.All);
    }
}
