using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Initiate : MonoBehaviour
{
    [SerializeField] GameObject boss = null;

    private void Start()
    {
        boss.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            boss.SetActive(true);
            Destroy(gameObject);
        }
    }
}
