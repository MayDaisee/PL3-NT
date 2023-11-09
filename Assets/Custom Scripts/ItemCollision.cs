using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemCollision : MonoBehaviour
{
    public GameObject poletti;
    public GameObject spawnThis;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.name == "PolettiIcon")
        {
            spawnThis.SetActive(true);
            poletti.SetActive(false);
            print("Ole hyvä :)");

        }


    }

}
