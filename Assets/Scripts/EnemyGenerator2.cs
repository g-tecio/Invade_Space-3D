using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator2 : MonoBehaviour
{
    public GameObject[] enemies;
    


    // Start is called before the first frame update
    void Start()
    {

        Invoke("CreateEnemy", Random.Range(8, 10));


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CreateEnemy()
    {
        var nube=Instantiate((enemies[Random.Range(0, enemies.Length - 1)]), transform.position, Quaternion.identity);
        Destroy(nube, 20);
        Invoke("CreateEnemy", Random.Range(8, 10));
    }


    void OnDisable()
    {
        CancelInvoke("CreateEnemy");

    }

    void OnEnable()
    {
        Invoke("CreateEnemy", Random.Range(2, 10));

    }

    
}
