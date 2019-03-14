using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider_Destruction : MonoBehaviour
{
    public float _timer = 0f;
  public  Collider m_Collider;
    public bool state;


    // Start is called before the first frame update
    void Start()
    {

        m_Collider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (state == true)
        {
            _timer += Time.deltaTime;
           // print(_timer);
            m_Collider.enabled = false;

            if (_timer >= 3)
            {
                m_Collider.enabled = true;
                state = false;
                _timer = 0f;
            }
        }
    }

}
