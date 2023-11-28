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

            if (other.CompareTag("Player"))
            {
                transform.LookAt(user);

                enemy.destination = user.position;
        }
        else
        {
            EnemyAnimator.SetBool("stand", true);
        }
        
        
      
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            userDetect = true;
            EnemyAnimator.SetBool("punch", true); // Activa la animacin de golpear
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        // Verifica si la colisión fue con un objeto que tiene un BoxCollider
        if (collision.gameObject.GetComponent<BoxCollider>() != null)
        {
            EnemyAnimator.SetBool("dead", true);
            CountEnemy.countEnemy += 1;
            Invoke("WaitAndDestroy",5f);
            
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

 void WaitAndDestroy()
    {
       
       Destroy(gameObject,5f);
        
    }
}