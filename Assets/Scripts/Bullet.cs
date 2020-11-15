using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Rigidbody2D bulletRB = null;
    [SerializeField] float bulletSpeed = 0;
    // Start is called before the first frame update
    void Awake()
    {
        if (!transform.parent.GetComponent<SpriteRenderer>().flipX)
        {
            bulletRB.AddForce(Vector2.right * bulletSpeed);
        }
        else
        {
            bulletRB.AddForce(Vector2.left * bulletSpeed);
        }
    }

}
