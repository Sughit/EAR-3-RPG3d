using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyAttack : MonoBehaviour
{
    [Header("Heavy Attack")]
    public float heavyDamage = 3;
    public float timeToHeavyAttack = 3;
    public Transform heavyAttackPoint;
    public float heavyAttackRange = 2;
    float startTimer;
    float endTimer;
    [Header("Normal Attack")]
    public float damage = 2;
    public float attackRate = 1;
    float currentAttackRate;
    public bool canAttack = true;
    public Transform attackPoint;
    public float attackRange=.7f;
    bool isAttacking;
    public bool inRangeOfUtilities = false;
    [Header("Particles for Heavy Attack")]
    public static bool heavy;
    public GameObject heavyAttackParticle;
    ParticleSystem heavyAttackPs;
    bool heavyAttackColorChange=true;
    Coroutine heavyAttackParticleCoroutine;

    void Awake()
    {
        heavyAttackPs = heavyAttackParticle.GetComponent<ParticleSystem>();
        startTimer = 0;
        endTimer = 0;
    }

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

        if(Input.GetMouseButtonDown(1))
        {
            heavyAttackParticle.SetActive(true);
            //resetam emisia
            var emission = heavyAttackPs.emission;
            emission.rateOverTime = 1;
            //resetam cronometrul
            startTimer = Time.time;
            //incepem coroutina de schimbat culoarea dupa "timeToHeavyAttack" seconds
            StopCoroutine(ParticleColorSet());
            heavyAttackParticleCoroutine = StartCoroutine(ParticleColorSet());
            heavyAttackColorChange=true;
        }

        if(Input.GetMouseButton(1))
        {
            if(endTimer - startTimer <= timeToHeavyAttack && heavyAttackPs.emission.rateOverTime.constant <= 1000) 
            {
                var emission = heavyAttackPs.emission;
                emission.rateOverTime = new ParticleSystem.MinMaxCurve(1, emission.rateOverTime.constant + 5);
            }
        }

        if(Input.GetMouseButtonUp(1))
        {
            endTimer = Time.time;
            if((endTimer - startTimer) <= timeToHeavyAttack)
            {
                //opreste coroutina care seteaza culoarea 
                heavyAttackColorChange=false;
                StopCoroutine(ParticleColorSet());
                //reseteaza culoarea
                var main = heavyAttackPs.main;
                main.startColor = new Color(255, 255, 255, 255);
                //reseteaza emisia
                var emission = heavyAttackPs.emission;
                emission.rateOverTime = 1;
                heavyAttackParticle.SetActive(false);
            }
        }

        if((endTimer - startTimer) > timeToHeavyAttack && canAttack)
        {
            Heavy();
            startTimer = 0;
            endTimer = 0;
            if(heavyAttackParticleCoroutine == null) heavyAttackColorChange=true;
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

    void Heavy()
    {
        Debug.Log("Heavy attack");
        ShakeCamera.shake = true;
        //reseteaza culoarea
        var main = heavyAttackPs.main;
        main.startColor = new Color(255, 255, 255, 255);
        //reseteaza emisia
        var emission = heavyAttackPs.emission;
        emission.rateOverTime = 1;
        heavyAttackParticle.SetActive(false);
        foreach(Collider other in Physics.OverlapSphere(heavyAttackPoint.position, heavyAttackRange))
        {
            if(other.gameObject.GetComponent<EnemyHealth>()) other.gameObject.GetComponent<EnemyHealth>().TakeDamage(heavyDamage, this.gameObject);
        }

    }

    IEnumerator ParticleColorSet()
    {
        yield return new WaitForSeconds(timeToHeavyAttack);
        if(heavyAttackColorChange)
        {
            var main = heavyAttackPs.main;
            main.startColor = new Color(135, 0, 115, 255);
        }    
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(heavyAttackPoint.position, heavyAttackRange);
    }
}
