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
        if (enemyRenderer.flipX)
        {
            firePoint.position = rightPosTransform.position;

            hit = Physics2D.Raycast(transform.position, Vector2.right, 5f);

            if (hit.collider != null)
            {
                if (hit.collider.tag == "Player")
                {
                    Instantiate(bulletPrefab, firePoint.position, Quaternion.identity, transform);
                }
            }
        }
        else
        {
            firePoint.position = leftPosTransform.position;

            hit = Physics2D.Raycast(transform.position, Vector2.left, 5f);

            if(hit.collider != null)
            {
                if (hit.collider.tag == "Player")
                {
                    Instantiate(bulletPrefab, firePoint.position, Quaternion.identity, transform);
                }
            }
        }
    }
}
