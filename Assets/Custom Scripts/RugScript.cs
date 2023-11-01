using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RugScript : MonoBehaviour
{
    Rigidbody mattoRB;
    public float delay;
    public bool onSiirtynyt = true;

    void Start()

    {

        mattoRB = GetComponent<Rigidbody>();

    }

    private void FixedUpdate()
    {
        delay += Time.deltaTime;

        if (delay < 1 && onSiirtynyt == true)
        {
            MattoSiirtyy();
        }


        if (delay >= 1)
        {
            this.enabled = false;
            delay = 0;

            if (onSiirtynyt == true)
            {
                onSiirtynyt = false;
            }

            else
            {
                onSiirtynyt = true;
            }

        }

        if (delay < 1 && onSiirtynyt == false)
        {
            MattoPalaa();
        }

    }


    void MattoSiirtyy()
    {
        mattoRB.AddForce(0, 0, 1f);
    }

    void MattoPalaa()
    {
        mattoRB.AddForce(0, 0, -1f);
    }
}
