﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Seeker))]
public class EnemyAI : MonoBehaviour
{
    public Transform target;
    public float updateRate = 2f;

    private Seeker seeker;
    private Rigidbody2D rb;

    //The calculated path
    public Path path;

    //AI speed per second
    public float speed = 300f;
    public ForceMode2D fMode;

    [HideInInspector] public bool pathIsEnded = false;

    //max distance from AI to waypoint
    public float nextWaypointDistance = 3;

    //current waypoint
    private int currentWaypoint = 0;

    private bool searchingForPlayer = false;

    private void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        if (target == null)
        {
            if(!searchingForPlayer)
            {
                searchingForPlayer = true;
                StartCoroutine(SearchForPlayer());
            }
            return;
        }

        //Start a new path to target position, return result to OnPathComplete
        seeker.StartPath(transform.position, target.position, OnPathComplete);

        StartCoroutine(UpdatePath());
    }

    IEnumerator SearchForPlayer()
    {
        GameObject sResult = GameObject.FindGameObjectWithTag("Player");
        if(sResult == null)
        {
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(SearchForPlayer());
        }
        else
        {
            target = sResult.transform;
            searchingForPlayer = false;
            StartCoroutine(UpdatePath());
            yield return false;
        }
    }

    IEnumerator UpdatePath()
    {
        if (target == null)
        {
            if (!searchingForPlayer)
            {
                searchingForPlayer = true;
                StartCoroutine(SearchForPlayer());
            }
            yield return false;
        }

        seeker.StartPath(transform.position, target.position, OnPathComplete);

        yield return new WaitForSeconds(1f / updateRate);
        StartCoroutine(UpdatePath());
    }

    public void OnPathComplete(Path p)
    {
        //Debug.Log("Path Error: " + p.error);
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    private void FixedUpdate()
    {
        if (target == null)
        {
            if (!searchingForPlayer)
            {
                searchingForPlayer = true;
                StartCoroutine(SearchForPlayer());
            }
            return;
        }

        if (target.position.x > transform.position.x)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (target.position.x < transform.position.x)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }

        if (path == null)
        {
            return;
        }

        if (currentWaypoint >= path.vectorPath.Count)
        {
            if (pathIsEnded)
            {
                return;
            }
            //Debug.Log("End of Path");
            pathIsEnded = true;
            return;
        }
        pathIsEnded = false;

        //Direction to next waypoint
        Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
        dir *= speed * Time.fixedDeltaTime;

        //Move the AI
        rb.AddForce(dir, fMode);

        float dist = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);

        if (dist < nextWaypointDistance)
        {
            currentWaypoint++;
            return;
        }
    }
}
