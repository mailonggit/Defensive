using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static bool isGameOver;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private SceneFader sceneFader;    
    private void Start()
    {
        isGameOver = false;       
    }
    private void Update()
    {
        if (isGameOver)
        {
            return;
        }
        if (PlayerInfo.Lives <= 0)
        {
            GameOver();
        }
    }
    private void GameOver()
    {
        isGameOver = true;
        gameOverUI.SetActive(true);
    }
    public void FinishedLevel()
    {
        Debug.Log("Level Completed!!");
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        PlayerPrefs.SetInt("levelReached", nextScene);
        sceneFader.FadeTo(nextScene);

    }
}
