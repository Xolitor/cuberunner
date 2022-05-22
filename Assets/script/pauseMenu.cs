using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public GameObject bigPanel;
    public GameObject settingwindow;
    public GameObject blurpanel;


    private void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            pause();
        }
    }
    public void pause()
    {
        blurpanel.SetActive(true);
        bigPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void restart()
    {
        blurpanel.SetActive(false);
        SceneManager.LoadScene("Level01");
        Time.timeScale = 1;
    }

    public void Play()
    {
        bigPanel.SetActive(false);
        blurpanel.SetActive(false);
        Time.timeScale = 1;
    }
    public void Settings()
    {
        bigPanel.SetActive(false);
        settingwindow.SetActive(true);
    }

    public void Exit()
    {
        SceneManager.LoadScene("menu");
        Time.timeScale = 1;
    }

    public void closeSettings()
    {
        bigPanel.SetActive(true);
        settingwindow.SetActive(false);
    }
}
