using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroScript : MonoBehaviour
{

    int pSpeed;
    int pHealth;

    // Start is called before the first frame update
    void Start()
    {
        if (pSpeed == 0)
        {
            pSpeed = 5;
        }   

        if (pHealth == 0)
        {
            pHealth = 3;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            //move up
        }
    }
}
