using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Shooting : MonoBehaviour
{
    [SerializeField] Transform leftPosTransform = null;

    [SerializeField] Transform rightPosTransform = null;

    [SerializeField] Transform playerTransform = null;

    [SerializeField] Transform bulletPrefab = null;

    [SerializeField] Transform firePoint = null;

    [SerializeField] SpriteRenderer enemyRenderer = null;

    [SerializeField] float timeBetweenShots = 0;

    private float shootingTimer = 0;

    public float bulletDestroyTimer = 0;

    RaycastHit2D hit;
    // Start is called before the first frame update
    void Start()
    {
        if (enemyRenderer == null)
        {
            enemyRenderer = transform.parent.root.GetComponent<SpriteRenderer>();
        }

        hit = Physics2D.Raycast(transform.position, Vector2.right);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void FixedUpdate()
    {
        if(shootingTimer <= 0)
        {
            if (enemyRenderer.flipX)
            {
                Shoot("Right");
            }
            else
            {
                Shoot("Left");
            }
            shootingTimer = timeBetweenShots;
        }
        else
        {
            shootingTimer -= Time.fixedDeltaTime;
        }
    }

    void Shoot(string leftOrRight)
    {
        if(leftOrRight == "Left")
        {
            firePoint.position = leftPosTransform.position;
            hit = Physics2D.Raycast(transform.position, Vector2.left, 5f);
        }
        else if (leftOrRight == "Right")
        {
            firePoint.position = rightPosTransform.position;
            hit = Physics2D.Raycast(transform.position, Vector2.right, 5f);
        }
        

        if (hit.collider != null)
        {
            if (hit.collider.tag == "Player")
            {
                Instantiate(bulletPrefab, firePoint.position, Quaternion.identity, transform);
            }
        }
    }
}
