using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInvincible : MonoBehaviour
{
    public float fadeValue = 0.1f;
    public int numberOfFlashes = 4;

    public  bool hit = false;

    int _flashes;

    Renderer _rend;
    Color _original, _transparent;
    float _fade;

    bool alpha1 = true;


    void Awake()
    {
        _rend = GetComponentInChildren<Renderer>();
    }

    void Start()
    {
        _original = _rend.material.color;
        _transparent = new Color(_original.r, _original.g, _original.b, 0);

        _fade = 1;
        alpha1 = true;

        _flashes = numberOfFlashes;
        numberOfFlashes = 0;
    }

    public void Hit()
    {
        hit = true;
    }

    void Update()
    {
        if (hit)
        {
            gameObject.layer = 11;
            if (alpha1)
            {
                _fade -= fadeValue;
            }
            else
            {
                _fade += fadeValue;
            }
            _rend.material.color = Transparent(_fade);
        }

        if(numberOfFlashes >= _flashes)
        {
            hit = false;
            numberOfFlashes = 0;
            gameObject.layer = 0;
        }
    }

    public Color Transparent(float x)
    {
        if(x <= 0)
        {
            alpha1 = false;
        }
        else if( x >= 1)
        {
            alpha1 = true;
            numberOfFlashes++;
        }
        return new Color(_original.r, _original.g, _original.b, x);
    }
}
