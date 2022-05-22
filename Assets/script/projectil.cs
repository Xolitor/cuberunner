    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectil : MonoBehaviour
{
    public float projectilspeed;
    public float destroyTime;
    //Rigidbody2D rb;
    float x, y;
    canon canon;

    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, destroyTime);
        y = transform.position.y;
        

    }
    void Update()
    {
    x = transform.position.x;
    //transform.position = new Vector2(145 - (1 * projectilspeed * Time.deltaTime), 0.56f);
    //rb.AddForce(Vector2.left*projectilspeed*Time.deltaTime);
    transform.position = new Vector2(x - projectilspeed * Time.deltaTime, y);
        
    }
}
