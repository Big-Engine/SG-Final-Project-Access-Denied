using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Collisions : MonoBehaviour
{
    public int playerHealth = 3;
    public int maxHealth;

    public Text healthText;

    public AudioSource hurtSoundFX;
    public AudioSource healthSoundFX;
    public AudioSource pickUpSoundFX;

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
            hurtSoundFX.Play();
            CheckIfDead();
        }

        if(other.tag == "Health")
        {
            if(maxHealth != playerHealth)
            {
                playerHealth++;
                UpdateHP();
                healthSoundFX.Play();
                Destroy(other.gameObject);
            }
        }

        if(other.tag == "Enemy_Bullet")
        {

            int magnitude = 500; // Knock back force

            Vector2 force = transform.position - other.transform.position;

            force.Normalize();
            GetComponent<Rigidbody2D>().AddForce(force * magnitude);

            Destroy(other.gameObject);

            playerHealth--;
            UpdateHP();
            hurtSoundFX.Play();
            CheckIfDead();
        }

        if(other.tag == "PickUp")//element pick up
        {
            pickUpSoundFX.Play();
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


