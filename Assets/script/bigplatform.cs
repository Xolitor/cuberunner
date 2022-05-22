using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bigplatform : MonoBehaviour
{
    public Transform pos1, pos2;
    public float bigPlatformSpeed;
    Vector3 nextpos;
    public GameObject player;
    public float check;

    private void Awake()
    {
        //check = checkplatform.onPlatform;
    }

    void start()
    {
        nextpos = pos1.position;
    }

    /* private void OnTriggerEnter2D(Collider2D collision)
     {
         if (collision.CompareTag("Player"))
         {
             onPlatform = true;
         }
     }
     private void OnTriggerExit2D(Collider2D collision)
     {
         onPlatform = false;
     }*/

    private void Update()
    {
        check = GetComponentInChildren<checkplatform>().onPlatform;
    }

    private void FixedUpdate()
    {
        if ( check==1)
        {
            nextpos = pos2.position;
            transform.position = Vector3.MoveTowards(transform.position, nextpos, bigPlatformSpeed * Time.deltaTime);
        }
        if (check == 0)
        { 
            nextpos = pos1.position;
            transform.position = Vector3.MoveTowards(transform.position, nextpos, bigPlatformSpeed * Time.deltaTime);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(pos1.position, pos2.position);
    }
}

