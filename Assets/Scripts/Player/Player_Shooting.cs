using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shooting : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab = null;

    [SerializeField] Rigidbody2D bulletRB = null;

    [SerializeField] float timeBetweenShots = 0;
    private float shootTimer = 0;

    [HideInInspector] public bool fireBullets = false;
    [HideInInspector] public bool waterBullets = false;
    [HideInInspector] public bool poisonBullets = false;

    public float bulletDestroyTimer = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(shootTimer <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                Shoot();
                shootTimer = timeBetweenShots;
            }
        }
        else
        {
            shootTimer -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "FirePickUp")
        {
            OnElementalCollision(true, false, false);
        }

        if (collision.gameObject.name == "WaterPickUp")
        {
            OnElementalCollision(false, true, false);
        }

        if (collision.gameObject.name == "PoisonPickUp")
        {
            OnElementalCollision(false, false, true);
        }
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, transform.position, Quaternion.identity, transform);
    }

    private void OnElementalCollision(bool toggleFire, bool toggleWater, bool togglePoison)
    {
        fireBullets = toggleFire;
        waterBullets = toggleWater;
        poisonBullets = togglePoison;
    }
}
