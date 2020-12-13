using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Collisions : MonoBehaviour
{
    //health variables
    public int playerHealth;
    public int maxHealth;

    //health UI
    public Text healthText;

    //sound effects
    public AudioSource hurtSoundFX;
    public AudioSource healthSoundFX;
    public AudioSource pickUpSoundFX;

    //music
    public AudioSource music1;

    private void Start()
    {
        UpdateHP();
        maxHealth = playerHealth;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy" || other.tag == "Boss")
        {
            TakeDamage(1250, other);
        }

        if(other.tag == "Health")
        {
            if(maxHealth != playerHealth)
            {
                playerHealth = maxHealth;
                UpdateHP();
                healthSoundFX.Play();
                Destroy(other.gameObject);
            }
        }

        if(other.tag == "Enemy_Bullet")
        {

            TakeDamage(500, other);
        }

        if(other.tag == "PickUp")//element pick up
        {
            pickUpSoundFX.Play();
        }

        if(other.tag == "WinGame")//Win the game when picked up
        {
            SceneManager.LoadScene("Win");
        }

        if(other.tag == "Teleporter")
        {
            music1.Pause();
        }
    }

    void CheckIfDead()
    {
        if (playerHealth <= 0)
        {
            SceneManager.LoadScene("Lose");
            //Destroy(gameObject);
        }
    }

    void UpdateHP()
    {
        healthText.text = "Health: " + playerHealth.ToString();
    }

    private void TakeDamage(int knockBackForce, Collider2D other)
    {
        int magnitude = knockBackForce; // Knock back force

        Vector2 angle = transform.position - other.transform.position;

        angle.Normalize();
        GetComponent<Rigidbody2D>().AddForce(angle * magnitude);

        playerHealth--;
        UpdateHP();
        hurtSoundFX.Play();
        CheckIfDead();
    }
}


