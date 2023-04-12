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
    private void Awake()
    {
        currentHealth = staringhealth;
        anim = GetComponent<Animator>();    
    }
    public void takedamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, staringhealth);
        if(currentHealth > 0)
        {
         
        }
        else
        {
           if(!_isDead)
            {
                anim.SetTrigger("isDead");
                GetComponent<Playermovement>().enabled = false;
                _isDead = true;

            }
        }
    }
   public void addvaluehealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, staringhealth);
    }
}
