using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poubelle : MonoBehaviour
{
    public List<Transform> slots; 

    public void RemoveItemsFromSlots()
    {
        foreach (Transform slot in slots)
        {
            
            if (slot.childCount > 0)
            {
               
                GameObject item = slot.GetChild(0).gameObject;

               
                Destroy(item);
            }
        }
    }
}