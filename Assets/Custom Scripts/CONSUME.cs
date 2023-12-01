using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
using UnityEngine.UI;


public class CONSUME : MonoBehaviour
{
    public GameObject spawnThis;                        // Suurin osa instansseista spawnaa jotain
    public GameObject killThis;                         // Jotkut myˆs tappaa (SuihkepulloIcon & KasviHitbox)
    public List<Itemtype> consumableItems;              // Instanssin oma vastaanotettava itemtyyppi, jotka m‰‰ritet‰‰n kussakin itemiss‰ erikseen interactableItem scriptill‰, tehty listaksi koska jotkut instanssit vaatii useamman eri itemin toimiakseen.
    bool pulloLevyll‰;                                  

    InteractableItem consumedItemType;                  // t‰ytyypi varastoida t‰‰ll‰ jotta toimii
    public List<InteractableItem> requiredStepsDone;    // HOX!! T‰ss‰ h‰mmennys, miten listata tarpeellisten vaiheiden m‰‰r‰ fiksusti, kun eri‰‰ per instanssi

    public UnityEvent onReqsMet;


    public void CheckIfRequirementsMet()                                
    {
        if (requiredStepsDone.Count == consumableItems.Count)           
        {
            onReqsMet.Invoke();                                         // voidaan invokata unityeventin‰ jokin public funktio
        }

        if (pulloLevyll‰ == true)                                       // Mixology saa tapahtua vain ja ainoastaan t‰m‰n ehdon t‰ytytty‰! Voisko t‰nkin saada unity event invokena??
        {
            Mixology();
        }

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.gameObject.name); // Debug

        consumedItemType = collision.gameObject.GetComponent<InteractableItem>();

        foreach (var consumableItem in  consumableItems)
        {

            if (consumedItemType.itemType == consumableItem)              // Omaako triggeriin osuneen colliderin gameObject sen saman tyypin itemin, mink‰ triggerin omaava gameobject vaatii?
            {
                requiredStepsDone.Add(consumedItemType);                  // Lis‰‰ kyseisen itemin tarvittujen vaiheiden listalle
                CheckIfRequirementsMet();                                 // sitten tarkistetaan onko tarvittujen vaiheiden m‰‰r‰ saavutettu ^
            }

        }
        
        if (consumedItemType.itemType == Itemtype.emptyBottle)          // Omaako triggeriin osuneen colliderin gameObject kyseisen itemtyypin?
        {
            pulloLevyll‰ = true;
            requiredStepsDone.Clear();                                  // koska jos huitoo jauheella tai limulla hitboxiin, niin foreachin if silti tapahtuu ja lis‰‰ listalle. N‰in se nollaantuu Mixologya varten hajoittamatta mit‰‰n.
        }


    }
    public void InteractionSuccessful()                                 // yleisimmin invokattu eventti
    {
        consumedItemType.gameObject.SetActive(false);                   //t‰n avulla objekti katoaa vasta kun kaikki vaaditut vaiheet on toteutettu! (oli aikaisemmin OnTriggerEnteriss‰, ei hyv‰)
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


        if (requiredStepsDone.Count == 1)                               // Emt onks t‰lle mit‰‰n j‰rkev‰mp‰‰ struktuuria Ø\_(uwu)_/Ø
        {
            spawnThis.GetComponent<ParticleSystem>().Play(true);
            consumedItemType.gameObject.SetActive(false);
        }

        if (requiredStepsDone.Count >= 2)
        {
            spawnThis.GetComponent<Light>().enabled = true;
            gameObject.GetComponent<Button>().enabled = true;
            consumedItemType.gameObject.SetActive(false);
        }

    }


}
