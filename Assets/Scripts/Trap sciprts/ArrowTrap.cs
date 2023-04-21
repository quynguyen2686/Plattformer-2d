using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    [SerializeField] private float attackCD;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] Arrows;
    private float CDtimer;
    private void attack()
    {
        CDtimer = 0;
        Arrows[FindFireball()].transform.position = firePoint.position;
        Arrows[FindFireball()].GetComponent<EnemyProjectile>().ActiveProjectile();

    }
    private int FindFireball()
    {
        for(int i = 0;i < Arrows.Length; i++)
        {
            if (!Arrows[i].activeInHierarchy) 
                return i;
        }
        return 0;
    }
    private void Update()
    {
        
        CDtimer += Time.deltaTime;
        if(CDtimer >= attackCD)
        {
            attack();
        }
    }
}
