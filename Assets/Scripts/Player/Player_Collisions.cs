using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Collisions : MonoBehaviour
{
    public int playerHealth = 3;
    public int maxHealth;

    public Text healthText;

    private void Start()
    {
        UpdateHP();
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
            UpdateHP();
            CheckIfDead();
        }

        if(other.tag == "Health")
        {
            if(maxHealth != playerHealth)
            {
                playerHealth++;
                UpdateHP();
                Destroy(other.gameObject);
            }
        }

        if(other.tag == "Enemy_Bullet")
        {
            Destroy(other.gameObject);

            int magnitude = 500; // Knock back force

            Vector2 force = transform.position - other.transform.position;

            force.Normalize();
            GetComponent<Rigidbody2D>().AddForce(force * magnitude);

            playerHealth--;
            UpdateHP();
            CheckIfDead();
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

    void UpdateHP()
    {
        healthText.text = "Health: " + playerHealth.ToString();
    }
}


