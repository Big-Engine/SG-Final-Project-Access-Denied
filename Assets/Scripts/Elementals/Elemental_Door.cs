using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elemental_Door : MonoBehaviour
{
    [SerializeField] string doorElement = "";
    private Color bulletColor;

    private void Start()
    {
        SelectElement(doorElement);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player_Bullet")
        {
            if(collision.gameObject.GetComponent<SpriteRenderer>().color == bulletColor)
            {
                Destroy(gameObject);
            }
        }
    }

    private void SelectElement(string element)
    {
        if(element == "Fire")
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            bulletColor = Color.red;
        }

        if (element == "Water")
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
            bulletColor = Color.blue;
        }

        if (element == "Poison")
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.green;
            bulletColor = Color.green;
        }
    }
}
