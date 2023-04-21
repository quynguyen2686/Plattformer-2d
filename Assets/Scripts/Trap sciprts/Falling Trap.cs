using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTrap : MonoBehaviour
{
   
    private float destroydelay = 2f;
    [SerializeField] private Rigidbody2D RBfan;

    private void Start()
    {
        RBfan = GetComponent<Rigidbody2D>();    
    }
    //private  IEnumerator Fall()
    //{
    //    RBfan.bodyType = RigidbodyType2D.Dynamic;
    //    Destroy(gameObject, destroydelay);
    //    yield return new WaitForSeconds(falldelay);
    //}
    // Start is called before the first frame update 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("DropFlat", 0.5f);
            Destroy(gameObject, 2f);
        }
    }
    private void DropFlat()
    {
        RBfan.isKinematic = false;
    }
}
