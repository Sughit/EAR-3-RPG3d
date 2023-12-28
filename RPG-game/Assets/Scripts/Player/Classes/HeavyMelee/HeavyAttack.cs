using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyAttack : MonoBehaviour
{
    [Header("Heavy Attack")]
    public float maxDamage = 3;
    public float timeToHeavyAttack = 3;
    float startTimer;
    float endTimer;
    [Space]
    public float damage = 2;
    public float attackRate = 1;
    float currentAttackRate;
    public bool canAttack = true;

    public static bool heavy;

    void Awake()
    {
        startTimer = 0;
        endTimer = 0;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && canAttack)
        {
            if(currentAttackRate <= 0)
            {
                Attack();
                currentAttackRate = attackRate;
            }
            else
            {
                currentAttackRate -= Time.deltaTime;
            }
        }

        if(Input.GetMouseButtonDown(1))
        {
            startTimer = Time.time;
        }

        if(Input.GetMouseButtonUp(1))
        {
            endTimer = Time.time;
        }

        if((endTimer - startTimer) > timeToHeavyAttack && canAttack)
        {
            Heavy();
            startTimer = 0;
            endTimer = 0;
        }
    }

    void Attack()
    {
        Debug.Log("Attack");
    }

    void Heavy()
    {
        Debug.Log("Heavy attack");
        ShakeCamera.shake = true;
    }
}
