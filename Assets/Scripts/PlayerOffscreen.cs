using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOffscreen : MonoBehaviour
{
    public float buffer = .8f;
    public float distance;

    float _leftConstraint, _rightConstraint;

    Camera cam;

    void Awake()
    {
        cam = Camera.main;
    }

    void Start()
    {
        distance = Mathf.Abs(cam.transform.position.z) + transform.position.z;
    }

    void Update()
    {
        _leftConstraint = cam.ScreenToWorldPoint(new Vector3(0, 0, distance)).x;
        _rightConstraint = cam.ScreenToWorldPoint(new Vector3(Screen.width, 0, distance)).x;
        Debug.DrawLine(cam.transform.position, cam.ScreenToWorldPoint(new Vector3(0,0,distance)), Color.green);
        Debug.DrawLine(cam.transform.position, cam.ScreenToWorldPoint(new Vector3(Screen.width,0,distance)), Color.blue);

        if(transform.position.x < _leftConstraint - (buffer * 2))
        {
            transform.position = new Vector3(_rightConstraint + buffer, transform.position.y, transform.position.z);
        }
        else if(transform.position.x > _rightConstraint + (buffer * 2))
        {
            transform.position = new Vector3(_leftConstraint - buffer, transform.position.y, transform.position.z);
        }
    }
}
