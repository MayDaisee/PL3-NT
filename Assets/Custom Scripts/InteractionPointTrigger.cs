using System.Collections;
using System.Collections.Generic;
using TouchScript.Examples;
using TouchScript.Examples.Tap;
using Unity.VisualScripting;
using UnityEngine;

public class InteractionPointTrigger : MonoBehaviour
{
    public string tagName;
    public GameObject spawnableObject;
    public GameObject spawnPoint;
    public GameObject uIHierarchy;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //spawnPosition = spawnPoint.transform;

        if (GameObject.FindWithTag(tagName))
        {
            Instantiate(spawnableObject, spawnPoint.transform.position, Quaternion.identity, uIHierarchy.transform);
            Debug.Log("Tägilöydetty");
            Destroy(gameObject);
        }

    }

}
