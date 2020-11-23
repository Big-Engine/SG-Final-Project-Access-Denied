using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;

    public void Start()
    {
        health = 3;
    }

    public void OnTriggerEnter2D(Collider2D collision)//needs testing
    {
        if (collision.tag == "bullet")
        {
            health--;
            Destroy(collision.gameObject);
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
