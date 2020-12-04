using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Rigidbody2D bulletRB = null;
    [SerializeField] float bulletSpeed = 0;
    [SerializeField] float selfDestructTimer = 0 ;
    private float animationTimer = 0.2f;

    private Player_Shooting playerShooting = null;

    // Start is called before the first frame update
    private void Start()
    {
        gameObject.GetComponent<Animator>().enabled = false;
        if(transform.root.tag == "Enemy")
        {
            gameObject.tag = "Enemy_Bullet";

            selfDestructTimer = transform.parent.GetComponent<Enemy_Shooting>().bulletDestroyTimer;

            if (transform.root.GetComponent<SpriteRenderer>().flipX)
            {
                bulletRB.AddForce(Vector2.right * bulletSpeed);
            }
            else
            {
                bulletRB.AddForce(Vector2.left * bulletSpeed);
            }
        }
        
        if(transform.root.tag == "Player")
        {

            playerShooting = transform.root.GetComponent<Player_Shooting>();

            gameObject.tag = "Player_Bullet";

            selfDestructTimer = transform.root.GetComponent<Player_Shooting>().bulletDestroyTimer;

            if (transform.root.GetComponent<SpriteRenderer>().flipX)
            {
                bulletRB.AddForce(Vector2.left * bulletSpeed);
            }
            else
            {
                bulletRB.AddForce(Vector2.right * bulletSpeed);
            }

            ChangeColor();
        }
    }

    private void Update()
    {
        if(selfDestructTimer <= 0)
        {
            DestroyBullet();
        }
        else
        {
            selfDestructTimer -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject != transform.root.gameObject)
        {
            if(collision.gameObject.tag != "PickUp")
            {
                if(collision.gameObject.tag != "Player_Bullet")
                {
                    DestroyBullet();
                }
            }
        }
    }

    private void ChangeColor()
    {
        if (playerShooting.fireBullets)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }

        if (playerShooting.waterBullets)
        {
            GetComponent<SpriteRenderer>().color = Color.blue;
        }

        if (playerShooting.poisonBullets)
        {
            GetComponent<SpriteRenderer>().color = Color.green;
        }
    }

    private void DestroyBullet()
    {
        bulletRB.velocity = new Vector2(0, 0);
        gameObject.GetComponent<Animator>().enabled = true;

        if (animationTimer <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            animationTimer -= Time.deltaTime;
        }
    }

}
