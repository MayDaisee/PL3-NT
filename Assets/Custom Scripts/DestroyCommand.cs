using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCommand : MonoBehaviour
{

    public void destroyGameObject()
    {
        Destroy(this.gameObject);
    }

   
}
