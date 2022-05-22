using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ending_Screen : MonoBehaviour
{
    public CanvasGroup uiElement;
    public Animator fadeSystem;
    void Start()
    {
        StartCoroutine(loadPanel(uiElement));
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
    public IEnumerator loadPanel(CanvasGroup cg)
    {
        yield return new WaitForSeconds(0.6f);
        for (uiElement.alpha = 0; uiElement.alpha <= 1; uiElement.alpha += Time.deltaTime)
        {
            yield return null;
        }
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
