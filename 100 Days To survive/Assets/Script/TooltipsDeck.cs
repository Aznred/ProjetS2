using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TooltipsDeck : MonoBehaviour
{
    public static TooltipsDeck instance;

    public TMP_Text name;
    public TMP_Text Description;
    public TMP_Text requiert;
    public GameObject imarc;
    public GameObject imepee;
    public GameObject imhache;
    public GameObject immasse;
    public GameObject imbouc;
    public GameObject imbat;
  
    private void Awake()
    {
        if (instance != null && instance !=this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    

    void Start()
    {
        Cursor.visible = true;
        gameObject.SetActive(false);
    }

 
    void Update()
    {
        transform.position = new Vector3(Input.mousePosition.x + 196, Input.mousePosition.y + 112, 0);
    }

    public void settooltip(Item item)
    {
       
        gameObject.SetActive(true);
        name.text = item.itemName;
        requiert.text = item.requiert.ToString();
      
        Description.text = $"{item.description}";
         if (item.typearme == Arme.autre)
         {
             requiert.text = "";
             imarc.SetActive(false);
             imbat.SetActive(false);
             imbouc.SetActive(false);
             imepee.SetActive(false);
             imhache.SetActive(false);
             immasse.SetActive(false);
         }
         if (item.typearme == Arme.arc)
         {
             imarc.SetActive(true);
             imbat.SetActive(false);
             imbouc.SetActive(false);
             imepee.SetActive(false);
             imhache.SetActive(false);
             immasse.SetActive(false);
         }
         if (item.typearme == Arme.baton)
         {
             imarc.SetActive(false);
             imbat.SetActive(true);
             imbouc.SetActive(false);
             imepee.SetActive(false);
             imhache.SetActive(false);
             immasse.SetActive(false);
         }
         if (item.typearme == Arme.bouclier)
         {
             imarc.SetActive(false);
             imbat.SetActive(false);
             imbouc.SetActive(true);
             imepee.SetActive(false);
             imhache.SetActive(false);
             immasse.SetActive(false);
         }
         if (item.typearme == Arme.sword)
         {
             imarc.SetActive(false);
             imbat.SetActive(false);
             imbouc.SetActive(false);
             imepee.SetActive(true);
             imhache.SetActive(false);
             immasse.SetActive(false);
         }
         if (item.typearme == Arme.hache)
         {
             imarc.SetActive(false);
             imbat.SetActive(false);
             imbouc.SetActive(false);
             imepee.SetActive(false);
             imhache.SetActive(true);
             immasse.SetActive(false);
         }
         if (item.typearme == Arme.hammer)
         {
             imarc.SetActive(false);
             imbat.SetActive(false);
             imbouc.SetActive(false);
             imepee.SetActive(false);
             imhache.SetActive(false);
             immasse.SetActive(true);
         }
    }

    public void hidetooltip()
    {
        gameObject.SetActive(false);
    }
}
