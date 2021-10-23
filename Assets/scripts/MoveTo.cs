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

    [SerializeField] public string attack1, attack2, attack3, idle, walk;

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


        if (!playerIsInSight && !playerInAttackRange) 
        {
            anim.Play(idle);

        }
        if (playerIsInSight && !playerInAttackRange) { ChasePlayer(); }
        if (playerIsInSight && playerInAttackRange) { AttackPlayer(); }


        

    }

    void ChasePlayer()
    {
        agent.SetDestination(goal.position);
        anim.Play(walk);

    }
    void AttackPlayer() 
    {
        agent.SetDestination(transform.position);

        transform.LookAt(goal);

        if (!hasAttacked)
        {
            Attack_Type();

            if (Attack_Type() == 0) { Attack_One(); }
            if (Attack_Type() == 1) { Attack_Two(); }
            else 
            {
                Attack_Three();


            }

        }
    }

    void ResetAttack() { hasAttacked = false; }

    public int Attack_Type() {

      return  Random.Range(0, 3);
    }

    void Attack_One() { 

        anim.Play(attack1);

        var health = player.GetComponent<Health>();

        var attackl = anim.GetCurrentAnimatorStateInfo(0).length;

        Invoke(nameof(ResetAttack), (attackl / 2));

        health.Damage(1f);

        Invoke(nameof(ResetAttack), (attackl / 2) + TimeBetweenAttacks);
        hasAttacked = true;

    }

    void Attack_Two()
    {

        anim.Play(attack2);

        var health = player.GetComponent<Health>();

        var attackl = anim.GetCurrentAnimatorStateInfo(0).length;

        Invoke(nameof(ResetAttack), (attackl / 2));

        health.Damage(1f);
        hasAttacked = true;

        Invoke(nameof(ResetAttack), (attackl / 2) + TimeBetweenAttacks);

    }

    void Attack_Three()
    {

        anim.Play(attack3);

        var health = player.GetComponent<Health>();

        var attackl = anim.GetCurrentAnimatorStateInfo(0).length;

        Invoke(nameof(ResetAttack), (attackl / 2));

        health.Damage(1f);
        hasAttacked = true;

        Invoke(nameof(ResetAttack), (attackl / 2) + TimeBetweenAttacks);

    }

}
