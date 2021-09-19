using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    private void OnMouseUpAsButton()
    {
        switch (gameObject.name)
        {
            case "Home":
                RestartGame.Restart = false; 
                SceneManager.LoadScene("Main");
                break;
            case "Restart":
                RestartGame.Restart = true;
                SceneManager.LoadScene("Main");
                break;
        }
    }
}
