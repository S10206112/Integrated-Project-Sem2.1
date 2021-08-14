using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RangedEnemy : MonoBehaviour
{
    public NavMeshAgent agent;
    
    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    public float SimpleEnemyHealth;

    //Patrolling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;

    //States   
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        //define what is player
        player = GameObject.Find("Player").transform;
        //define the navmesh agent
        agent = GetComponent<NavMeshAgent>();

    }

    private void Update()
    {
        //checking the sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        
        //trigger conditions for the enemy to do the following actions
        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInSightRange && playerInAttackRange) AttackPlayer();
    }

    private void Patroling()
    {
        //if no walkpoint yet, then create one
        if (!walkPointSet) SearchWalkPoint();

        //go to walkpoint if set
        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        //calculating the random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange );
        float randomX = Random.Range(-walkPointRange, walkPointRange );

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;


    }
    private void ChasePlayer()
    { 
        //follow player
        agent.SetDestination(player.position);
    }
    private void AttackPlayer()
    {
        //enemy doesnt move
        agent.SetDestination(transform.position); 
        //faces player
        transform.LookAt(player);
        
        if (!alreadyAttacked)
        {
            //shooting attack
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 8f, ForceMode.Impulse);


            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        //reset attack
        alreadyAttacked = false;
    }
    //Used in another script
    public void TakeDamage(int damage)
    {
        SimpleEnemyHealth -= damage;

        
    }
}
