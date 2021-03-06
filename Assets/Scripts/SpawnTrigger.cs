﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
    public List<GameObject> Enemies = new List<GameObject>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            for(int i = 0; i < Enemies.Count; i++)
            {
                Enemies[i].SetActive(true);
            }
            Destroy(gameObject);
        }
    }
}

