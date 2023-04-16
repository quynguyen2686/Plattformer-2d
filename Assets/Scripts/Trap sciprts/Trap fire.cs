using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trapfire : MonoBehaviour
{
    [SerializeField] private Animator anim;
    private bool isOn;
    [SerializeField] private float coolDown;
    private float coolDowntimer;
    [SerializeField] private BoxCollider2D collider;
 

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        coolDowntimer -= Time.deltaTime;
        if( coolDowntimer < 0 )
        {
            isOn = !isOn;
            coolDowntimer = coolDown;
        }
        collider.enabled = isOn;
        anim.SetBool("isOn", isOn);
    }
}
