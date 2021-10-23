using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Opsive.UltimateCharacterController.Traits;
using Opsive.Shared.Events;

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

        anim.Play("LeftHandAttack");

        var health = player.GetComponent<Health>();

        var attackl = anim.GetCurrentAnimatorStateInfo(0).length;

        Invoke(nameof(ResetAttack), (attackl / 2));

        health.Damage(1f);
        hasAttacked = true;

        Invoke(nameof(ResetAttack), (attackl / 2) + TimeBetweenAttacks);

    }

    void Attack_Two()
    {

        anim.Play("2HitComboAttackForward_RM");

        var health = player.GetComponent<Health>();

        var attackl = anim.GetCurrentAnimatorStateInfo(0).length;

        Invoke(nameof(ResetAttack), (attackl / 2));

        health.Damage(1f);
        hasAttacked = true;

        Invoke(nameof(ResetAttack), (attackl / 2) + TimeBetweenAttacks);

    }

    void Attack_Three()
    {

        anim.Play("RightHandSmashAttack");

        var health = player.GetComponent<Health>();

        var attackl = anim.GetCurrentAnimatorStateInfo(0).length;

        Invoke(nameof(ResetAttack), (attackl / 2));

        health.Damage(1f);
        hasAttacked = true;

        Invoke(nameof(ResetAttack), (attackl / 2) + TimeBetweenAttacks);

    }

    void Death() {

        anim.Play("Death");

        var Death = anim.GetCurrentAnimatorStateInfo(0).length;

        this.enabled = false;

        Invoke(nameof(ResetAttack), Death);


    }

}
