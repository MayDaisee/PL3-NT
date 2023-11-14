using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySnap : MonoBehaviour
{
    //public List<GameObject> ikonit = new();
    RectTransform transformi;

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.gameObject.name);
        transformi = collision.gameObject.GetComponent<RectTransform>();
        transformi.anchoredPosition = new Vector3(0, 0, 0);

        // ei toimi, ihan kuin toinen scripti updateis positiota 
    }
}
