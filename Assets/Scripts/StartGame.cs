using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    [SerializeField] private Text gameName = null;
    [SerializeField] private Text tapToStart = null;
    [SerializeField] private GameObject player = null;


    public void SG()
    {
        tapToStart.gameObject.SetActive(false);
        gameName.gameObject.SetActive(false);
        Camera.main.GetComponent<CameraFollow>().StartGame();
        player.GetComponent<Animator>().SetBool("isStart", true);
    }

}
