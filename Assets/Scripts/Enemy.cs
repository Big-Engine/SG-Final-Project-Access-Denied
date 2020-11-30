using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int health;

    public void Start()
    {
        health = 2;
    }

    public void OnTriggerEnter2D(Collider2D collision)//needs testing
    {
        if (collision.tag == "Player_Bullet")
        {
            Debug.Log("Enemy hit");
            health--;
            Destroy(collision.gameObject);
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
