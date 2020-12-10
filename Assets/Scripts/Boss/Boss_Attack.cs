using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Attack : MonoBehaviour
{
    [SerializeField] EnemyAI enemyAI = null;
    [SerializeField] Boss_Shooting boss_Shooting = null;

    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        timer = Random.Range(10, 15);
        boss_Shooting.enabled = false;
        enemyAI.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer <= 0)
        {
            int randomAttack = Random.Range(0, 2);
            if(randomAttack == 0)
            {
                enemyAI.enabled = true;
                boss_Shooting.enabled = false;
            }
            else
            {
                enemyAI.enabled = false;
                boss_Shooting.enabled = true;
            }
            timer = Random.Range(10, 15);
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
