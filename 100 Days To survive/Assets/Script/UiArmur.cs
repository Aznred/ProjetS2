using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiArmur : MonoBehaviour
{
    public List<Image> UiEquipement;
    public List<inventoryslot> equipementslot;
    public void Update()
    {
        
        if (equipementslot[0].transform.childCount > 0)
        {
               
            UiEquipement[0].sprite = equipementslot[0].GetComponentInChildren<DraggableItem>().Item.itemImage;
                
        }
        if (equipementslot[1].transform.childCount > 0)
        {
               
            UiEquipement[1].sprite = equipementslot[1].GetComponentInChildren<DraggableItem>().Item.itemImage;
              
        }
        if (equipementslot[2].transform.childCount > 0)
        {
                
            UiEquipement[2].sprite = equipementslot[2].GetComponentInChildren<DraggableItem>().Item.itemImage;
               
                
        }
        if (equipementslot[3].transform.childCount > 0)
        {
               
            UiEquipement[3].sprite = equipementslot[3].GetComponentInChildren<DraggableItem>().Item.itemImage;
               
        }
        if (equipementslot[4].transform.childCount > 0)
        {
                
            UiEquipement[4].sprite = equipementslot[4].GetComponentInChildren<DraggableItem>().Item.itemImage;
                
        }
            
           
         
    }
}
