using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroundAI : MonoBehaviour
{
    public GameObject position1;
    public GameObject position2;

    public float speed;
    Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        target = position1.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MoveToTarget();
    }

    void MoveToTarget()
    {


        target.z = transform.position.z;
        transform.position = Vector2.MoveTowards(transform.position, target, speed);
        if (transform.position == target)
        {
            if (Vector2.Distance(transform.position, position1.transform.position)< 1)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
                target = position2.transform.position;
            }
            else if(Vector2.Distance(transform.position, position2.transform.position) < 1)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
                target = position1.transform.position;
            }
        }
    }
}
