using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
using UnityEngine.UI;

using static UnityEditor.PlayerSettings;


public class CONSUME : MonoBehaviour
{
    public GameObject spawnThis;
    public GameObject killThis;
    public Itemtype consumableItems;

    InteractableItem consumedItemType;
    public List<InteractableItem> requiredStepsDone;

    public UnityEvent onReqsMet;


    public void CheckIfRequirementsMet()
    {
        if (requiredStepsDone.Count == requiredStepsDone.Capacity)
        {
            onReqsMet.Invoke();
        }

        if (consumedItemType.itemType == Itemtype.ingredient)
        {
            Mixology();
        }

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.gameObject.name);

        consumedItemType = collision.gameObject.GetComponent<InteractableItem>();

        if (consumedItemType.itemType == consumableItems)
        {
            requiredStepsDone.Add(consumedItemType);
            collision.gameObject.SetActive(false);
            CheckIfRequirementsMet();
        }

      
    }

    public void InteractionSuccessful()
    {
        spawnThis.SetActive(true);
        print(gameObject.name + "Interaction success");
    }

    public void Kill()
    {
        killThis.SetActive(false);
        print("Killed");
    }

    public void Mixology()
    {
        if (requiredStepsDone.Count == 1)
        {
            spawnThis.GetComponent<ParticleSystem>().Play(true);
        }

        if (requiredStepsDone.Count == 2)
        {
            spawnThis.GetComponent<Light>().enabled = true;
        }

        if (requiredStepsDone.Count >= 2)
        {
            gameObject.GetComponent<Button>().enabled = true;
        }
    }


}
