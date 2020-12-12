using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] Transform target = null;

    [SerializeField] float smoothspeed = 0;
    [SerializeField] Vector3 offset = new Vector2();

    private void FixedUpdate()
    {
        Vector3 desiredPos = target.position + offset;
        Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothspeed);
        transform.position = smoothedPos;
    }
}
