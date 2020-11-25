using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Shooting : MonoBehaviour
{
    [SerializeField] Transform playerTransform = null;

    [SerializeField] Transform bulletPrefab = null;

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
        if (gameObject.GetComponent<SpriteRenderer>().flipX)
        {
            hit = Physics2D.Raycast(transform.position, Vector2.right);

            if (hit.collider.name == "Player")
            {
                Instantiate(bulletPrefab, transform.position, Quaternion.identity, transform);
            }

            Debug.DrawRay(transform.position, Vector2.right, Color.red);
        }
        else
        {
            hit = Physics2D.Raycast(transform.position, Vector2.left);

            if(hit.collider.name == "Player")
            {
                Instantiate(bulletPrefab, transform.position, Quaternion.identity, transform);
            }

            Debug.DrawRay(transform.position, Vector2.left, Color.red);
        }
    }
}
