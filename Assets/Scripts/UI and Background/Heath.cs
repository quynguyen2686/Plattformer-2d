using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Heath : MonoBehaviour
{
    [SerializeField] private float staringhealth;
     private Animator anim;
    private bool _isDead;
    public float currentHealth { get; private set; }
   [SerializeField] private GameManager gameManager;
    private void Awake() 
    {
        currentHealth = staringhealth;
        anim = GetComponent<Animator>();    
    }
    public void takedamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, staringhealth);
        if (currentHealth <= 0 && !_isDead)
        {
           
                _isDead = true;
                gameManager.GameOver();
                anim.SetTrigger("isDead");
                GetComponent<Playermovement>().enabled = false;

          
        }
    }
           

   public void addvaluehealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, staringhealth);
    }
}
