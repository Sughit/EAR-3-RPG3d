using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyAttack : MonoBehaviour
{
    [Header("Heavy Attack")]
    public float maxDamage = 3;
    public float timeToHeavyAttack = 3;
    float startTimer;
    public ShakeCamera camShake;
    [Space]
    public float damage = 2;
    public float attackRate = 1;
    float currentAttackRate;
    public bool canAttack = true;

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && canAttack)
        {
            Attack();
        }

        if(Input.GetMouseButtonDown(1) && canAttack)
        {
            startTimer = Time.time;
        }

        if(Input.GetMouseButton(1) && canAttack)
        {
            if((startTimer + timeToHeavyAttack) >= Time.time) Heavy();
        }
    }

    void Attack()
    {
        Debug.Log("Attack");
    }

    void Heavy()
    {
        Debug.Log("Heavy attack");
        camShake.CameraShake();
    }
}
