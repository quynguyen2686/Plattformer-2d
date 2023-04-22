using System;
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
    public static event Action PlayerDead;
    [SerializeField] private AudioSource Hurt;

    private void Awake() 
    {
        currentHealth = staringhealth;
        anim = GetComponent<Animator>();    
    }
    public void takedamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, staringhealth);
        Hurt.Play();
        if (currentHealth <= 0 && !_isDead)
        {
            _isDead = true;
            PlayerDead?.Invoke();
            anim.SetTrigger("isDead");
         
        }
    }
           

    public void addvaluehealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, staringhealth);
    }
}
