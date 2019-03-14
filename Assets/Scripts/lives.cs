using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class lives : MonoBehaviour
{
    public Sprite[] vida;
    public static int vida2 = 3;
    public float value;
   // public Color white;
    //public Color black;
    //public GameObject panel;
    //public Image panelI;

    void Start()
    {
    }

    void Update()
    {
        
    }
    
    public void CambioVida(){
        vida2--;
        value += 0.001f;
        if (vida2 <= 0)
        {
            StartCoroutine(wait());
        }else
        {
            this.GetComponent<Image>().sprite = vida[vida2];
        }
        

        

    }
    IEnumerator wait()
    {
        //panelI = panel.GetComponent<Image>();
        //panelI.color= Color.Lerp(white,black, value);
        yield return new WaitForSeconds(5f);

        SceneManager.LoadScene("Menu_Scene");
    }
}
