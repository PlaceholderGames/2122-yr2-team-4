using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Opsive.UltimateCharacterController.Traits;

public class Attacking : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;
    public GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AttackPlayer()
    {

        anim.SetTrigger("Attack");

        var health = player.GetComponent<Health>();
        health.Damage(0.1f);


    }
}
