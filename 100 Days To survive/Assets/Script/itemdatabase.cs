using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

[CreateAssetMenu(fileName = "New Item Database", menuName = "Item Database")]
public class InventoryItemData : ScriptableObject
{
    public List<Item> items = new List<Item>();
    
   
}

public partial class InventoryData
{
    public InventoryItemData[] items;
}
