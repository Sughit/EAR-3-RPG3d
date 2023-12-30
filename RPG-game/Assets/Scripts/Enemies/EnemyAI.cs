using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject player;
    public LayerMask whatIsGround, whatIsPlayer;

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
    public bool playerInSightRange, playerInAttackRange;

    void Awake()
    {
        player = GameObject.FindWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if(player == null) player = GameObject.FindWithTag("Player");

        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if(!playerInSightRange && !playerInAttackRange) Patroling();
        if(playerInSightRange && !playerInAttackRange) ChasePlayer();
        if(playerInSightRange && playerInAttackRange) Attack();
    }

    void Patroling()
    {
        if(!walkPointSet) SearchWalkPoint();

        if(walkPointSet) agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Am ajuns la walkPoint
        if(distanceToWalkPoint.magnitude < 1f) walkPointSet=false;
    }

    void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomx = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomx, transform.position.y, transform.position.z + randomZ);

        if(Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    void ChasePlayer()
    {
        agent.SetDestination(player.transform.position);
    }

    void Attack()
    {
        agent.SetDestination(transform.position);

        transform.LookAt(player.transform);

        if(!attacked) 
        {
            attacked = true;
            Invoke(nameof(ResetAttack), attackRate);
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
