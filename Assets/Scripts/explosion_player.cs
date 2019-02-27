using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion_player : MonoBehaviour
{
   public GameObject explosion;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lives.vida2 <= 0)
        {
            explosion.SetActive(true);
            player.SetActive(false);
            
        }
    }
}
