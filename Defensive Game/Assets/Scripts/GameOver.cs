using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    [SerializeField] private SceneFader sceneFader;    
    public void Retry()
    {
        sceneFader.FadeTo(SceneManager.GetActiveScene().buildIndex);
    }
    public void Menu()
    {
        sceneFader.FadeTo(0);
    }
}
