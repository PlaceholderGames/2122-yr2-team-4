using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Opsive.UltimateCharacterController.Traits;

public class MoveTo : MonoBehaviour
{
    public Transform goal;
    public Animator anim;
    public NavMeshAgent agent;
    [SerializeField] protected GameObject player;
    [SerializeField] public float attackRange;

    public LayerMask IsPlayer;

    [SerializeField] public float TimeBetweenAttacks;
    [SerializeField] public float SightRange;

    public bool hasAttacked;
    public bool playerIsInSight;
    public bool playerInAttackRange;

    void Start()
    {

    }
    private void Awake()
    {
        //finding player on map
        goal = GameObject.Find("Nolan").transform;
        //initializing navmesh agent
        agent = GetComponent<NavMeshAgent>();

    }

    void Update()
    {
        //checking is the player in range
        playerIsInSight = Physics.CheckSphere(transform.position, SightRange, IsPlayer);
        //checking is player in attack range
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, IsPlayer);

        //float dist = Vector3.Distance(goal.position, transform.position);

        //behavior(dist);

        if (!playerIsInSight && !playerInAttackRange) 
        {
            anim.Play("IdleLookAround");

        }
        if (playerIsInSight && !playerInAttackRange) { ChasePlayer(); }
        if (playerIsInSight && playerInAttackRange) { AttackPlayer(); }

    }

    void ChasePlayer()
    {
        agent.SetDestination(goal.position);
        anim.Play("WalkForward");

    }
    void AttackPlayer() 
    {
        agent.SetDestination(transform.position);

        transform.LookAt(goal);

        if (!hasAttacked)
        {
            anim.Play("LeftHandAttack");

            var health = player.GetComponent<Health>();
            health.Damage(1f);

            hasAttacked = true;
            Invoke(nameof(ResetAttack), TimeBetweenAttacks);
        }
    }

    void ResetAttack() { hasAttacked = false; }


}
