using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaseAI : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;


    public Animator anim;

    public float maxHetalth;
    public float currentHealth;
    public float speed = 4f;


    void Start()
    {
        currentHealth = maxHetalth;

        anim = gameObject.GetComponent<Animator>();
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {   

        if (currentHealth == 0) {

            anim.Play("Death");

            //GameObject.Destroy(Boss);


        }
    }

}
