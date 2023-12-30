using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRange : MonoBehaviour
{
    public float damage = 1;
    public float attackRate = 3;
    [SerializeField]
    float currentAttackRate;
    public bool canAttack=true;
    bool isAttacking;
    [Header("Projectile")]
    public GameObject spellProjectile;
    public Transform spawnPoint;
    public float spellSpeed = 10;

    void Update()
    {
        if(GameObject.Find("GameManager").GetComponent<InGameMenu>().inGameMenuGO.activeSelf) canAttack=false;
        else canAttack=true;
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
            ShakeCamera.shake = true;
            var spell = Instantiate(spellProjectile, spawnPoint.position, spawnPoint.rotation);
            spell.GetComponent<Rigidbody>().velocity = spawnPoint.forward * spellSpeed;
        }
    }
}
