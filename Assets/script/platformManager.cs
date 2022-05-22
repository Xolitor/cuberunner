using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformManager : MonoBehaviour
{
    public static platformManager Instance = null;
    public GameObject platformprefab;

    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator spawnPlatform (Vector2 spawnposition)
    {
        yield return new WaitForSeconds(5f);
        Instantiate(platformprefab, spawnposition, platformprefab.transform.rotation);
    }
}
