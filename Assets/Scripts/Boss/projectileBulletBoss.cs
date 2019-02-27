using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class projectileBulletBoss : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public GameObject effect;
    public float distance;
    public lives vida_canvas;

    // Use this for initialization
    void Start()
    {
        vida_canvas= GameObject.FindObjectOfType<lives>();
        Invoke("DestroyProjectile", lifetime);
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(0, 0, -(speed * Time.deltaTime));
    }


    void DestroyProjectile()
    {
        var p = Instantiate(effect, transform.position, Quaternion.identity);
        
        Destroy(p, 3f);
        Destroy(gameObject);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerInvincible invincible = other.GetComponent<PlayerInvincible>();
            invincible.hit = true;
            vida_canvas.CambioVida();

            CancelInvoke("DestroyProjectile");
            DestroyProjectile();
        }
    }
}
