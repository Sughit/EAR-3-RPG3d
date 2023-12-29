using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRange : MonoBehaviour
{
    public float damage = 1;
    public float attackRate = 3;
    [SerializeField]
    float currentAttackRate;
    public float attackRange = 5;
    public bool canAttack=true;
    public GameObject spellProjectile;
    bool isAttacking;

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && canAttack)
        {
            Attack();
        }

        if(isAttacking)
        {
            currentAttackRate += Time.deltaTime;
            if(currentAttackRate >= attackRate)
            {
                currentAttackRate = 0;
                isAttacking=false;
            }
        }
    }

    void Attack()
    {
        isAttacking=true;
        if(currentAttackRate == 0)
        {
            Debug.Log("Attack");
            Instantiate(spellProjectile, transform.position, Quaternion.identity);
        }
    }
}
