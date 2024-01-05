using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Dwarf : MonoBehaviour
{
    [HideInInspector]
    public NavMeshAgent agent;
    public GameObject target;
    public LayerMask whatIsGround, whatIsTarget;

    //Patrulare
    public bool walkPointSet;
    public bool anotherStone;
    public GameObject[] stones;
    public GameObject currentStone;
    GameObject oldStone;

    //Atac
    public float attackRate;
    public float damage;
    float currentAttackRate;
    bool attacked;

    //Stari
    public float sightRange, attackRange;
    public bool targetInSightRange, targetInAttackRange;
    bool isTarget;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void GetTarget()
    {
        List<Collider> targets = new List<Collider>();
        foreach(Collider other in Physics.OverlapSphere(transform.position, sightRange, whatIsTarget))
        {
            targets.Add(other);
        }
        if(targets.Count > 0)
        {
            target = targets[0].gameObject;
            isTarget = true;
        }
        else
        {
            target = null;
        }
    }

    void Update()
    {
        if(!isTarget) GetTarget();

        if(target != null)
        {
            targetInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsTarget);
            targetInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsTarget);

            if(!targetInSightRange && !targetInAttackRange) Patroling();
            if(targetInSightRange && !targetInAttackRange) ChaseTarget();
            if(targetInSightRange && targetInAttackRange) Attack();
        }
        else
        {
            Patroling();
            isTarget = false;
        }
    }

    void Patroling()
    {
        target = null;
        if(!walkPointSet) 
        {
            oldStone = currentStone;
            currentStone = stones[Random.Range(0, stones.Length)];
            agent.SetDestination(currentStone.transform.position);
            walkPointSet = true;
        }

        while(oldStone == currentStone)
        {
            currentStone = stones[Random.Range(0, stones.Length)];
        }

        agent.SetDestination(currentStone.transform.position);
        //pentru a reseta piatra, este scris in Rock
    }

    void SearchAnotherStone()
    {
        walkPointSet=false;
        Debug.Log("Another stone");
    }

    void ChaseTarget()
    {
        if(target != null) agent.SetDestination(target.transform.position);
    }

    void Attack()
    {
        try
        {
            agent.SetDestination(transform.position);

            transform.LookAt(target.transform);

            if(!attacked) 
            {
                attacked = true;
                Invoke(nameof(ResetAttack), attackRate);
                if(target.GetComponent<PlayerHealth>()) target.GetComponent<PlayerHealth>().TakeDamage(damage);
                if(target.GetComponent<EnemyHealth>()) target.GetComponent<EnemyHealth>().TakeDamage(damage, this.gameObject);
            }
        }
        catch
        {
            Patroling();
        }
    }

    void ResetAttack()
    {
        attacked = false;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
