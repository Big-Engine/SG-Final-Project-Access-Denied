using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Rigidbody2D bulletRB = null;
    [SerializeField] float bulletSpeed = 0;
    [SerializeField] float selfDestructTimer = 0 ;

    // Start is called before the first frame update
    void Awake()
    {
        if (transform.root.GetComponent<SpriteRenderer>().flipX)
        {
            bulletRB.AddForce(Vector2.right * bulletSpeed);
        }
        else
        {
            bulletRB.AddForce(Vector2.left * bulletSpeed);
        }
    }

    private void Start()
    {
        if(transform.root.tag == "Enemy")
        {
            selfDestructTimer = transform.root.GetComponent<Enemy_Shooting>().bulletDestroyTimer;
        }
        
        if(transform.root.tag == "Player")
        {
            selfDestructTimer = transform.root.GetComponent<Player_Shooting>().bulletDestroyTimer;
        }
    }

    private void Update()
    {
        if(selfDestructTimer <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            selfDestructTimer -= Time.deltaTime;
        }
    }

}
