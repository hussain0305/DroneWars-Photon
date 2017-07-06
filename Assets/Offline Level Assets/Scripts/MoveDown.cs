using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class MoveDown : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    // Use this for initialization
    int flag = -1;
    private GameObject Player;
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (flag > 0)
        {
            Player.GetComponent<AutoMotion>().goDown();
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
