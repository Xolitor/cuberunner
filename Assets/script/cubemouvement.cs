using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class cubemouvement : MonoBehaviour
{
    [Header("Particle Systems")]
    public ParticleSystem dust;
    public ParticleSystem death;

    [Header("Horizontal mouvement")]
    public float movespeed = 0f;
    private float mouvementInput;

    [Header("Jump system")]
    public float jumpVelocity = 0f;
    public float jumpDelay = 0f;

    public float fallMultiplier;
    public float lowMuliplier;
    public bool isGrounded;
    public float groundLength = 0f;
    public Vector3 colliderOffset;
    public float platform;
    public bool onPlatform =false;


    [Header("Components")]
    public LayerMask ground;
    public Rigidbody2D rb;
    public GameObject player;
    public Transform spawnPoint;

    [Header("Respawn")]
    public GameObject maincamera;
    public SpriteRenderer rend;
    public bool isAlive=true;


    private void Start()
    {
        transform.position = spawnPoint.position;
        rend = GetComponent<SpriteRenderer>();
        rend.enabled = true;
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); //this line allows to apply a force to the rigidbody of the player
    }
    void Update()
    {
        mouvementInput = Input.GetAxisRaw("Horizontal") * movespeed;
        if (isAlive)
        {
            if (mouvementInput > 0) //flip the sprite depending on the direction the cube is facing
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                dust.transform.eulerAngles = new Vector3(0, 0, 0);
            }
            if (mouvementInput < 0)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                dust.transform.eulerAngles = new Vector3(0, 90, 0);
            }
            isGrounded = Physics2D.Raycast(transform.position + colliderOffset, Vector2.down, groundLength, ground) || Physics2D.Raycast(transform.position - colliderOffset, Vector2.down, groundLength, ground);   // creates an array facing down starting from the center of the cube

            if (isGrounded)
            {
                jump();
                if (mouvementInput != 0)
                {
                    createDust();
                }
            }
            Debug.Log(mouvementInput);
            
        }
    }

    void FixedUpdate()
    {
        if (isAlive)
        {
            gravity();
            rb.velocity = new Vector2(mouvementInput, rb.velocity.y);//allows the cube to move horizontally
        }
    }



    void jump()
    {
        if (onPlatform == false)
        {
            if (Input.GetButtonDown("Jump")) //jumps whenever the player presses jump button
            {
                rb.AddForce(Vector2.up * jumpVelocity);
                FindObjectOfType<audiomanager>().Play("jump");
                Debug.Log(Time.deltaTime);
                //StartCoroutine(JumpSqueeze(0.65f, 0.8f, 0.15f));
            }
        }
        if (onPlatform == true)
        {
            if (Input.GetButtonDown("Jump")) //jumps whenever the player presses jump button
            {
                rb.AddForce(Vector2.up * jumpVelocity * platform);
                FindObjectOfType<audiomanager>().Play("jump");
                //StartCoroutine(JumpSqueeze(0.65f, 0.8f, 0.2f));
            }
        }
    }

    void gravity()
    {
        if (rb.velocity.y < 0) //when the cube is falling applies a stronger gravity
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump")) //if the player is going up applies a smaller gravity to give a sens of floating
        {
           
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowMuliplier - 1) * Time.deltaTime;
        }
    }
    private void OnDrawGizmos() //visual debugging to help see the array that detects if the cube is on the ground
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position - colliderOffset, transform.position - colliderOffset + Vector3.down * groundLength);
        Gizmos.DrawLine(transform.position + colliderOffset, transform.position + colliderOffset + Vector3.down * groundLength);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("deathZone"))
        {
            StartCoroutine(deathanim());
            FindObjectOfType<audiomanager>().Play("PlayerDeath");
        }
        if (collision.CompareTag("enemy")) 
        {
            StartCoroutine(deathanim());
            FindObjectOfType<audiomanager>().Play("PlayerDeath");
        }
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "platform")
        {
            player.transform.parent = collision.gameObject.transform;
            onPlatform = true;
        }
        if (collision.collider.tag == "bigplatform")
        {
            player.transform.parent = collision.gameObject.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        player.transform.parent = null;
        onPlatform = false;
    }

    IEnumerator JumpSqueeze(float xSqueeze, float ySqueeze, float seconds)
    {
        Vector3 originalSize = Vector3.one;
        Vector3 newSize = new Vector3(xSqueeze, ySqueeze, originalSize.z);
        float t = 0f;

            while (t <= 1.0)
            {
                t += Time.deltaTime / seconds;
                transform.localScale = Vector3.Lerp(originalSize, newSize, t);
                yield return null;
            }
            t = 0f;
            while (t <= 1.0)
            {
                t += Time.deltaTime / seconds;
                transform.localScale = Vector3.Lerp(newSize, originalSize, t);
                yield return null;
            }

    }

    IEnumerator deathanim()
    {
        death.Play();
        isAlive = false;
        maincamera.GetComponent<cameramouvement>().enabled = false;
        rend.enabled = false;
        Destroy(rb);
        yield return new WaitForSeconds(1.5f);
        transform.position = spawnPoint.position;
        maincamera.GetComponent<cameramouvement>().enabled = true;
        rend.enabled = true;
        gameObject.AddComponent<Rigidbody2D>();
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        isAlive = true;
    }

    void createDust()
    {
        dust.Stop();
        var dustMainSettings = dust.main;
        dust.Play();
    }
}
