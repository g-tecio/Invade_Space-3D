using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMovement : MonoBehaviour
{
    public float velocity = -15f;
    public int min, max;
    public GameObject effect;
    public bool nube=false;
    public lives vida_canvas;

    // Start is called before the first frame update
    void Start()
    {
        vida_canvas= GameObject.FindObjectOfType<lives>();

        if (nube == false)
        {
            transform.Translate((Random.Range(min, max) * Time.deltaTime), 0, 0);
        }
        else
        {
            transform.Translate(0, 0, (Random.Range(min, max) * Time.deltaTime));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (nube == false)
        {
            transform.Translate((Random.Range(min, max) * Time.deltaTime), 0, 0);
        }
        else
        {
            transform.Translate(0, 0, (Random.Range(min, max) * Time.deltaTime));
        }
    }
    void DestroyProjectile()
    {
        Instantiate(effect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Destroyer")
        {
            Destroy(gameObject);
            print("Hola");
            vida_canvas.CambioVida();
        }
        if (other.gameObject.tag == "Kill")
        {
            DestroyProjectile();

            CancelInvoke("DestroyProjectile");
            Destroy(other.gameObject);

            Destroy(gameObject);

        }

    }
}
