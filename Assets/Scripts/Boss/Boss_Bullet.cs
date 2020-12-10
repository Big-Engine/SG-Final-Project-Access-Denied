using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Bullet : MonoBehaviour
{
    [SerializeField] GameObject player = null;
    [SerializeField] Rigidbody2D bulletRB = null;

    float timer = 2f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        Vector3 angleBetween = (transform.position - player.transform.position).normalized;

        float angle = Mathf.Atan2(angleBetween.y, angleBetween.x) * Mathf.Rad2Deg + 180;

        transform.rotation = Quaternion.Euler(0, 0, angle);

        bulletRB.AddForce(new Vector2(-angleBetween.x, -angleBetween.y) * 800);
    }

    // Update is called once per frame
    void Update()
    {
        if(timer <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
