using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]

public partial class InventoryData
{
    public string itemName;
    public Sprite itemImage;

    public ItemType itemtype;
    public int bonusvie;
    public int bonusdegat;
    public int bonusdexterité;
    public int bonusresistance;
    public int bonusintelligence;
    public int bonusmagie;
    public bool stackable;
 public int count;
}

