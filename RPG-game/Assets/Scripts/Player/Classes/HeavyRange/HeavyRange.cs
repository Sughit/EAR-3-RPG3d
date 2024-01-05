using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyRange : MonoBehaviour
{
    public float damage = 3;
    public float attackRate = 1;
    [SerializeField]
    float currentAttackRate;
    public bool canAttack=true;
    bool isAttacking;
    public bool inRangeOfUtilities = false;
    [Header("Projectile")]
    public GameObject spellProjectile;
    public Transform spawnPoint;
    public float spellSpeed = 10;

    void Update()
    {
        if(GameObject.Find("GameManager").GetComponent<InGameMenu>().inGameMenuGO.activeSelf) canAttack=false;
        else if(!inRangeOfUtilities) canAttack=true;

        if(inRangeOfUtilities) canAttack=false;

        //Inputs
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
            var spell = Instantiate(spellProjectile, spawnPoint.position, spawnPoint.rotation);
            spell.GetComponent<Rigidbody>().velocity = spawnPoint.up * spellSpeed;
        }
    }
}
