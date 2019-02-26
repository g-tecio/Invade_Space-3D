using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public GameObject bullet;
    public Transform shotPoint;
    private float timeBtwShots;
    public float startTimeBtwShots = 0.1f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Disparar en direccion y calcular cada cuando se puede ahcer
        if (timeBtwShots <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(bullet, shotPoint.position, Quaternion.identity);
                timeBtwShots = startTimeBtwShots;
            }
            

        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }

    }
}
