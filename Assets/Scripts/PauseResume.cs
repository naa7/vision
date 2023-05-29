using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PauseResume : MonoBehaviour
{
    public TextMeshProUGUI pauseText; 
    public Button pauseButton;
    public Button resumeButton;
    void Start()
    {
        pauseButton.gameObject.SetActive(true);
        resumeButton.gameObject.SetActive(false);
        pauseText.enabled = false;

    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseButton.gameObject.SetActive(false);
        resumeButton.gameObject.SetActive(true);
        pauseText.enabled = true;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseButton.gameObject.SetActive(true);
        resumeButton.gameObject.SetActive(false);
        pauseText.enabled = false;
    }
}
