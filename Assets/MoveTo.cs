using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{
    public Transform goal;
    public Animator anim;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;

        float dist = Vector3.Distance(goal.position, transform.position);

        if (agent.speed > 0) { anim.Play("WalkForward_RM"); }

        if (dist < 3) { agent.isStopped = true; }
    }
}
