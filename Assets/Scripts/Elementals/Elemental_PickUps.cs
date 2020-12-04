using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elemental_PickUps : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            transform.root.GetComponent<Elemental_Manager>().elementalOff = true;
            gameObject.SetActive(false);
        }
    }
}
