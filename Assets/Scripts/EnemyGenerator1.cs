﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator1 : MonoBehaviour
{
    public GameObject[] enemies;
    


    // Start is called before the first frame update
    void Start()
    {

        Invoke("CreateEnemy", Random.Range(2, 10));


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CreateEnemy()
    {
        Instantiate((enemies[Random.Range(0, enemies.Length - 1)]),transform.position, Quaternion.Euler(0, -90, 0));
        Invoke("CreateEnemy", Random.Range(2, 6));
    }
}
    
