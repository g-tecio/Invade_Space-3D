using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class lives : MonoBehaviour
{
    public Sprite[] vida;
    public int vida2 = 3;


    void Start()
    {
    }

    void Update()
    {
        
    }
    
    public void CambioVida(){
        vida2--;
        this.GetComponent<Image>().sprite = vida[vida2];

        if (vida2 <= 0)
        {
            SceneManager.LoadScene("Menu_Scene");
            

        }
        

        

    }
}
