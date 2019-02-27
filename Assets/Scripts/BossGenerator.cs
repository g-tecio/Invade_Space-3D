using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossGenerator : MonoBehaviour
{
    
    public GameObject Boss,BossNave, Bar;
    float current, previous;
    public bool alien = true, nave=true;
    
	public Scrollbar HealthBar;
	public float Health = 100;


    // Start is called before the first frame update
    void Start()
    {

        


    }

    // Update is called once per frame
    void Update()
    {
        current = HighScore.cont;
        var x = current - previous;
        
        if (x >= 100 && alien==true)
        {
            previous = current;
            CreateBoss();
            alien = false;
            nave = false;
            Bar.SetActive(true);
            


            print("esta adentro en alien");
        }
        else if(x >= 2000  && nave==false)
        {
            previous = current;
            CreateBossNave();
            print("esta adentro en nave");
            nave = true;
            Bar.SetActive(true);
        }
        if(Health==0){
            Bar.SetActive(false);
            Health = 100;
            HealthBar.size = Health / 100f;
        }
        

    }
    	public void Hit(float value)
	{
        Health -= value;
		HealthBar.size = Health / 100f;

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
