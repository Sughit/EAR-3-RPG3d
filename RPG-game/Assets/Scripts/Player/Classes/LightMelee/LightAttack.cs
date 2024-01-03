using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAttack : MonoBehaviour
{
    [Header("Dodge Stuff")]
    public bool canDash = true;
    public float dashForce = 2f;
    public bool canAttackDash;
    public float dashDamage = 1;
    public float dashCoolDown = 3;
    [Space]
    public float damage = 1;
    public float attackRate = 2;
    public float attackRange = 1;
    public Transform attackPoint;
    [SerializeField]
    float currentAttackRate;
    public bool canAttack = true;
    bool isAttacking;

    Animator anim;

    void Start()
    {
        anim=GetComponent<Animator>();
    }

    void Update()
    {
        if(GameObject.Find("GameManager").GetComponent<InGameMenu>().inGameMenuGO.activeSelf) canAttack=false;
        else canAttack=true;
        if(Input.GetKey(KeyCode.Space) && canDash)
        {
            Debug.Log("Dash");
            StartCoroutine(Dash());
            anim.SetTrigger("roll");
        }

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
            foreach(Collider other in Physics.OverlapSphere(attackPoint.position, attackRange))
            {
                if(other.gameObject.GetComponent<EnemyHealth>()) other.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage, this.gameObject);
            }
        }
    }

    IEnumerator Dash()
    {
        canDash = false;
        canAttack = false;
        GetComponent<Rigidbody>().AddForce(transform.forward * dashForce, ForceMode.Impulse);
        yield return null;
        canAttack = true;
        yield return new WaitForSeconds(dashCoolDown);
        canDash = true;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
