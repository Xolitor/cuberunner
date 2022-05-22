using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
    private Transform playerSpawn;

    // Start is called before the first frame update
    private void Awake()
    {
        playerSpawn = GameObject.FindGameObjectWithTag("spawnpoint").transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerSpawn.position = transform.position;
            Destroy(gameObject);
        }
    }
}
