using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public Transform pos1, pos2, startpos;
    public float enemySpeed = 0f;
    Vector3 nextpos;
    // Start is called before the first frame update
    void Start()
    {
        nextpos = startpos.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position == pos1.position)
        {
            nextpos = pos2.position;
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (transform.position == pos2.position)
        {
            nextpos = pos1.position;
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        transform.position = Vector3.MoveTowards(transform.position, nextpos, enemySpeed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(pos1.position, pos2.position);
    }
}
