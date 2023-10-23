using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
[CreateAssetMenu(menuName = "Scriptable object/Quest" + "")]
public class Day : ScriptableObject
{
    public AudioClip music;
    public string phrasecomb;
    public string phraseplayer;
    public string phrasejoueur;
    public string name;
    public string histoire;
    public string choix_1;
    public string choix_2;
    public Sprite background;
    public int prixrouge;
    public int prixbleue;
    public int bonusvie;
    public int bonusdegat;
    public int bonusdexterité;
    public int bonusresistance;
    public int bonusintelligence;
    public int bonusmagie;
    public Item recompense;
    public List<Item> marché;
    public List<int> prix;
    public int recrouge;
    public int recbleu;
    public Day choix1;
    public Day choix2;
    public DayType typedequete;
    public Sprite perso;
    public String Firstdialogue;
    public String[] Choixdial1;
    public String[] Choixdial2;
    public String[] choixdial3;
    public string[] act1;
    public string[] act2;
    public string[] act3;
    public bool dial;
    public Day choix3;
    public List<Ennemy> combatmonstre;


    // Start is called before the first frame update
    public enum DayType
    {
        Combat,
        Marchand,
        Quete,
        Histoire
        
    }
}
