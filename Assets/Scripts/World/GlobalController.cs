using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GlobalController : MonoBehaviour
{
    public Text _coinText;
    public Text _diceText;
    public GameObject _pauseMenu;
    public GameObject _wall;
    
    public float _topBounds;
    public float _bottomBounds;

    private int coinCount;
    private bool paused;

    public void AddCoin(int val)
    {
        coinCount += val;
    }

    void Update()
    {
        if(GameObject.Find("Player").transform.position.y > _topBounds || GameObject.Find("Player").transform.position.y < _bottomBounds)
        {
            SceneManager.LoadScene("DeathScreen");
        }

        if(coinCount >= 6)
        {
            Destroy(_wall);
        }

        _diceText.text = $"Current Dice: {GameObject.Find("Player").GetComponent<PlayerDice>()._diceType}";
        _coinText.text = coinCount.ToString();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused)
            {
                PauseGame();
            }
            else
            {
                UnPauseGame();
            }
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0;
        _pauseMenu.SetActive(true);
        paused = true;
    }

    public void UnPauseGame()
    {
        Time.timeScale = 1;
        _pauseMenu.SetActive(false);
        paused = false;
    }

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
}
