using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void playButton()
    {
        SceneManager.LoadScene("OutdoorsScene");
    }

    public void exitButton()
    {
        Application.Quit();
    }

    public void returnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void retry()
    {
        SceneManager.LoadScene("OutdoorsScene");
    }
}
