using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollection: MonoBehaviour
{
    private int point;
    [SerializeField] private Text pointText;
    [SerializeField] private AudioSource collectionEffect;
    private float heathvalue = 1f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PineApple"))
        {
            Destroy(collision.gameObject);
            point++;
            pointText.text = "x" + point;
            collectionEffect.Play();    
            GetComponent<Heath>().addvaluehealth(heathvalue);
        }  
        
    }
}
