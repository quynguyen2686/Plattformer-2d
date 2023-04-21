using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikeballrotate : MonoBehaviour
{
     private float speed = 0.5f;


    // Update is called once per frame  
    void Update()
    {
        transform.Rotate(0,0,speed);
    }
}
