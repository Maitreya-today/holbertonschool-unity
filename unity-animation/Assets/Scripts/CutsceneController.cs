using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    Animator anim;
    public GameObject mainCamera;
    public GameObject player;
    public GameObject timerCanvas;
    public GameObject cutCamera;
    
    void awake()
    {
        anim = GetComponent<Animator>();
        Debug.Log("awake");
    }

    void StartGame()
    {
        Debug.Log("brfore transition");
        cutCamera.SetActive(false);
        mainCamera.SetActive(true);
        timerCanvas.SetActive(true);
        player.gameObject.GetComponent<PlayerController>().enabled = true;
        
        Debug.Log("after trans");
    }
}
