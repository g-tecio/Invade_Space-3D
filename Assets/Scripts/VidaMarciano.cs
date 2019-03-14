using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaMarciano : MonoBehaviour
{
    public BossGenerator boss;
    public GameObject explosionboss;
    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.Find("BossGenerator").GetComponent<BossGenerator>();
		boss.HealthBar.size = boss.Health / 100f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Kill")
        {
            boss.Health -= 5;
            boss.HealthBar.size = boss.Health / 100f;
            if(boss.Health == 0){
                Instantiate(explosionboss, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }

    }
}
