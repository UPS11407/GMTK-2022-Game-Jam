using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Debug.Log("Quit to desktop");
        Application.Quit();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("Level");
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void LoadControls()
    {
        SceneManager.LoadScene("Controls");
    }
}
