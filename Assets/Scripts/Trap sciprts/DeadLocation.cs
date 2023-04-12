using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadLocation : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.tag =="Player")
        {
            Destroy(gameObject);
        }
    }
}
