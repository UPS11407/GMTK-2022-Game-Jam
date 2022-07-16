using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GlobalController : MonoBehaviour
{
    public Text _coinText;
    public GameObject _pauseMenu;
    
    public string _mainLevelScene;
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
            GameObject.Find("Player").GetComponent<PlayerBase>().ResetLevel(SceneManager.GetSceneByName(_mainLevelScene));
        }

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
    }

    void UnPauseGame()
    {
        Time.timeScale = 1;
    }
}
