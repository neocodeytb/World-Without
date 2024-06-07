using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightsScript : MonoBehaviour
{
    public NinjaScript ninja;
    public Light L;
    public float pas = -0.5f;

    void Start()
    {
        
    }

    void Update()
    {
        if (ninja.levelUp == true)
        {
            L.intensity += pas * Time.deltaTime;
            if (L.intensity <= 0.0f) 
            {
                pas = pas * (-1.0f);
            }
            if (L.intensity >= 1.0f)
            {
                L.intensity = 1.0f;
                ninja.levelUp = false;
                pas = pas * (-1.0f);
            }

        }
    }
}
