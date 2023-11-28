using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Itemtype
{
    none, credit, emptyBottle, fullBottle, soda, powder, poison
}

public class InteractableItem : MonoBehaviour
{

    public Itemtype itemType;


}
