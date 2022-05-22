using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public CanvasGroup uiElement;
    public Animator fadeSystem;
    public GameObject settingwindow;

    private void Start()
    {
        StartCoroutine(loadMenu(uiElement));
        uiElement.interactable = true;
    }
    public void Play()
    {
     StartCoroutine(faker(uiElement));
     StartCoroutine(loadNextScene());
    }

    public void Settings()
    {
        settingwindow.SetActive(true);
    }

    public void Credit()
    {
        StartCoroutine(faker(uiElement));
        StartCoroutine(loadCredit());
    }
    public void Exit()
    {
        Debug.Log("quit");
        Application.Quit();
    }

    public void closeSettings()
    {
        settingwindow.SetActive(false);
    }

    public IEnumerator loadNextScene()
    {
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Level01");
    }
    public IEnumerator loadCredit()
    {
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("credit");
    }

    public IEnumerator faker(CanvasGroup cg)
    {
        while (uiElement.alpha > 0)
        {
            uiElement.alpha -= Time.deltaTime*1.75f;
            yield return null;
        }
        yield return null;
    }

    public IEnumerator loadMenu(CanvasGroup cg)
    {
        yield return new WaitForSeconds(0.75f);
        for (uiElement.alpha = 0; uiElement.alpha <= 1; uiElement.alpha += Time.deltaTime)
        {
            yield return null;
        }
    }
}
