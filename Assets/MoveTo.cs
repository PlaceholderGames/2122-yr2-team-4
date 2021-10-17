using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Opsive.UltimateCharacterController.Traits;

public class MoveTo : MonoBehaviour
{
    public Transform goal;
    public Animator anim;
    [SerializeField]protected GameObject player;

    void Start()
    {


    }

    void FixedUpdate()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;

        float dist = Vector3.Distance(goal.position, transform.position);

        if (agent.speed > 0) { anim.Play("WalkForward_RM"); }

        if (dist >10 || dist < 25)
        {
            agent.speed = 0;
            anim.SetTrigger("Attack");

            var health = player.GetComponent<Health>();
            health.Damage(10);

        }
    }
}
