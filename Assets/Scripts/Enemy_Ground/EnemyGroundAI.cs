using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroundAI : MonoBehaviour
{
    [SerializeField] Vector2 position1;
    [SerializeField] Vector2 position2;

    public float speed;
    Vector2 target;

    // Start is called before the first frame update
    void Start()
    {
        target = position1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveToTarget();
    }

    void MoveToTarget()
    {

        transform.position = Vector2.MoveTowards(transform.position, target, speed);

        if (Vector2.Distance(transform.position, target) < 1f)
        {
            if (target == position1)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
                target = position2;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
                target = position1;
            }
        }
    }
}
