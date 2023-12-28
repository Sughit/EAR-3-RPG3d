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
    public float damage = 2;
    public float attackRate = 2;
    float currentAttackRate;
    public bool canAttack = true;

    Animator anim;

    void Start()
    {
        anim=GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Space) && canDash)
        {
            Debug.Log("Dash");
            StartCoroutine(Dash());
        }

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
    }

    void Attack()
    {
        Debug.Log("Attack");
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
}
