using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class ItemCollision : MonoBehaviour
{
    public GameObject spawnThis;
    public GameObject pahaKasvi;
    bool pulloLevyllä;
    bool koksuIn;
    bool limuIn;
    ParticleSystem luigit;

    private void Start()
    {
        luigit = spawnThis.GetComponent<ParticleSystem>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

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

    }
}
