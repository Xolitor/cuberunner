using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winPlace : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(winAnim());
        }
    }

    IEnumerator winAnim()
    {
        yield return new WaitForSeconds(0.75f);
        SceneManager.LoadScene("End_Screen");
    }
}
