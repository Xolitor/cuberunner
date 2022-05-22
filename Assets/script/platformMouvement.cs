using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformMouvement : MonoBehaviour
{
    public Transform posA, posB,startpos;
    public float platformSpeed;

    Vector3 nextPos; 
    // Start is called before the first frame update
    void Start()
    {
        nextPos = startpos.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position == posA.position)
        {
            nextPos = posB.position;
        }
        if (transform.position == posB.position)
        {
            nextPos = posA.position;
        }
        transform.position = Vector3.MoveTowards(transform.position, nextPos, platformSpeed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(posA.position, posB.position);
    }
}
