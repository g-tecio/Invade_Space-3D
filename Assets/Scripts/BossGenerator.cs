using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGenerator : MonoBehaviour
{
    
    public GameObject Boss,BossNave, Bar;
    float current, previous;
    public bool alien = true, nave=true;


    // Start is called before the first frame update
    void Start()
    {

        


    }

    // Update is called once per frame
    void Update()
    {
        current = HighScore.cont;
        var x = current - previous;
        
        if (x >= 1000 && alien==true)
        {
            previous = current;
            CreateBoss();
            alien = false;
            nave = false;
            Bar.SetActive(true);
            print("esta adentro en alien");
        }
        else if(x >= 1000  && nave==false)
        {
            previous = current;
            CreateBossNave();
            print("esta adentro en nave");
            nave = true;
            Bar.SetActive(true);
        }

    }


    void CreateBoss()
    {

        Instantiate(Boss, transform.position, Quaternion.identity);
        
    }
    void CreateBossNave()
    {
        Instantiate(BossNave, transform.position, Quaternion.identity);
    }
}
