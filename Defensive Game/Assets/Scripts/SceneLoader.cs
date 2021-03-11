using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(sceneName: "Level 2");
    }
    public void Option()
    {

    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
