using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Collisions : MonoBehaviour
{
    public int playerHealth = 3;
    public int maxHealth;

    private void Start()
    {
        maxHealth = playerHealth;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            int magnitude = 1500; // Knock back force

            Vector2 force = transform.position - other.transform.position;

            force.Normalize();
            GetComponent<Rigidbody2D>().AddForce(force * magnitude);

            playerHealth--;
            CheckIfDead();
        }

        if(other.tag == "Health")
        {
            if(maxHealth != playerHealth)
            {
                playerHealth++;
                Destroy(other.gameObject);
            }
        }
    }

    void CheckIfDead()
    {
        if (playerHealth <= 0)
        {
            //player dies
            //change scene, animations, etc.
            Destroy(gameObject);
        }
    }
}


