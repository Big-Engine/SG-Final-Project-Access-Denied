using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int health;

    public AudioSource hitSoundFX;

    private void OnTriggerEnter2D(Collider2D collision)//needs testing
    {
        if(gameObject.tag == "Boss")
        {
            if (collision.tag == "Player_Bullet")
            {
                if(collision.GetComponent<SpriteRenderer>().color == gameObject.GetComponent<SpriteRenderer>().color)
                {
                    TakeDamage();
                    CheckHealth();
                }
            }
        }

        if(gameObject.tag == "Enemy")
        {
            if(collision.tag == "Player_Bullet")
            {
                TakeDamage();
                CheckHealth();
            }
        }
    }

    private void TakeDamage()
    {
        health--;
        hitSoundFX.Play();
    }

    private void CheckHealth()
    {
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
