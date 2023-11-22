using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    private bool userDetect;
    public Transform user;
    private NavMeshAgent enemy;
    // lo que se recomienda es dejarlo en privado
    public Animator EnemyAnimator;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player")) {
            transform.LookAt(user);
            userDetect = true;
            enemy.destination = user.position;
        }
        else { userDetect = false; }
      
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            userDetect = true;
            EnemyAnimator.SetBool("punch", true); // Activa la animacin de golpear
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            userDetect = true;
            EnemyAnimator.SetBool("punch", false); // Desactiva la animacin de golpear al salir de la colisin
        }
    }

    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
        EnemyAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        
    }
}