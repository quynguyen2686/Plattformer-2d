using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heath : MonoBehaviour
{
    [SerializeField] private float staringhealth;
    private float currentHealth;
    private void Awake()
    {
        currentHealth = staringhealth;
    }
    private void takedamage(float _damage)
    {
        currentHealth = Mathf.Lerp(currentHealth - _damage, 0, staringhealth);
        if(currentHealth < 0)
        {
            //player dead animation
        }
        else
        {
            //player hurt
        }
    }
}
