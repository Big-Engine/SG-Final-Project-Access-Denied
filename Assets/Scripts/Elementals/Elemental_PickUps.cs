using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elemental_PickUps : MonoBehaviour
{
    [SerializeField] string element = "";

    private void Start()
    {
        if(element == "Fire")
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else if (element == "Water")
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        }
        else if(element == "Poison")
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        }
        else
        {
            Debug.LogError("Invalid pick up element type");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            transform.parent.GetComponent<Elemental_Manager>().elementalOff = true;
            gameObject.SetActive(false);
        }
    }
}
