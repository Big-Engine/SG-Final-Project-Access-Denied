using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int health;

    public AudioSource hitSoundFX;

    public void OnTriggerEnter2D(Collider2D collision)//needs testing
    {
        if (collision.tag == "Player_Bullet")
        {
            Debug.Log("Enemy hit");
            health--;
            hitSoundFX.Play();
            if (health <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
