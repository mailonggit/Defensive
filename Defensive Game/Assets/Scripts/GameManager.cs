using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool isGameOver;
    [SerializeField] private GameObject gameOverUI;
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
}
