using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class inventoryslot : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public TMP_Text name;
    public Image image;
    public ItemType acceptedItemType = ItemType.All;
    private static inventoryslot selectedSlot = null;
    private PlayerData playerData;
    private Item olditem = null;
    public TMP_Text sante;
    public TMP_Text degat;
    public TMP_Text dexterité;
    public TMP_Text resistance;
    public TMP_Text intelligence;
    public TMP_Text magie;
    public GameObject slot;
    public bool armor = false;
    public Loader loader;

    private void Start()
    {
        TooltipsDeck.instance.hidetooltip();
        Tooltipmanager.instance.hidetooltip();
        
        if (acceptedItemType != ItemType.All && acceptedItemType != ItemType.Abilité)
        {
            foreach (var ele in loader.ArmorList)
            {
                if (ele.itemtype == acceptedItemType)
                {
                    
                    olditem = ele;
                    loader.playerData.baseDamage -= ele.bonusdegat;
                    loader.playerData.baseHealth -= ele.bonusvie;
                    loader.playerData.baseDexterity -= ele.bonusdexterité;
                    loader.playerData.baseResistance -= ele.bonusresistance;
                    loader.playerData.baseIntelligence -= ele.bonusintelligence;
                    loader.playerData.baseMagic -= ele.bonusmagie;
                    Debug.Log(olditem);
                    loader.UpdatePlayerUI();
                }
              
        
            }
        }
        
       
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (gameObject.transform.childCount == 1)
        {
            DraggableItem draggable = gameObject.GetComponentInChildren<DraggableItem>();
            

            Tooltipmanager.instance.settooltip(draggable.Item);
            TooltipsDeck.instance.settooltip(draggable.Item);
        }
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Tooltipmanager.instance.hidetooltip();
        TooltipsDeck.instance.hidetooltip();
    }

    public void Update()
    {
       
        string playerDataJson =
            PlayerPrefs.GetString("PlayerData", "");
        if (!string.IsNullOrEmpty(playerDataJson))
        {
            playerData = JsonUtility.FromJson<PlayerData>(playerDataJson);
        }

        if (armor && slot.transform.childCount == 0 && olditem != null && olditem.itemtype == ItemType.Abilité)
        {
            for (int i = 0; i < loader.Deck.Count; i++)
            {
                if (loader.Deck[i].transform.childCount <= 0)
                {
                    name.text = "";
                }
            }
            olditem = null;
            armor = false;
            loader.UpdatePlayerData();
           
        }
        else if (armor && slot.transform.childCount == 0 && olditem != null)
        {
            for (int i = 0; i < loader.equipementslot.Count; i++)
            {
                if (loader.equipementslot[i].transform.childCount <= 0)
                {
                    loader.UiEquipement[i].sprite = loader.Transparent.sprite;
                }
                else
                {
                    loader.UiEquipement[i].sprite = loader.equipementslot[i].GetComponentInChildren<DraggableItem>().Item.itemImage;
                }
            }

            loader.bonusDamage-= olditem.bonusdegat;
            loader.bonusHealth -= olditem.bonusvie;
            loader.bonusDexterity -= olditem.bonusdexterité;
            loader.bonusResistance -= olditem.bonusresistance;
            loader.bonusIntelligence -= olditem.bonusintelligence;
            loader.bonusMagic -= olditem.bonusmagie;
            olditem = null;
            armor = false;
            loader.UpdatePlayerData();
        }
        
    }
    private bool CanEquipAbility(Item item)
    {
        
        switch (item.typearme)
        {
            case Arme.sword:
                return item.requiert <= playerData.epee;
            case Arme.arc:
                return item.requiert <= playerData.arc;
            case Arme.bouclier:
                return item.requiert <= playerData.bouclier;
            case Arme.baton:
                return item.requiert <= playerData.baton;
            case Arme.hache:
                return item.requiert <= playerData.hache;
            case Arme.hammer:
                return item.requiert <= playerData.massue;
            case Arme.autre:
     
                return true;
            default:
                return false;
        }
    }

    public Color selectcolor, notselectedcolor;
    
   
    
   
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
        {
            Debug.LogWarning("L'objet pointé par eventData.pointerDrag est null.");
            return;  // Quitter la méthode si eventData.pointerDrag est null.
        }
        if (transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;

            DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
            if (acceptedItemType == ItemType.Abilité)
            {
                if (CanEquipAbility(draggableItem.Item))
                {
                    draggableItem.parentafterdrag = transform;
                    name.text = draggableItem.Item.itemName;
                    olditem = draggableItem.Item;
                    armor = true;
                }
                else
                {
                   
                    Debug.Log("Le joueur n'a pas la maîtrise d'arme requise pour cette compétence.");
                }
            }
            else if (acceptedItemType == ItemType.All)
            {
                draggableItem.parentafterdrag = transform;
               
              
                loader.UpdatePlayerData();
            }
                else if (draggableItem.Item.typearme == Arme.arc && draggableItem.Item.requiert <= playerData.arc )
                {
                    draggableItem.parentafterdrag = transform;
                    olditem = draggableItem.Item;
                    playerData.damage +=olditem.bonusdegat;
                    playerData.health += olditem.bonusvie;
                    playerData.dexterity += olditem.bonusdexterité;
                    playerData.resistance += olditem.bonusresistance;
                    playerData.intelligence += olditem.bonusintelligence;
                    playerData.magic += olditem.bonusmagie;
                    intelligence.text = playerData.intelligence.ToString();
                    sante.text = playerData.health.ToString();
                    magie.text = playerData.magic.ToString();
                    degat.text = playerData.damage.ToString();
                    dexterité.text = playerData.dexterity.ToString();
                    resistance.text = playerData.resistance.ToString();
                    loader.bonusHealth += olditem.bonusvie;
                    loader.bonusDamage += olditem.bonusdegat;
                    loader.bonusDexterity += olditem.bonusdexterité;
                    loader.bonusResistance += olditem.bonusresistance;
                    loader.bonusIntelligence += olditem.bonusintelligence;
                    loader.bonusMagic += olditem.bonusmagie;
                    armor = true;
                    loader.UpdatePlayerData();
                    
                }
                else if (draggableItem.Item.typearme == Arme.sword && draggableItem.Item.requiert <= playerData.epee )
                {
                    draggableItem.parentafterdrag = transform;
                    olditem = draggableItem.Item;
                    playerData.damage +=olditem.bonusdegat;
                    playerData.health += olditem.bonusvie;
                    playerData.dexterity += olditem.bonusdexterité;
                    playerData.resistance += olditem.bonusresistance;
                    playerData.intelligence += olditem.bonusintelligence;
                    playerData.magic += olditem.bonusmagie;
                    intelligence.text = playerData.intelligence.ToString();
                    sante.text = playerData.health.ToString();
                    magie.text = playerData.magic.ToString();
                    degat.text = playerData.damage.ToString();
                    dexterité.text = playerData.dexterity.ToString();
                    resistance.text = playerData.resistance.ToString();
                    loader.bonusHealth += olditem.bonusvie;
                    loader.bonusDamage += olditem.bonusdegat;
                    loader.bonusDexterity += olditem.bonusdexterité;
                    loader.bonusResistance += olditem.bonusresistance;
                    loader.bonusIntelligence += olditem.bonusintelligence;
                    loader.bonusMagic += olditem.bonusmagie;
                    armor = true;
                    loader.UpdatePlayerData();
                }
                else if (draggableItem.Item.typearme == Arme.hache && draggableItem.Item.requiert <= playerData.hache)
                {
                    draggableItem.parentafterdrag = transform;
                    olditem = draggableItem.Item;
                    playerData.damage +=olditem.bonusdegat;
                    playerData.health += olditem.bonusvie;
                    playerData.dexterity += olditem.bonusdexterité;
                    playerData.resistance += olditem.bonusresistance;
                    playerData.intelligence += olditem.bonusintelligence;
                    playerData.magic += olditem.bonusmagie;
                    intelligence.text = playerData.intelligence.ToString();
                    sante.text = playerData.health.ToString();
                    magie.text = playerData.magic.ToString();
                    degat.text = playerData.damage.ToString();
                    dexterité.text = playerData.dexterity.ToString();
                    resistance.text = playerData.resistance.ToString();
                    loader.bonusHealth += olditem.bonusvie;
                    loader.bonusDamage += olditem.bonusdegat;
                    loader.bonusDexterity += olditem.bonusdexterité;
                    loader.bonusResistance += olditem.bonusresistance;
                    loader.bonusIntelligence += olditem.bonusintelligence;
                    loader.bonusMagic += olditem.bonusmagie;
                    armor = true;
                    loader.UpdatePlayerData();
                }
                else if (draggableItem.Item.typearme == Arme.hammer && draggableItem.Item.requiert <= playerData.massue )
                {
                    draggableItem.parentafterdrag = transform;
                    olditem = draggableItem.Item;
                    playerData.damage +=olditem.bonusdegat;
                    playerData.health += olditem.bonusvie;
                    playerData.dexterity += olditem.bonusdexterité;
                    playerData.resistance += olditem.bonusresistance;
                    playerData.intelligence += olditem.bonusintelligence;
                    playerData.magic += olditem.bonusmagie;
                    intelligence.text = playerData.intelligence.ToString();
                    sante.text = playerData.health.ToString();
                    magie.text = playerData.magic.ToString();
                    degat.text = playerData.damage.ToString();
                    dexterité.text = playerData.dexterity.ToString();
                    resistance.text = playerData.resistance.ToString();
                    loader.bonusHealth += olditem.bonusvie;
                    loader.bonusDamage += olditem.bonusdegat;
                    loader.bonusDexterity += olditem.bonusdexterité;
                    loader.bonusResistance += olditem.bonusresistance;
                    loader.bonusIntelligence += olditem.bonusintelligence;
                    loader.bonusMagic += olditem.bonusmagie;
                    armor = true;
                    loader.UpdatePlayerData();
                }
                else if (draggableItem.Item.typearme == Arme.bouclier && draggableItem.Item.requiert <= playerData.bouclier )
                {
                    draggableItem.parentafterdrag = transform;
                    olditem = draggableItem.Item;
                    playerData.damage +=olditem.bonusdegat;
                    playerData.health += olditem.bonusvie;
                    playerData.dexterity += olditem.bonusdexterité;
                    playerData.resistance += olditem.bonusresistance;
                    playerData.intelligence += olditem.bonusintelligence;
                    playerData.magic += olditem.bonusmagie;
                    intelligence.text = playerData.intelligence.ToString();
                    sante.text = playerData.health.ToString();
                    magie.text = playerData.magic.ToString();
                    degat.text = playerData.damage.ToString();
                    dexterité.text = playerData.dexterity.ToString();
                    resistance.text = playerData.resistance.ToString();
                    loader.bonusHealth += olditem.bonusvie;
                    loader.bonusDamage += olditem.bonusdegat;
                    loader.bonusDexterity += olditem.bonusdexterité;
                    loader.bonusResistance += olditem.bonusresistance;
                    loader.bonusIntelligence += olditem.bonusintelligence;
                    loader.bonusMagic += olditem.bonusmagie;
                    armor = true;
                    loader.UpdatePlayerData();
                }
                else if (draggableItem.Item.typearme == Arme.baton && draggableItem.Item.requiert <= playerData.baton)
                {
                    draggableItem.parentafterdrag = transform;
                    olditem = draggableItem.Item;
                    playerData.damage +=olditem.bonusdegat;
                    playerData.health += olditem.bonusvie;
                    playerData.dexterity += olditem.bonusdexterité;
                    playerData.resistance += olditem.bonusresistance;
                    playerData.intelligence += olditem.bonusintelligence;
                    playerData.magic += olditem.bonusmagie;
                    intelligence.text = playerData.intelligence.ToString();
                    sante.text = playerData.health.ToString();
                    magie.text = playerData.magic.ToString();
                    degat.text = playerData.damage.ToString();
                    dexterité.text = playerData.dexterity.ToString();
                    resistance.text = playerData.resistance.ToString();
                    loader.bonusHealth += olditem.bonusvie;
                    loader.bonusDamage += olditem.bonusdegat;
                    loader.bonusDexterity += olditem.bonusdexterité;
                    loader.bonusResistance += olditem.bonusresistance;
                    loader.bonusIntelligence += olditem.bonusintelligence;
                    loader.bonusMagic += olditem.bonusmagie;
                    armor = true;
                    loader.UpdatePlayerData();
                }
                else if (draggableItem.Item.typearme == Arme.autre )
                {
                    draggableItem.parentafterdrag = transform;
                    olditem = draggableItem.Item;
                    playerData.damage +=olditem.bonusdegat;
                    playerData.health += olditem.bonusvie;
                    playerData.dexterity += olditem.bonusdexterité;
                    playerData.resistance += olditem.bonusresistance;
                    playerData.intelligence += olditem.bonusintelligence;
                    playerData.magic += olditem.bonusmagie;
                    intelligence.text = playerData.intelligence.ToString();
                    sante.text = playerData.health.ToString();
                    magie.text = playerData.magic.ToString();
                    degat.text = playerData.damage.ToString();
                    dexterité.text = playerData.dexterity.ToString();
                    resistance.text = playerData.resistance.ToString();
                    loader.bonusHealth += olditem.bonusvie;
                    loader.bonusDamage += olditem.bonusdegat;
                    loader.bonusDexterity += olditem.bonusdexterité;
                    loader.bonusResistance += olditem.bonusresistance;
                    loader.bonusIntelligence += olditem.bonusintelligence;
                    loader.bonusMagic += olditem.bonusmagie;
                    armor = true;
                    loader.UpdatePlayerData();
                }

               

            }
            else
            {
               
                Debug.Log("Cet objet n'est pas accepté dans cette case.");
            }


          
        }
    }

