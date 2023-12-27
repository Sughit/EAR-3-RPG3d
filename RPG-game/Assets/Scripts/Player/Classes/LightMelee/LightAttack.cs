using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAttack : MonoBehaviour
{
    [Header("Dodge Stuff")]
    public bool canDodge = true;
    public float dodgeDistance = 2f;
    public bool canAttackDodge;
    public float dodgeDamage = 1;
    public float dodgeTime = .5f;
    public float dodgeCoolDown = 3;
    public float dodgeSpeed = 5;
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
        if(Input.GetKey(KeyCode.Space) && canDodge)
        {
            Debug.Log("Dodge");
            StartCoroutine(Dodge());
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

    IEnumerator Dodge()
    {
        canDodge = false;
        canAttack = false;
        anim.SetBool("dodge", true);
        
        float startTime = Time.time;
        Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        while(Time.time < startTime + dodgeTime)
        {
            transform.Translate(dir * dodgeTime * dodgeSpeed);

            yield return null;
        }

        yield return new WaitForSeconds(dodgeTime);
        anim.SetBool("dodge", false);
        if(canAttackDodge) Debug.Log("Attack dodge");
        yield return null;
        canAttack = true;
        yield return new WaitForSeconds(dodgeCoolDown);
        canDodge = true;
    }
}
