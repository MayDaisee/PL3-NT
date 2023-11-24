using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
using UnityEngine.UI;

public enum Item
{
    none, credit, bottle
}

public class ItemCollision : MonoBehaviour
{
    public GameObject spawnThis;
    public GameObject pahaKasvi;
    bool pulloLevyllä;
    bool koksuIn;
    bool limuIn;
    ParticleSystem luigit;

    public Item collectableItem; //voi olla tarvittaessa lista

    public List<ItemCollision> requiredStepsDone;

    public UnityEvent onConsume;

    private void Start()
    {
        luigit = spawnThis.GetComponent<ParticleSystem>();
    }



    public void CheckIfRequirementsMet()
    {
        // Check that requiredStepsDone count
        Consume();
    }

    /// <summary>
    /// When all requirements met, Consume
    /// </summary>
    void Consume()
    {
        onConsume?.Invoke();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // get component for Intractable, if found, and type maches, requirements ok --> go on


        if (gameObject.name == "PoleCollider" && collision.gameObject.name == "PolettiIcon")
        {
            InteractionSuccess();

            print("Ole hyvä :)");
            Destroy(gameObject);

        }

        if (gameObject.name == "ChemCollider" && collision.gameObject.name == "LasipulloIcon")
        {
            InteractionSuccess();

            print("Jee pullo");
            pulloLevyllä = true;

        }

        if (gameObject.name == "SuihkepulloIcon" && collision.gameObject.name == "FullLasipulloIcon")
        {
            InteractionSuccess();

            print("KASVIMYRKKY GET");
            Destroy(gameObject);

        }

        if (gameObject.name == "KasviHitbox" && collision.gameObject.name == "MyrkkypulloIcon")
        {

            InteractionSuccess();
            pahaKasvi.SetActive(false);

            print("Voitto!");

        }


        void InteractionSuccess()
        {
            spawnThis.SetActive(true);
            collision.gameObject.SetActive(false);
        }

        if (pulloLevyllä == true)
        {
            Mixology();
        }

        void Mixology()
        {
            if (gameObject.name == "ChemCollider" && collision.gameObject.name == "LimuIcon")
            {
                collision.gameObject.SetActive(false);
                luigit.Play(true);
                limuIn = true;
                print("Limu miksattu");
            }

            if (gameObject.name == "ChemCollider" && collision.gameObject.name == "KoksuIcon")
            {
                collision.gameObject.SetActive(false);
                spawnThis.GetComponent<Light>().enabled = true;
                koksuIn = true;
            }

            if (koksuIn == true && limuIn == true)
            {
                gameObject.GetComponent<Button>().enabled = true;
            }

        }

        Consume();

        // ja sit joku OnDeniedEvent >> VÄÄRIN
    }
}
