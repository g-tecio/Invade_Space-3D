using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    public static float speed = 15f;
    //public float interpolation = 0.01f;
    float _origValue;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.velocity = Input.acceleration * speed;
        rb.velocity = new Vector2(Input.GetAxis("Horizontal"), 0) * speed;
    }

    void Update()
    {
        if (rb.velocity.x != 0)
        {
            transform.eulerAngles = new Vector3(0,0, -rb.velocity.x);
        }
    }
}

