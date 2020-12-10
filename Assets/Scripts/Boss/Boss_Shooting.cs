using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Shooting : MonoBehaviour
{
    [SerializeField] GameObject bossBullet = null;
    float timer = 1f;

    // Start is called before the first frame update
    void Update()
    {
        if(timer <= 0)
        {
            Instantiate(bossBullet, transform.position, Quaternion.identity);
            timer = 1f;
        }
        else
        {
            timer -= Time.deltaTime;
        }
       
    }

}
