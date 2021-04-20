using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    [SerializeField] SceneFader sceneFader;
    public void PlayGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        sceneFader.FadeTo(1);
    }
    public void Help()
    {

    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
