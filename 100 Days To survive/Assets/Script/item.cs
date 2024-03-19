using Unity.Burst.Intrinsics;
using UnityEngine;
[System.Serializable]
[CreateAssetMenu(menuName = "Scriptable object/Item" )]
public class Item : ScriptableObject
{
    public int itemId;
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
    public int count = 1;
    public int valeurRubyRouge = 0;
    public int valeurRubybleu = 0;
    public string description;
    public capicitytype spelltype;
    public Item(int id, string name)
    {
        itemId = id;
        itemName = name;
      
    }

    public Arme typearme;
    public int requiert;

}

public enum ItemType
{
    All,
    sword,
    bouclier,
    casque,
    plastron,
    jambiere,
    bottes,
    anneau,
    amulette,
    item,
    Consomnables,
    Abilité,
}

public enum capicitytype
{
    Buff,Debuff,Attack
}
public enum Arme
{
    sword,
    arc,
    hammer,
    baton,
    bouclier,
    hache,
    autre
}