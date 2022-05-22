using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingplatform : MonoBehaviour
{
    Rigidbody2D rb;
    private bool fallCheck=true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag=="Player"&& fallCheck){
            fallCheck = false;
            platformManager.Instance.StartCoroutine("spawnPlatform", new Vector2(transform.position.x, transform.position.y));
            Invoke("platformFall", 0.5f);
            rb.gravityScale = 3f;
            Destroy(gameObject, 4f);
        }
    }

    void platformFall()
    {
        rb.isKinematic = false;
    }
}
