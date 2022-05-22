using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramouvement : MonoBehaviour
{
    public Transform cube;

    private void Start()
    {
        transform.position = new Vector3(cube.position.x, cube.position.y + 2, transform.position.z);
    }
    private void FixedUpdate()
    {
        transform.position = new Vector3(cube.position.x, cube.position.y+2,transform.position.z);
    }
}
