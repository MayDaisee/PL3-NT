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
    public bool pulloLevyllä;

    public Itemtype consumableItems;
    InteractableItem consumedItemType;
    ParticleSystem luigit;

    public List<InteractableItem> requiredStepsDone;

    public UnityEvent onReqsMet;



    private void Start()
    {
        luigit = spawnThis.GetComponent<ParticleSystem>();
    }

    public void CheckIfRequirementsMet()
    {
        if (requiredStepsDone.Count == 0)
        {
            onReqsMet.Invoke();
        }

        if (pulloLevyllä == true)
        {
            //???????? ÄÄÄ
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.gameObject.name);

        consumedItemType = collision.gameObject.GetComponent<InteractableItem>();

        if (consumedItemType.itemType == consumableItems)
        {
            requiredStepsDone.Remove(consumedItemType);
            collision.gameObject.SetActive(false);
            CheckIfRequirementsMet();
        }

        if (consumedItemType.itemType == Itemtype.emptyBottle && consumedItemType.itemType == consumableItems)
        {
            pulloLevyllä = true; // I guess, oon väsynyt
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
    }

    public void Mixology()
    {
        //äää
    }


}
