using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PausedMenu : MonoBehaviour
{
    [SerializeField] private GameObject menuUI  , resumeBtn, pausedBtn;
    // Start is called before the first frame update

    private void Start()
    {
        ActivateBtn(false, true);
    }
    public void PausedGame()
    {        
        ActivateBtn(true, false);
        Time.timeScale = 0f;        
    }
    public void ContinueGame()
    {
        menuUI.SetActive(false);
        ActivateBtn(false, true);
        Time.timeScale = 1f;
    }
    public void RetryGame()
    {
        menuUI.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }
    public void Menu()
    {
        menuUI.SetActive(true);
        ActivateBtn(false, true);
        Time.timeScale = 0f;
    }

    private void ActivateBtn(bool resume, bool paused)
    {
        resumeBtn.SetActive(resume);
        pausedBtn.SetActive(paused);
    }

}
