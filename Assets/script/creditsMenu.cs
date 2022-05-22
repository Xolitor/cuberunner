using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class creditsMenu : MonoBehaviour
{
    public CanvasGroup uiElement;
    public Animator fadeSystem;
    void Start()
    {
        uiElement.interactable = true;
    }

    public void returnMenu()
    {
        StartCoroutine(faker(uiElement));
        StartCoroutine(loadMenu());
    }

    public IEnumerator loadMenu()
    {
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("menu");
    }
    public IEnumerator faker(CanvasGroup cg)
    {
        while (uiElement.alpha > 0)
        {
            uiElement.alpha -= Time.deltaTime * 1.75f;
            yield return null;
        }
        yield return null;
    }
}
