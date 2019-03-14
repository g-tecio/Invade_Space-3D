using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{

    public float velocity = 1F;
    private int randomSpot;
    private float waitTime;
    public float startWaitTime;
    public Transform[] Targets;

    void Start()

    {
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, Targets.Length);
    }

   

    void Update()
    {
        moveEnemy();
        

    }


    void moveEnemy()
    {
        transform.position = Vector2.MoveTowards(transform.position, Targets[randomSpot].position, velocity * Time.deltaTime);
        if (Vector2.Distance(transform.position, Targets[randomSpot].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, Targets.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

}
