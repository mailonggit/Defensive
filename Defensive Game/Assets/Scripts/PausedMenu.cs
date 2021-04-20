using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PausedMenu : MonoBehaviour
{
    [SerializeField] private GameObject menuUI, resumeBtn, pausedBtn;
    
    private void Start()
    {
        SwapButton(false, true);
    }
    public void PausedGame()
    {        
        SwapButton(true, false);
        Time.timeScale = 0f;        
    }
    public void ContinueGame()
    {
        menuUI.SetActive(false);
        SwapButton(false, true);
        Time.timeScale = 1f;
    }
    public void RetryGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level-1");        
    }
    public void DisplayMenu()
    {
        Time.timeScale = 0f;
        menuUI.SetActive(true);
        SwapButton(false, true);                
    }
    public void BackToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);        
    }
    private void SwapButton(bool resume, bool paused)
    {
        resumeBtn.SetActive(resume);
        pausedBtn.SetActive(paused);
    }
   
}
