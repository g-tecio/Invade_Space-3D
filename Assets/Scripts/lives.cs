using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class lives : MonoBehaviour
{
    public Sprite[] vida;
    public static int vida2 = 3;
    


    void Start()
    {
    }

    void Update()
    {
        
    }
    
    public void CambioVida(){
        vida2--;
       

        if (vida2 <0)
        {
            StartCoroutine(wait());
            

        }else
        {
            this.GetComponent<Image>().sprite = vida[vida2];
        }
        

        

    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene("Menu_Scene");
    }
}
