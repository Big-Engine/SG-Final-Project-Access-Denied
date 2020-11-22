using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject helpPanel;

    public void OnClickPlayButton()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void OnClickHelpButton()
    {
        helpPanel.SetActive(true);
    }

    public void OnClickBackButton()
    {
        helpPanel.SetActive(false);
    }

    public void OnClickQuitButton()
    {
        Application.Quit();
        Debug.Log("quit");
    }
}
