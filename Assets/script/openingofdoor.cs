using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openingofdoor : MonoBehaviour
{
    public GameObject door;
    public Transform finalPos;
    public bool closed =true;
    private void Start()
    {
        closed = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            closed = false;
        }
    }

    private void FixedUpdate()
    {
        if (closed == false)
        {
            door.transform.position = Vector3.MoveTowards(door.transform.position, finalPos.position, 2 * Time.deltaTime);
        }
    }
}
