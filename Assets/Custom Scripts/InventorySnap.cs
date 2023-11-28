using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySnap : MonoBehaviour
{
    RectTransform transformi;
    bool triggered;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print(collision.gameObject.name);
        transformi = collision.gameObject.GetComponent<RectTransform>();               
        triggered = true;

    }

    public void SnapToInventory()
    {
        if (triggered == true)
        {
            transformi.anchoredPosition = new Vector3(0, 0, 0);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        triggered = false;
    }
}
