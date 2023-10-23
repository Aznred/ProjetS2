using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TooltipCombat : MonoBehaviour
{


    public static TooltipCombat instance;

    public TMP_Text name;
    public TMP_Text bonusitemvie;
    public TMP_Text bonusitemdam;
    public TMP_Text bonusitemdex;
    public TMP_Text bonusitemres;
    public TMP_Text bonusitemint;
    public TMP_Text bonusitemmag;
    public TMP_Text vluelife;
    public TMP_Text vluemax;
  
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

    public void settooltip(Ennemy item, Slider slider)
    {
       
        gameObject.SetActive(true);
        name.text = item.name;
       
         bonusitemvie.text = $"{item.Health}";
         bonusitemdam.text = $"{item.Damage}";
         bonusitemdex.text = $"{item.Dexterity}";
         bonusitemres.text = $"{item.Resistance}";
         bonusitemint.text = $"{item.Intelligence}";
         bonusitemmag.text = $"{item.Magic}";
         vluelife.text = slider.value.ToString();
         vluemax.text = $"{item.Health*100}";

    }

    public void hidetooltip()
    {
        gameObject.SetActive(false);
    }
}


