using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossScript : MonoBehaviour
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
   

    //States   
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        //define player component
        player = GameObject.Find("Player").transform;
        //define agent
        agent = GetComponent<NavMeshAgent>();

    }

    private void Update()
    {
        //checking the sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        //trigger the action based on the conditions (whether to patrol, chase or attack the player)
        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInSightRange && playerInAttackRange) AttackPlayer();
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

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

        //walking points for the AI
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        //if the distance in front of the player is a ground, AI can walk
        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;


    }
    //chase player function
    private void ChasePlayer()
    { 
        //nav agent follows the player
        agent.SetDestination(player.position);
    }
    private void AttackPlayer()
    {
        //enemy doesnt move
        agent.SetDestination(transform.position); 

        //enemy looks at player
        transform.LookAt(player);
        
        // if enemy already attacks the player, gives it a attack cooldown
        if (!alreadyAttacked)
        {
            
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    //reset the enemy attack
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }


    //using this in another script (not active in this script)
    public void TakeDamage(int damage)
    {
        SimpleEnemyHealth -= damage;

        
    }
}