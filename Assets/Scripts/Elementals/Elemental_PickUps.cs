using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elemental_PickUps : MonoBehaviour
{
    [SerializeField] string element = "";

    private void Start()
    {
        ChooseColor(element);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            transform.parent.GetComponent<Elemental_Manager>().elementalOff = true;
            gameObject.SetActive(false);
        }
    }

    private void ChooseColor(string elementType)
    {
        if (elementType == "Fire")
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else if (elementType == "Water")
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        }
        else if (elementType == "Poison")
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        }
        else
        {
            Debug.LogError("Invalid pick up element type");
        }
    }
}
