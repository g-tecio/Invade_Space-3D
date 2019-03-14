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
    public GameObject clouds,clouds2,clouds3,cloud4,cloud5;

    public float t;
    float current, previous, cont;

    Quaternion _originalRot;

    ParticleSystem _stars;


    bool aux = true, Negro=true, luz=true;

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

        current = HighScore.cont;
        var x = current - previous;
        cont = HighScore.cont;
        if (x >= 1000 && Negro == true)
        {
            previous = current;
            TurnDark();
            Negro = false;
            luz = false;
            print("Se va a oscurecer");
        }

        else if (x >= 1000 && luz == false)
        {
            previous = current;
            TurnLight();
            Negro = true;
            luz = true;
        }
        if (Dark)
        {
            value += 0.001f;
            cam.backgroundColor = Color.Lerp(sky, space, value);

            if (aux)
            {
                _stars.Play();
                aux = false;
                clouds.SetActive(false);
                clouds2.SetActive(false);
                clouds3.SetActive(false);
                cloud4.SetActive(false);
                cloud5.SetActive(false);
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
                clouds.SetActive(true);
                clouds2.SetActive(true);
                clouds3.SetActive(true);
                cloud4.SetActive(true);
                cloud5.SetActive(true);
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
