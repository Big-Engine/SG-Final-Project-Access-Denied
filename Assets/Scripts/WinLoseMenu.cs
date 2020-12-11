using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseMenu : MonoBehaviour
{
    public void OnClickPlayButton()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void OnClickMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnClickQuitButton()
    {
        Application.Quit();
        Debug.Log("quit");
    }
}
