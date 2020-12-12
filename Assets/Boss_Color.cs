using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Color : MonoBehaviour
{
    [SerializeField] SpriteRenderer bossRenderer = null;

    private float timer = 0;
    private Color red = Color.red;
    private Color blue = Color.blue;
    private Color green = Color.green;

    private void Start()
    {
        timer = Random.Range(2, 5);
        ChangeColor();
    }
    void Update()
    {
        if(timer <= 0)
        {
            ChangeColor();
            timer = Random.Range(2, 5);
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    private void ChangeColor()
    {
        int random = Random.Range(0, 3);

        if(random == 0)
        {
            bossRenderer.color = red;
        }
        else if(random == 1)
        {
            bossRenderer.color = blue;
        }
        else
        {
            bossRenderer.color = green;
        }
    }
}
