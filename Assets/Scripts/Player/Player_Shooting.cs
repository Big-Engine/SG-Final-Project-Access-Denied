using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shooting : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab = null;

    [SerializeField] Rigidbody2D bulletRB = null;

    [SerializeField] float timeBetweenShots = 0;
    private float shootTimer = 0;

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

    private void Shoot()
    {
        Instantiate(bulletPrefab, transform.position, Quaternion.identity, transform);
    }
}
