using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileBullet : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float distance;

    // Use this for initialization
    void Start()
    {
        Invoke("DestroyProjectile", lifetime);
 }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(0, 0, (speed * Time.deltaTime));
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {

            CancelInvoke("DestroyProjectile");
        }
        if (other.gameObject.tag == "Boss")
        {
            DestroyProjectile();

            CancelInvoke("DestroyProjectile");
        }
    }
}
