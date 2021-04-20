using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelSelector : MonoBehaviour
{
    [SerializeField] private SceneFader sceneFader;
    [SerializeField] private Button[] lvButtons;
    private void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);
        for (int i = 0; i < lvButtons.Length; i++)
        {
            if (i + 1 > levelReached)
            {
                lvButtons[i].interactable = false;
            }
            
        }
    }
    public void Select(int levelIndex)
    {
        sceneFader.FadeTo(levelIndex + 1);
    }
}
