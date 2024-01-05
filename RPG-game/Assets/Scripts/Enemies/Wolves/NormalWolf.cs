using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NormalWolf : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject target;
    public LayerMask whatIsGround, whatIsTarget;

    //Patrulare
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

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
            target = targets[Random.Range(0, targets.Count)].gameObject;
            isTarget = true;
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
        agent.speed = 1.5f;
        if(!walkPointSet) SearchWalkPoint();

        if(walkPointSet) agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Am ajuns la walkPoint
        if(distanceToWalkPoint.magnitude < 1f) 
        {   
            Invoke("SetWalkPointSetFalse", 2f);
        }
    }

    void SetWalkPointSetFalse()
    {
        walkPointSet=false;
    }

    void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomx = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomx, transform.position.y, transform.position.z + randomZ);

        if(Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    void ChaseTarget()
    {
        agent.speed = 3.5f;
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
