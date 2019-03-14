using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    public static float speed = 15f;
    public float moveSpeed = 1.5f;
    public bool sa = false;
    public lives vida_canvas;
    //public float interpolation = 0.01f;
    float _origValue;

    void Awake()
    {
        vida_canvas = GameObject.FindObjectOfType<lives>();
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
       
            rb.velocity = Input.acceleration * speed * moveSpeed;
          // rb.velocity = new Vector2(Input.GetAxis("Horizontal"), 0) * speed * moveSpeed;
        

    }

    void Update()
    {
        if (rb.velocity.x != 0)
        {
            transform.eulerAngles = new Vector3(0,0, -rb.velocity.x);
        }

        if (sa == true)
        {
            rb.velocity = Input.acceleration * 0;
           // rb.velocity = new Vector2(Input.GetAxis("Horizontal"), 0) * 0;
            sa = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "muro")
        {
           
            sa = true; ;
            print("adentro");
        }

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name.Contains("proyectil"))
        {
            PlayerInvincible invincible = GetComponent<PlayerInvincible>();
            invincible.hit = true;
            vida_canvas.CambioVida();

            Destroy(other.gameObject);
           
        }
    }
}

