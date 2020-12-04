using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elemental_Manager : MonoBehaviour
{
    [SerializeField] List<GameObject> elementalPickUps = new List<GameObject>();

    [HideInInspector] public bool elementalOff = false;

    private float timer = 3;
    // Update is called once per frame
    void Update()
    {
        if (elementalOff)
        {
            if(timer <= 0)
            {
                for (int i = 0; i < elementalPickUps.Count; i++)
                {
                    elementalPickUps[i].SetActive(true);
                }
                elementalOff = false;
                timer = 3;
            }
            else
            {
                timer -= Time.deltaTime
;            }
        }
    }
}
