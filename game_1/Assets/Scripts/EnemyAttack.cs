using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;

    Animator anim;
    GameObject player;
    public PlayerHealth playerHealth;
    bool playerInRange;
    float timer;

	void Awake /*Start*/ ()
    {
        player = GameObject.FindGameObjectWithTag("Player"); // не ищет?
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        ////anim = GetComponent<Animator>();
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
	}

    void Update ()
    {

        //player = GameObject.FindGameObjectWithTag("Player"); // не ищет?
        //playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        //anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();

        timer += Time.deltaTime;

        if (timer >= timeBetweenAttacks && playerInRange)
        {
            //Debug.Log("attac in", gameObject);

            Attack();
        }

        if (playerHealth.currentHealth <= 0)
        {
           // Debug.Log("DEAD");
            anim.SetTrigger("PlayerDead");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("trigger enemy in");
            playerInRange = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("trigger enemy out");
            playerInRange = false;
        }
    }

    void Attack()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        if (playerHealth.currentHealth == 100)
            Debug.Log("current3 = 100");
        timer = 0f;
        if (playerHealth.currentHealth > 0)
        {
            //Debug.Log("!!!attac in", gameObject);
            playerHealth.TakeDamage(attackDamage);
        }
    }
}
