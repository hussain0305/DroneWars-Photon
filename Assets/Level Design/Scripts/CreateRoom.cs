using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class CreateRoom : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnPointerDown(PointerEventData eventData)
    {
        SceneManager.LoadScene("MultiMatch");
    }
    public void OnPointerUp(PointerEventData eventData)
    {
    }
}
