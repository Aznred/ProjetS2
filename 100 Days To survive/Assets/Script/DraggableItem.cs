using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
[Serializable]
public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Item Item;
    public string itemName;
    public Image image;
    public TMP_Text counttext;
    [HideInInspector] public Transform parentafterdrag;
    [HideInInspector] public int count = 1;



    public void InitialiseItem(Item newitem)
    {
        Item = newitem;
        image.sprite = newitem.itemImage;
        itemName = newitem.itemName;
     

    }

    public void refreshcount()
    {
        counttext.text = count.ToString();
        bool textactive = count > 1;
        counttext.gameObject.SetActive(textactive);
    }
   

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Sauvegarde de la position et du parent d'origine de l'objet
        parentafterdrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Met à jour la position de l'objet pour le suivre avec la souris/finger
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
      transform.SetParent(parentafterdrag);
      image.raycastTarget = true;

    }
    
}
    