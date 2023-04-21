using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerlife : MonoBehaviour
{
    private Rigidbody2D rbplayer;
    private Animator anim;


    private void Start()
    {
        rbplayer = GetComponent<Rigidbody2D>();
        anim= GetComponent<Animator>(); 
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }
    private void Die()
    {
        rbplayer.bodyType = RigidbodyType2D.Kinematic;
        anim.SetTrigger("isDead");
    }
}
