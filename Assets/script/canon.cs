using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canon : MonoBehaviour
{
    public GameObject projectil;
    public Transform exit;
    public float startTime;
    private float reloadTime;
    AudioSource canonSound;
    // Start is called before the first frame update


    void Start()
    {
        reloadTime = startTime;
        canonSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (reloadTime <= 0)
        {
            canonSound.Play();
            Instantiate(projectil, transform.position,transform.rotation) ;
            reloadTime = startTime;
        }
        else
        {
            reloadTime -= Time.deltaTime;
        }
       
    }
}
