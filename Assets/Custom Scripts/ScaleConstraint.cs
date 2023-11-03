using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleConstraint : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform uIElement;
    private float maxScale = 2f;
    private float minScale =  0.5f;

    public void Scaleconstrainer()
    {

        if (uIElement.localScale.x > maxScale &&
            uIElement.localScale.y > maxScale &&
            uIElement.localScale.z > maxScale )
        {
            uIElement.localScale = new Vector3(2f, 2f, 2f);
        }

        if (uIElement.localScale.x < minScale &&
            uIElement.localScale.y < minScale &&
            uIElement.localScale.z < minScale)
        {
            uIElement.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
    }
}


