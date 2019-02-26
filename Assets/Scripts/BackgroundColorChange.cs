using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundColorChange : MonoBehaviour
{
    Camera cam;

    public Transform newRotation;
    //public GameObject clouds;

    public float value;
    public Color sky;
   /*  public Color pink;
    public Color orange;
    public Color purple;
    public Color gray; */
    public Color space;

    public bool Dark, Light;

    Transform _sun;


    public float t;

    Quaternion _originalRot;

    ParticleSystem _stars;


    bool aux = true;

    void Awake()
    {
        cam = GetComponent<Camera>();
        _sun = GameObject.Find("Directional Light").GetComponent<Transform>();
        _stars = GameObject.Find("Stars").GetComponent<ParticleSystem>();

    }

    void Start()
    {
        _originalRot = _sun.rotation;
        aux = true;
    }

    void Update()
    {
        if (Dark)
        {
            value += 0.001f;
            cam.backgroundColor = Color.Lerp(sky, space, value);

            if (aux)
            {
                _stars.Play();
                aux = false;
                //clouds.SetActive(false);
            }

            t += 0.0002f;
            _sun.rotation = Quaternion.RotateTowards(_sun.rotation, newRotation.rotation, t);
        }
        else if (!Dark && Light)
        {
            value += 0.001f;
            cam.backgroundColor = Color.Lerp(space, sky, value);

            if (value >= 0.2f)
            {
                _stars.Stop();
                aux = true;
                //clouds.SetActive(true);
            }


            t += 0.0002f;
            _sun.rotation = Quaternion.RotateTowards(_sun.rotation, _originalRot, t);
        }
    }

    public void TurnDark()
    {
        Dark = true;
        Light = false;
        value = 0;
        t = 0;
    }
    public void TurnLight()
    {
        Dark = false;
        Light = true;
        value = 0;
        t = 0;
    }
}
