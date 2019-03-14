using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class EnemyMovement : MonoBehaviour
{
    public float velocity = -15f;
    public int min, max;
    public GameObject effect;
    public bool nube = false;
    public lives vida_canvas;
    PlayerInvincible invincible2;
    public static bool pass;
    public float _timer = 0f;


    // Start is called before the first frame update
    void Start()
    {
        vida_canvas = GameObject.FindObjectOfType<lives>();

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
        var c = Instantiate(effect, transform.position, Quaternion.identity);
        Destroy(c, 2f);
        Destroy(gameObject);
    }
    void Awake()
    {

        invincible2 = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInvincible>();

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Destroyer")
        {
            var box = other.gameObject.GetComponent<Collider_Destruction>();
            if (box)
            {
                box.state = true;
                vida_canvas.CambioVida();
                invincible2.hit = true;
#if UNITY_ANDROID
                Handheld.Vibrate();
#endif
            }
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Kill")
        {
            DestroyProjectile();
            CancelInvoke("DestroyProjectile");
            Destroy(other.gameObject);

            Destroy(gameObject);

        }


        if (other.gameObject.tag == "Cloud")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);





        }

    }
}
