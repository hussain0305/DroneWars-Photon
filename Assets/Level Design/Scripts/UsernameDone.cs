using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UsernameDone : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject username;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnPointerDown(PointerEventData eventData)
    {
        GameControl.control.Username = username.GetComponent<Text>().text;
        GameControl.control.WriteStats();
        SceneManager.LoadScene("MainMenu");
    }
    public void OnPointerUp(PointerEventData eventData)
    {
    }
}
