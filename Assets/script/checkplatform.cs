using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkplatform : MonoBehaviour
{
    public float onPlatform;
    public GameObject player;
    Rigidbody2D rb;
    public Collider2D collision;
    cubemouvement stat;

    private void Awake()
    {
        rb = player.GetComponent<Rigidbody2D>();
        stat = player.GetComponent<cubemouvement>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            onPlatform = 1;
            if (Input.GetButtonDown("Jump"))
            {
                Debug.Log("jump");
                rb.AddForce(Vector2.up * stat.jumpVelocity * stat.platform); 
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        onPlatform = 0;
    }

    private void Update()
    {
        if (stat.isAlive == false)
        {
            onPlatform = 0;
        }
    }
}
