using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DemoScript : MonoBehaviour
{
    public Loader Inventorymanager;
    public Item[] itemsToPicKup;

    public void pickup(int id)
    {
        Inventorymanager.AddItem(itemsToPicKup[id]);
    }

   

   

}
