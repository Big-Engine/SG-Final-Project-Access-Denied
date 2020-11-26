using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Shooting : MonoBehaviour
{
    [SerializeField] Transform playerTransform = null;

    [SerializeField] Transform bulletPrefab = null;

    [SerializeField] Transform firePoint = null;

    [SerializeField] SpriteRenderer enemyRenderer = null;

    RaycastHit2D hit;
    // Start is called before the first frame update
    void Start()
    {
        hit = Physics2D.Raycast(transform.position, Vector2.right);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (enemyRenderer.flipX)
        {
            hit = Physics2D.Raycast(transform.position, Vector2.right, 5f);

            if (hit.collider.tag == "Player")
            {
                Instantiate(bulletPrefab, firePoint.position, Quaternion.identity, transform);
            }
        }
        else
        {
            hit = Physics2D.Raycast(transform.position, Vector2.left, 5f);

            if (hit.collider.tag == "Player")
            {
                Instantiate(bulletPrefab, firePoint.position, Quaternion.identity, transform);
            }

        }
    }
}
