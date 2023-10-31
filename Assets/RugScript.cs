using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RugScript : MonoBehaviour
{
    Rigidbody mattoRB;
    public float delay;

    void Start()

    {
        mattoRB = GetComponent<Rigidbody>();
        print("Rigidbody Get");

    }

    private void Update()
    {
        delay += Time.deltaTime;

        if (delay <= 1)
        {
            MattoSiirtyy();
        }

    }


    void MattoSiirtyy()
    {
        mattoRB.AddForce(0, 0, 1f);
        print("siirtyy");
    }
}
