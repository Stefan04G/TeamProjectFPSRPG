using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent enemy;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    //wandering

    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //attack

    public float attackInterval;
    bool attackedAlready;

    //states
    public float vision, range;
    public bool playerInVision, playerInRange;



    private void Awake()

    {
        player = GameObject.Find("soldier").transform;
        enemy = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        playerInVision = Physics.CheckSphere(transform.position, vision, whatIsPlayer);
        playerInRange = Physics.CheckSphere(transform.position, range, whatIsPlayer);

        if (!playerInVision && !playerInRange) Wandering();
        if (playerInVision && !playerInRange) Chase();
        if (playerInVision && playerInRange) Attack();
    }


    private void Wandering()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            enemy.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        //checking if random positon is on map
        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
        

    }

    private void Chase()
    { 
        enemy.SetDestination(player.position);
    }

    private void Attack()
    {
        //make sure enemy doesnt move
        enemy.SetDestination(transform.position);

        transform.LookAt(player);

        if (!attackedAlready)
        {
            attackedAlready = true;
            Invoke(nameof(AttackReset), attackInterval);
        }

    }

    private void AttackReset()
    {
        attackedAlready = false;
    }


}