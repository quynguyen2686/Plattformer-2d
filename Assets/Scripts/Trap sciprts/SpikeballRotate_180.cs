using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeballRotate_180 : MonoBehaviour
{
     private float speed = -0.8f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,speed);
    }
}
