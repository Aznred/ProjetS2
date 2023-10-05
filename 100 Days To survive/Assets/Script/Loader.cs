using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;


[Serializable]
[SerializeField]
public class Loader : MonoBehaviour
{
    public int bonusDamage = 0;
    public int bonusHealth = 0;
    public int bonusDexterity = 0;
    public int bonusResistance = 0;
    public int bonusIntelligence = 0;
    public int bonusMagic = 0;
    public AudioSource entreance;
    public GameObject trans;
    public TMP_Text namemob;
    public TMP_Text nameplayer;
    public Image perso;
    public Image ennemy;
    public AudioSource ambiance;
    public AudioSource dicesong;
    public Image attaquemob;
    public Image defensemob;
    public GameObject defaite;
    public GameObject victoire;
    public TMP_Text bonusitemvie;
    public TMP_Text bonusitemdam;
    public TMP_Text bonusitemdex;
    public TMP_Text bonusitemres;
    public TMP_Text bonusitemint;
    public TMP_Text bonusitemmag;
    public TMP_Text requiert;
    public Image req;
    public GameObject imarc;
    public GameObject imepee;
    public GameObject imhache;
    public GameObject immasse;
    public GameObject imbouc;
    public GameObject imbat;
    public bool mag = false;
    public bool mindbool;
    public bool dodging;
    public int tourrecup;
    public int cooldown = 3;
    public int timedodge = 2;
    public int randomboost;
    public Button dodgeButton;
    public Button castButton;
    public Button mindButton;
    public TMP_Text phrasemid;
    public Button attackButton;
    public TMP_Text phrase;
    private int dicemonste;
    public TMP_Text namemonstre;
    public Image monstre;
    public Image monstreback;
    public GameObject combat;
    public TMP_Text healthmonstre;
    public TMP_Text degatmonstre;
    public TMP_Text dexhmonstre;
    public TMP_Text reshmonstre;
    public TMP_Text inthmonstre;
    public TMP_Text magiemonstre;
    public TMP_Text healthplay;
    public TMP_Text degatplay;
    public TMP_Text dexplay;
    public TMP_Text respaly;
    public TMP_Text intplay;
    public TMP_Text magieplay;
    public TMP_Text nameplay;
    public Image combbackgr;
    public Image playerim;
    public Slider healthmob;
    private int dicescore;
    public Slider heatlhplayer;
    public Image back;
    public List<Item> dataitem;
    public GameObject croix1;
    public GameObject croix2;
    public TMP_Text playerNameText;
    public TMP_Text epee;
    public TMP_Text arc;
    public TMP_Text bouclier;
    public TMP_Text baton;
    public TMP_Text hache;
    public TMP_Text massue;
    public TMP_Text sante;
    public TMP_Text degat;
    public TMP_Text dexterité;
    public TMP_Text resistance;
    public TMP_Text intelligence;
    public TMP_Text magie;
    public TMP_Text sante1;
    public TMP_Text degat1;
    public TMP_Text dexterité1;
    public TMP_Text resistance1;
    public TMP_Text intelligence1;
    public TMP_Text magie1;
    public TMP_Text rubyred;
    public TMP_Text rubybleu;
    public TMP_Text jour;
    public TMP_Text total;
    public TMP_Text pointarme;

    public TMP_Text pointstat;
    public GameObject dice;
    public GameObject diceanim;
    public TMP_Text random;
    

   
    public GameObject[] pages; 

    private PlayerData playerData;
    public inventoryslot[] Inventoryslots;
    public GameObject InvetoryItemprefab;
    public InventoryData[] inventorySlotData;
    public inventoryslot[] armorinventory;
    private static inventoryslot selectedSlot;
    public Image imageequip;
    public List<inventoryslot> equippedarmor;
    public List<inventoryslot> equippedarmor1;
    public List<Image> UiEquipement;
    public List<inventoryslot> equipementslot;
    public GameObject armor;
    public List<Item> armoritem;
    public List<Sprite> meteo;
    public Image meteochange;
    public TMP_Text actiondujour;
    public TMP_Text action1;
    public TMP_Text action2;
    public Day quete;
    public List<Day> dataquete;
    public GameObject buttonhealth;
    public GameObject buttondam;
    public GameObject buttres;
    public GameObject butdex;
    public GameObject butint;
    public GameObject butmag;



    private void Awake()
    {
        LoadPlayerData();
    }

        private void Start()
        {bonusDamage = 0;
        bonusHealth = 0;
         bonusDexterity = 0;
         bonusResistance = 0;
        bonusIntelligence = 0;
         bonusMagic = 0;
            Acualise();
            mindButton.enabled = true;
            attackButton.interactable = true;
            heatlhplayer.maxValue = playerData.health * 100;
            heatlhplayer.value = playerData.health * 100;
      
      GenererDay(quete);
        
        selectedSlot = Inventoryslots[1];
    }
       
      
        

        public void Update()
        {
        
            if (playerData.baseHealth >= 5)
            {
                buttonhealth.SetActive(false);
            }
            if (playerData.baseDamage >= 5)
            {
                buttondam.SetActive(false);
            }
            if (playerData.baseDexterity >= 5)
            {
                butdex.SetActive(false);
            }
            if (playerData.baseResistance >= 5)
            {
                buttres.SetActive(false);
            }
            if (playerData.baseIntelligence >= 5)
            {
                butint.SetActive(false);
            }
            if (playerData.baseMagic >= 5)
            {
                butmag.SetActive(false);
            }
            UpdatePlayerData();
            if (tourrecup <=0)
            {
                dodging = false;
            }

            
            armor = GameObject.FindWithTag("inv1");
          
            if (equipementslot[0].transform.childCount > 0)
            {
                UiEquipement[0].sprite = equipementslot[0].GetComponentInChildren<DraggableItem>().Item.itemImage;
                UpdatePlayerUI();
            }
            if (equipementslot[1].transform.childCount > 0)
            {
                UiEquipement[1].sprite = equipementslot[1].GetComponentInChildren<DraggableItem>().Item.itemImage;
                UpdatePlayerUI();
            }
            if (equipementslot[2].transform.childCount > 0)
            {
                UiEquipement[2].sprite = equipementslot[2].GetComponentInChildren<DraggableItem>().Item.itemImage;
                UpdatePlayerUI();
            }
            if (equipementslot[3].transform.childCount > 0)
            {
                UiEquipement[3].sprite = equipementslot[3].GetComponentInChildren<DraggableItem>().Item.itemImage;
                UpdatePlayerUI();
            }
            if (equipementslot[4].transform.childCount > 0)
            {
                UiEquipement[4].sprite = equipementslot[4].GetComponentInChildren<DraggableItem>().Item.itemImage;
                UpdatePlayerUI();
            }
            
           
         
        }

        public void UpdatePlayerData()
    {
       
        playerData.playerName = playerNameText.text;

        playerData.health = int.Parse(sante.text);
        playerData.damage = int.Parse(degat.text);
        playerData.dexterity = int.Parse(dexterité.text);
        playerData.intelligence = int.Parse(intelligence.text);
        playerData.resistance = int.Parse(resistance.text);
        playerData.magic = int.Parse(magie.text);
        playerData.blueRubies = int.Parse(rubybleu.text);
        playerData.redRubies = int.Parse(rubyred.text);
        playerData.epee = int.Parse(epee.text);
        playerData.arc = int.Parse(arc.text);
        playerData.baton = int.Parse(baton.text);
        playerData.bouclier = int.Parse(bouclier.text);
        playerData.hache = int.Parse(hache.text);
        playerData.massue = int.Parse(massue.text);
        playerData.jour = int.Parse(jour.text);
        playerData.pointarme = int.Parse(pointarme.text);
        playerData.pointstat = int.Parse(pointstat.text);

        playerData.inventory.Clear();
        playerData.arminv.Clear();
        playerData.invstr.Clear();
        playerData.quete = quete.name; 
        Debug.Log(playerData.quete);
        foreach (var slot in equippedarmor)
        {
            if (slot.transform.childCount > 0)
            {
                
                DraggableItem itemInSlot = slot.GetComponentInChildren<DraggableItem>();
                if (itemInSlot != null)
                {
                    playerData.arminv.Add(itemInSlot.Item.name);
                    Debug.Log(itemInSlot.Item.name);  
                }
                
            }
        }
        
  
     
       

        foreach (inventoryslot slot in Inventoryslots)
        {
            DraggableItem itemInSlot = slot.GetComponentInChildren<DraggableItem>();
            if (itemInSlot != null)
            {
                
                playerData.invstr.Add(itemInSlot.Item.name);
                Debug.Log(itemInSlot.Item.name);  
            }
        }


      

      
        string playerDataJson = JsonUtility.ToJson(playerData);
        PlayerPrefs.SetString("PlayerData", playerDataJson);
        PlayerPrefs.Save();
        UpdatePlayerUI();
    }

   
    private void LoadPlayerData()
    {
        string playerDataJson =
            PlayerPrefs.GetString("PlayerData", ""); 

        if (!string.IsNullOrEmpty(playerDataJson))
        {
            playerData = JsonUtility.FromJson<PlayerData>(playerDataJson); 

            armoritem = playerData.armoritem;
            foreach (var slot in equippedarmor)
            {
                foreach (var name in playerData.arminv)
                {
                    Debug.Log(name);
                    foreach (var ele in dataitem)
                    {  
                        if (name== ele.name)
                        {
                        
                       
                            if (slot.acceptedItemType == ele.itemtype && slot.transform.childCount < 1)
                            {
                                playerData.damage -= ele.bonusdegat;
                                playerData.health -= ele.bonusvie;
                                playerData.dexterity -= ele.bonusdexterité;
                                playerData.resistance -= ele.bonusresistance;
                                playerData.intelligence -= ele.bonusintelligence;
                                playerData.magic -= ele.bonusmagie;
                                SpawnItem(ele,slot);

                                intelligence.text = (playerData.baseIntelligence+ bonusIntelligence).ToString();
                                sante.text = (playerData.baseHealth + bonusHealth).ToString();
                                magie.text = (playerData.baseMagic+ bonusMagic).ToString();
                                degat.text = (playerData.baseDamage+ bonusDamage).ToString();
                                dexterité.text = (playerData.baseDexterity+ bonusDexterity).ToString();
                                resistance.text = (playerData.baseResistance+ bonusResistance).ToString();
                               
                            }
                        }
                    }
                
                }
            
            }
            playerNameText.text = playerData.playerName;
            epee.text = playerData.epee.ToString();
            arc.text = playerData.arc.ToString();
            hache.text = playerData.hache.ToString();
            baton.text = playerData.baton.ToString();
            bouclier.text = playerData.bouclier.ToString();
            massue.text = playerData.massue.ToString();
            intelligence.text = playerData.intelligence.ToString();
            sante.text = playerData.health.ToString();
            magie.text = playerData.magic.ToString();
            degat.text = playerData.damage.ToString();
            dexterité.text = playerData.dexterity.ToString();
            resistance.text = playerData.resistance.ToString();
            intelligence1.text = playerData.intelligence.ToString();
            sante1.text = playerData.health.ToString();
            magie1.text = playerData.magic.ToString();
            degat1.text = playerData.damage.ToString();
            dexterité1.text = playerData.dexterity.ToString();
            resistance1.text = playerData.resistance.ToString();
            rubybleu.text = playerData.blueRubies.ToString();
            rubyred.text = playerData.redRubies.ToString();
            jour.text = playerData.jour.ToString();
            total.text = (playerData.redRubies + playerData.blueRubies).ToString();
            pointarme.text = playerData.pointarme.ToString();
            pointstat.text = playerData.pointstat.ToString();
            Debug.Log(playerData.quete);
            foreach (var day in dataquete)
            {
                if (playerData.quete == day.name)
                {
                    quete = day;
                } 
            }


            


            pages[playerData.currentPageIndex].SetActive(true);
            for (int i = 0; i < pages.Length; i++)
            {
                if (i == playerData.currentPageIndex)
                {
                    pages[i].SetActive(true);

                    
                    Image pageImage = pages[i].GetComponent<Image>();
                    if (pageImage != null)
                    {
                        imageequip.sprite = pageImage.sprite;
                       
                    }
                }
            }

            foreach (inventoryslot slot in Inventoryslots)
            {
                if (selectedSlot != null)
                {
                    if (selectedSlot.transform.childCount > 0)
                    {
                        Destroy(selectedSlot.transform.GetChild(0).gameObject);
                    }
                    else
                    {
                        Debug.Log("Le transform de selectedSlot n'a pas d'enfants.");
                    }
                }
                else
                {
                    Debug.Log("selectedSlot est null.");
                }
            }




            foreach (var name in playerData.invstr)
            {
                Debug.Log(name);
                foreach (var ele in dataitem)
                {
                    
                    if (name== ele.name)
                    {
                        AddItemToInventory(ele);
                    }
                }
                
            }



          
        }
        else
        {
            Debug.LogWarning("Aucune donnée de joueur n'a été trouvée.");
        }

       
    }

    public void AddItemToInventory(Item item)
    {
     
        for (int i = 0; i < Inventoryslots.Length; i++)
        {
            inventoryslot slot = Inventoryslots[i];
            DraggableItem itemInSlot = slot.GetComponentInChildren<DraggableItem>();
            if (itemInSlot == null)
            {
               
                SpawnItem(item, slot);
                return;
            }
        }
    }



    public void quit()
    {
        Application.Quit();
    }

    public void menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void credits()
    {
        SceneManager.LoadScene("credits");
    }

    public void achievement()
    {
        SceneManager.LoadScene("succes");
    }

  public void AddHealthStat()
    {
       
        if (playerData.pointstat > 0 && playerData.baseHealth < 5)
        {
            playerData.pointstat--;
            playerData.baseHealth++;
            playerData.health = playerData.baseHealth + bonusHealth;
            sante.text = playerData.health.ToString();
            pointstat.text = playerData.pointstat.ToString();
        }
        UpdatePlayerData();
    }

    public void AddDamageStat()
    {
        if (playerData.pointstat > 0&& playerData.baseDamage < 5)
        {
            playerData.pointstat--;
            playerData.baseDamage++;
            playerData.damage = playerData.baseDamage + bonusDamage;
            degat.text = playerData.damage.ToString();
            pointstat.text = playerData.pointstat.ToString();
        }
        UpdatePlayerData();
    }

    public void AddDexterityStat()
    {
        if (playerData.pointstat > 0&& playerData.baseDexterity < 5)
        {
            playerData.pointstat--;
            playerData.baseDexterity++;
            playerData.dexterity = playerData.baseDexterity + bonusDexterity;
            dexterité.text = playerData.dexterity.ToString();
            pointstat.text =  playerData.pointstat.ToString();
        }
        UpdatePlayerData();
    }

    public void AddIntelligenceStat()
    {
        if (playerData.pointstat > 0&& playerData.baseIntelligence < 5)
        {
            playerData.pointstat--;
            playerData.baseIntelligence++;
            playerData.intelligence = playerData.baseIntelligence + bonusIntelligence;
            intelligence.text = (playerData.baseIntelligence+ bonusIntelligence).ToString();
            
            pointstat.text =  playerData.pointstat.ToString();
        }
        UpdatePlayerData();
    }

    public void AddResistanceStat()
    {
        if (playerData.pointstat > 0&& playerData.baseResistance < 5)
        {
            playerData.pointstat--;
            playerData.baseResistance++;
            playerData.resistance = playerData.baseResistance + bonusResistance;
            resistance.text = playerData.resistance.ToString();
            pointstat.text =  playerData.pointstat.ToString();
        }
        UpdatePlayerData();
    }

    public void AddMagicStat()
    {
        if (playerData.pointstat > 0&& playerData.baseMagic < 5)
        {
            playerData.pointstat--;
            playerData.baseMagic++;
            playerData.magic = playerData.baseMagic + bonusMagic;
            magie.text = playerData.magic.ToString();
            pointstat.text =  playerData.pointstat.ToString();
        }
        UpdatePlayerData();
    }
    
    

    public void AddEpeeStat()
    {
        if (playerData.pointarme > 0)
        {
            playerData.pointarme--;
            playerData.epee++;
            epee.text = playerData.epee.ToString();
            pointarme.text = playerData.pointarme.ToString();
        }
        UpdatePlayerData();
    }

    public void AddArcStat()
    {
        if (playerData.pointarme > 0)
        {
            playerData.pointarme--;
            playerData.arc++;
            arc.text = playerData.arc.ToString();
            pointarme.text = playerData.pointarme.ToString();
        }
        UpdatePlayerData();
    }

    public void AddBatonStat()
    {
        if (playerData.pointarme > 0)
        {
            playerData.pointarme--;
            playerData.baton++;
            baton.text = playerData.baton.ToString();
            pointarme.text = playerData.pointarme.ToString();
            
        }
        UpdatePlayerData();
    }

    public void AddBouclierStat()
    {
        if (playerData.pointarme > 0)
        {
            playerData.pointarme--;
            playerData.bouclier++;
            bouclier.text = playerData.bouclier.ToString();
            pointarme.text = playerData.pointarme.ToString();
        }
        UpdatePlayerData();
    }

    public void AddHacheStat()
    {
        if (playerData.pointarme > 0)
        {
            playerData.pointarme--;
            playerData.hache++;
            hache.text = playerData.hache.ToString();
            pointarme.text = playerData.pointarme.ToString();
        }
        UpdatePlayerData();
    }

    public void AddMassueStat()
    {
        if (playerData.pointarme > 0)
        {
            playerData.pointarme--;
            playerData.massue++;
            massue.text = playerData.massue.ToString();
            pointarme.text = playerData.pointarme.ToString();
        }
        UpdatePlayerData();
    }

    public void AddItem(Item item)
    {
        for (int i = 0; i < Inventoryslots.Length; i++)
        {
            inventoryslot slot = Inventoryslots[i];
            DraggableItem iteminslot = slot.GetComponentInChildren<DraggableItem>();
            if (iteminslot != null && iteminslot.Item == item && iteminslot.count < 20 &&
                iteminslot.Item.stackable == true)
            {
                iteminslot.count++;
                iteminslot.refreshcount();


                return;
            }
        }

        for (int i = 0; i < Inventoryslots.Length; i++)
        {
            inventoryslot slot = Inventoryslots[i];
            DraggableItem iteminslot = slot.GetComponentInChildren<DraggableItem>();
            if (iteminslot == null)
            {
                SpawnItem(item, slot);
                return;
            }
        }
    }   

    public void SpawnItem(Item item, inventoryslot slot)
    {
        GameObject newitemgo = Instantiate(InvetoryItemprefab, slot.transform);
        DraggableItem invetoryItem = newitemgo.GetComponent<DraggableItem>();
        invetoryItem.InitialiseItem(item);
  
    }
    public void AddItemToArmorSlot(Item item)
    {
      
        foreach (inventoryslot slot in armorinventory)
        {
            
            if (slot == null)
            {
              
               break;
            }
        }
    }
    public void SaveEquippedArmor()
    {
        foreach (var slot in equippedarmor)
        {
            if (slot.transform.childCount > 0)
            {
                armoritem.Add(slot.GetComponentInChildren<DraggableItem>().Item);
                Debug.Log("yeah");
            }
        }

        playerData.armoritem = armoritem;
    }


    public void LoadEquippedArmor()
    {
      
            foreach (var slot in equippedarmor)
            {
                foreach (var item in playerData.armoritem)
                {
                    if (slot.acceptedItemType == item.itemtype )
                    {
                        SpawnItem(item,slot);
                      

                    }
                }
            }



    }
    public void GenererDay(Day Quest)
    {
        ambiance.clip = Quest.music;
        ambiance.loop = true;
        ambiance.Play();
        back.sprite = Quest.background;
        Sprite   lieu = meteo[UnityEngine.Random.Range(0, meteo.Count)];
        meteochange.sprite = lieu;
        actiondujour.text = Quest.histoire;
        playerData.redRubies = Quest.recrouge;
        playerData.blueRubies = Quest.prixbleue;
        if (Quest.typedequete == Day.DayType.Histoire)
        {
            
        }

        if (Quest.typedequete == Day.DayType.Combat)
        {
            UpdatePlayerData();
            attaquemob.color = Color.gray;
            defensemob.color = Color.gray;
            victoire.SetActive(false);
            defaite.SetActive(false);
            phrase.text = "";
            tourrecup = 0;
            dodging = false;
            mindbool = false;
            EnableAttackButton();
            namemonstre.text = Quest.name;
            healthmob.maxValue = Quest.bonusvie * 100;
            healthmob.value = Quest.bonusvie * 100;
            healthmonstre.text = Quest.bonusvie.ToString();
            degatmonstre.text = Quest.bonusdegat.ToString();
            dexhmonstre.text = Quest.bonusdexterité.ToString();
            reshmonstre.text = Quest.bonusresistance.ToString();
            inthmonstre.text = Quest.bonusintelligence.ToString();
            magiemonstre.text = Quest.bonusmagie.ToString();
            monstre.sprite = Quest.perso;
            monstreback.sprite = Quest.background;
            healthplay.text = playerData.health.ToString();
            degatplay.text = playerData.damage.ToString();
            dexplay.text = playerData.dexterity.ToString();
            respaly.text = playerData.resistance.ToString();
            intplay.text = playerData.intelligence.ToString();
            magieplay.text = playerData.magic.ToString();
            nameplay.text = playerData.playerName;
            combbackgr.sprite = Quest.background;
            playerim.sprite = imageequip.sprite;
            phrasemid.text = Quest.phrasecomb;
            heatlhplayer.maxValue = playerData.health * 100;
            heatlhplayer.value = playerData.health * 100;
          
            StartCoroutine(transition(Quest));

        }

        if (Quest.typedequete == Day.DayType.Marchand)
        {
            
        }

        if (Quest.typedequete == Day.DayType.Quete)
        {
            
        }

      







    }

    public void Acualise()
    {
        if (playerData != null) 
        {
       
            bonusDamage = 0;
            bonusHealth = 0;
            bonusDexterity = 0;
            bonusResistance = 0;
            bonusIntelligence = 0;
            bonusMagic = 0;

            foreach (var slot in equippedarmor)
            {
                if (slot.transform.childCount > 0)
                {
                    DraggableItem draggableItem = slot.GetComponentInChildren<DraggableItem>();
                    bonusDamage += draggableItem.Item.bonusdegat;
                    bonusHealth += draggableItem.Item.bonusvie;
                    bonusDexterity += draggableItem.Item.bonusdexterité;
                    bonusResistance += draggableItem.Item.bonusresistance;
                    bonusIntelligence += draggableItem.Item.bonusintelligence;
                    bonusMagic += draggableItem.Item.bonusmagie;
                }
            }

           
            playerData.damage = playerData.baseDamage + bonusDamage;
            playerData.health = playerData.baseHealth + bonusHealth;
            playerData.dexterity = playerData.baseDexterity + bonusDexterity;
            playerData.resistance = playerData.baseResistance + bonusResistance;
            playerData.intelligence = playerData.baseIntelligence + bonusIntelligence;
            playerData.magic = playerData.baseMagic + bonusMagic;

           
            intelligence.text = (playerData.baseIntelligence+ bonusIntelligence).ToString();
            sante.text = (playerData.baseHealth + bonusHealth).ToString();
            magie.text = (playerData.baseMagic+ bonusMagic).ToString();
            degat.text = (playerData.baseDamage+ bonusDamage).ToString();
            dexterité.text = (playerData.baseDexterity+ bonusDexterity).ToString();
            resistance.text = (playerData.baseResistance+ bonusResistance).ToString();
        }
        else
        {
            Debug.LogError("playerData is null.");
        }
    }
    public IEnumerator transition(Day Quest)
    {
        entreance.Play();
        namemob.text = Quest.name;
        nameplayer.text = playerData.playerName;
        ennemy.sprite = Quest.perso;
        perso.sprite = imageequip.sprite;
        trans.SetActive(true);
        yield return StartCoroutine(WaitForSeconds(3));
        trans.SetActive(false);
        combat.SetActive(true);
        if (int.Parse(dexhmonstre.text) > int.Parse(dexplay.text))
        {
            phrase.text = $"{Quest.name} est plus rapide il engage le combat";
            DisableAttackButton();
            mobattack();
            attaquemob.color = Color.red;
        }  
    }

    public void prendre()
    {
        AddItemToInventory(quete.recompense);
        combat.SetActive(false);
    }

    public void laisser()
    {
        combat.SetActive(false);
    }
     public void choice1()
    {
        
        croix1.SetActive(true);
        int jour1 = int.Parse(jour.text);
        jour1++;
        jour.text = jour1.ToString();
        GenererDay(quete.choix1);
        quete = quete.choix1;
        playerData.quete = quete.name;

    }

    public void choice2()
    {
        croix2.SetActive(true);
        int jour2 = int.Parse(jour.text);
        jour2++;
        jour.text = jour2.ToString();
       GenererDay(quete.choix2);
       quete = quete.choix2;
       playerData.quete = quete.name;
    }
    public void UpdatePlayerUI()
    {
        intelligence.text = (playerData.baseIntelligence+ bonusIntelligence).ToString();
        sante.text = (playerData.baseHealth + bonusHealth).ToString();
        magie.text = (playerData.baseMagic+ bonusMagic).ToString();
        degat.text = (playerData.baseDamage+ bonusDamage).ToString();
        dexterité.text = (playerData.baseDexterity+ bonusDexterity).ToString();
        resistance.text = (playerData.baseResistance+ bonusResistance).ToString();
        sante1.text = sante.text;
        degat1.text = degat.text;
        dexterité1.text = dexterité.text;
        resistance1.text = resistance.text;
        intelligence1.text = intelligence.text;
        magie1.text = magie.text;


    }
  
     public void Dice()
     {
         dicemonste = UnityEngine.Random.Range(1, 21);
         dice.SetActive(false);
         StartCoroutine(RollAndShowResult(dicemonste));
     }

     private IEnumerator RollAndShowResult(int randomValue)
     {
         diceanim.SetActive(true);
         yield return StartCoroutine(Roll());
         diceanim.SetActive(false);
         dice.SetActive(true);
         random.text = randomValue.ToString();
     }

     private IEnumerator Roll()
     {
         dicesong.Play();
         float randomWaitTime = UnityEngine.Random.Range(1.0f, 2.0f);
         yield return new WaitForSeconds(randomWaitTime);
     }
     public void Dicej()
     {
         dicescore = UnityEngine.Random.Range(1, 21);
         dice.SetActive(false);
         StartCoroutine(RollAndShowResultj(dicescore));
     }

     private IEnumerator RollAndShowResultj(int randomValue)
     {
         diceanim.SetActive(true);
         yield return StartCoroutine(Roll());
         diceanim.SetActive(false);
         dice.SetActive(true);
         random.text = randomValue.ToString();
     }
     

     public void attackj()
     {
         StartCoroutine(PlayerAttackSequence());
         DisableAttackButton();
     }

     private IEnumerator PlayerAttackSequence()
     {
         phrase.text = "Le joueur lance le de";
       
         Dicej();
         

      
         yield return StartCoroutine(WaitForSeconds(4)); 

   
         phrase.text = $"{quete.name} lance le de"; 
         Dice();
         yield return StartCoroutine(WaitForSeconds(3));
       
         AttackLogic();
         yield return StartCoroutine(WaitForSeconds(2));
         defensemob.color = Color.red;
         phrase.text = $"{quete.name} lance le de"; 
         Dice();
         yield return StartCoroutine(WaitForSeconds(4));
         phrase.text = "Le joueur lance le de";
         Dicej();
         yield return StartCoroutine(WaitForSeconds(3));
         Attmonstre();
         yield return StartCoroutine(WaitForSeconds(2));
         EnableAttackButton();
         attaquemob.color = Color.grey;
         defensemob.color = Color.grey;

     }

     public void mobattack()
     {
         StartCoroutine(Mobattack());
     }
     private IEnumerator Mobattack()
     {
         yield return StartCoroutine(WaitForSeconds(2));
         phrase.text = $"{quete.name} lance le de"; 
         Dice();
         yield return StartCoroutine(WaitForSeconds(4));
         phrase.text = "Le joueur lance le de";
         Dicej();
         yield return StartCoroutine(WaitForSeconds(3));
         Attmonstre();
         yield return StartCoroutine(WaitForSeconds(2));
         EnableAttackButton();
         tourrecup--;
         attaquemob.color = Color.grey;
         defensemob.color = Color.grey;
     }

     private IEnumerator WaitForSeconds(float seconds)
     {
         yield return new WaitForSeconds(seconds);
     }

     private IEnumerator End1()
     {
         StopCoroutine(PlayerAttackSequence());
         StopCoroutine(dodge());
         StopCoroutine(Cast());
         StopCoroutine(findweak());
         requiert.text = quete.recompense.requiert.ToString();
         bonusitemvie.text = $"+{quete.recompense.bonusvie}";
         bonusitemdam.text = $"+{quete.recompense.bonusdegat}";
         bonusitemdex.text = $"+{quete.recompense.bonusdexterité}";
         bonusitemres.text = $"+{quete.recompense.bonusresistance}";
         bonusitemint.text = $"+{quete.recompense.bonusintelligence}";
         bonusitemmag.text = $"+{quete.recompense.bonusmagie}";
         req.sprite = quete.recompense.itemImage;
         if (quete.recompense.typearme == Arme.autre)
         {
             requiert.text = "";
             imarc.SetActive(false);
             imbat.SetActive(false);
             imbouc.SetActive(false);
             imepee.SetActive(false);
             imhache.SetActive(false);
             immasse.SetActive(false);
         }
         if (quete.recompense.typearme == Arme.arc)
         {
             imarc.SetActive(true);
             imbat.SetActive(false);
             imbouc.SetActive(false);
             imepee.SetActive(false);
             imhache.SetActive(false);
             immasse.SetActive(false);
         }
         if (quete.recompense.typearme == Arme.baton)
         {
             imarc.SetActive(false);
             imbat.SetActive(true);
             imbouc.SetActive(false);
             imepee.SetActive(false);
             imhache.SetActive(false);
             immasse.SetActive(false);
         }
         if (quete.recompense.typearme == Arme.bouclier)
         {
             imarc.SetActive(false);
             imbat.SetActive(false);
             imbouc.SetActive(true);
             imepee.SetActive(false);
             imhache.SetActive(false);
             immasse.SetActive(false);
         }
         if (quete.recompense.typearme == Arme.sword)
         {
             imarc.SetActive(false);
             imbat.SetActive(false);
             imbouc.SetActive(false);
             imepee.SetActive(true);
             imhache.SetActive(false);
             immasse.SetActive(false);
         }
         if (quete.recompense.typearme == Arme.hache)
         {
             imarc.SetActive(false);
             imbat.SetActive(false);
             imbouc.SetActive(false);
             imepee.SetActive(false);
             imhache.SetActive(true);
             immasse.SetActive(false);
         }
         if (quete.recompense.typearme == Arme.hammer)
         {
             imarc.SetActive(false);
             imbat.SetActive(false);
             imbouc.SetActive(false);
             imepee.SetActive(false);
             imhache.SetActive(false);
             immasse.SetActive(true);
         }
         yield return new WaitForSeconds(1.5f);
         victoire.SetActive(true);
         playerData.damage -= randomboost;
     }

     private IEnumerator Defaite()
     {
         yield return new WaitForSeconds(1.5f);
         defaite.SetActive(true);
     }

     public void newgame()
     {
         
             PlayerPrefs.DeleteAll();
             SceneManager.LoadScene("Customize");
         
     }
     public void menut()
     {
         PlayerPrefs.DeleteAll();
         SceneManager.LoadScene("Menu");
     }
     

     private void Attmonstre()
     {
         if (dicescore <  dicemonste)
         {
             if (dodging && timedodge > 0)
             {
                 heatlhplayer.value -=(int) ((quete.bonusdegat * dicemonste) * 0.7);
                 phrase.text = $"{quete.name} inflige <color=red>{(int) ((quete.bonusdegat * dicemonste) * 0.7)}</color> de degats";
                 timedodge--;
                 
             }
             else
             {
                 heatlhplayer.value -= quete.bonusdegat * dicemonste;
                 phrase.text = $"{quete.name} inflige <color=red>{quete.bonusdegat * dicemonste}</color> de degats";
                 dexplay.text = $"<color=white>{playerData.dexterity}</color>";
                 dodging = false;
             }
             
            
             if (heatlhplayer.value <= heatlhplayer.maxValue / 2)
             {
                 phrasemid.text = quete.phraseplayer;
             }
             
             if (heatlhplayer.value <= 0)
             {
                 heatlhplayer.value = heatlhplayer.maxValue;
                 StartCoroutine(Defaite());

             }
             
         }
         else
         {
            healthmob.value -= playerData.resistance * dicemonste;
             phrase.text = $"le joueurse defent et {quete.name} recoit <color=red>{playerData.resistance * dicemonste}</color> de degats";
             if (healthmob.value <= healthmob.maxValue/2)
             {
                 phrasemid.text = quete.phrasejoueur;
             }

             if (dodging && timedodge > 0)
             {
                 timedodge--;
             }
             if (healthmob.value <= 0)
             {
                 heatlhplayer.value = heatlhplayer.maxValue;
                 StartCoroutine(End1());

             }
         }
     }
     private void AttackLogic()
     {
         if (dicescore > dicemonste)
         {
             healthmob.value -= playerData.damage * dicescore;
             phrase.text = $"Le joueur inflige <color=red>{playerData.damage * dicescore}</color> de degats";
             if (healthmob.value <= healthmob.maxValue/2)
             {
                 phrasemid.text = quete.phrasejoueur;
             }
             if (healthmob.value <= 0)
             {
               heatlhplayer.value = heatlhplayer.maxValue;
                 StartCoroutine(End1());
            
                 
             }
         }
         else
         {
             heatlhplayer.value -= quete.bonusresistance * dicescore;
             phrase.text = $"{quete.name} se defent et le joueur recoit <color=red>{quete.bonusresistance * dicescore}</color> de degats";
             if (heatlhplayer.value <= heatlhplayer.maxValue / 2)
             {
                 phrasemid.text = quete.phraseplayer;
             }
             if (heatlhplayer.value <= 0)
             {
                 heatlhplayer.value = heatlhplayer.maxValue;
                 StartCoroutine(Defaite());
             }
         }
         
     
     } 
     public void DisableAttackButton()
     {
         attackButton.interactable = false;
         dodgeButton.interactable = false;
         mindButton.interactable = false;
         castButton.interactable = false; 
     }

     public void EnableAttackButton()
     {
        
         mindButton.interactable = true;
         attackButton.interactable = true;
         dodgeButton.interactable = true;
         castButton.interactable = true;
       
         if (mindbool)
         {
             mindButton.interactable = false;
         }

         if (dodging)
         {
             dodgeButton.interactable = false;
             
         }
     }

     public IEnumerator findweak()
     {
         
         phrase.text = "Vous lancez le de pour essayer de trouver une faiblesse.";
         Dicej();
         yield return StartCoroutine(WaitForSeconds(3));
         if (dicescore <= playerData.intelligence * 2)
         {
             randomboost = Random.Range(1, 4);
             phrase.text = $"Vous avez trouver une faiblesse votre attaque a un bonus de <color=green>+{randomboost}</color>.";
             
             playerData.damage += randomboost;
             degatplay.text = $"<color=green> {playerData.damage.ToString()} </color>";
             mindbool = true;
         }
         else
         {
             phrase.text = $"Vous ne trouvez aucune faiblesse chez {quete.name} il contre attaque";
             attaquemob.color = Color.red;
         }

         yield return StartCoroutine(WaitForSeconds(3));
         
         phrase.text = $"{quete.name} lance le de";
         Dice();
         yield return StartCoroutine(WaitForSeconds(3));
         contreattaque();
         EnableAttackButton();
         attaquemob.color = Color.gray;
         defensemob.color = Color.gray;
         tourrecup--;
     }

     public void mind()
     { 
         DisableAttackButton();
         StartCoroutine(findweak());
        
     }

     public void Dodge()
     {
         DisableAttackButton();
         StartCoroutine(dodge());
     }

     public void contreattaque()
     {
         
         if (dodging && timedodge > 0)
         {
             if (mag)
             {
                 heatlhplayer.value -=(int) (((quete.bonusdegat * dicemonste) * 0.7)*1.5);
                 phrase.text = $"{quete.name} inflige <color=red>{(int) (((quete.bonusdegat * dicemonste) * 0.7)*1.5)}</color> de degats";
                 timedodge--;
             }
             else
             {
                 heatlhplayer.value -= (int)((quete.bonusdegat * dicemonste) * 0.7);
                 phrase.text =
                     $"{quete.name} inflige <color=red>{(int)((quete.bonusdegat * dicemonste) * 0.7)}</color> de degats";
                 timedodge--;
             }
         }
         else if (mag)
         {
             heatlhplayer.value -= (int)(quete.bonusdegat * dicemonste * 1.5);
             phrase.text = $"{quete.name} inflige <color=red>{(int)(quete.bonusdegat * dicemonste * 1.5)}</color> de degats";
             dexplay.text = $"<color=white>{playerData.dexterity}</color>";
             dodging = false;
         }
         else
         {
             heatlhplayer.value -= quete.bonusdegat * dicemonste;
             phrase.text = $"{quete.name} inflige <color=red>{quete.bonusdegat * dicemonste}</color> de degats";
             dexplay.text = $"<color=white>{playerData.dexterity}</color>";
             dodging = false;
         }
         if (heatlhplayer.value <= heatlhplayer.maxValue / 2)
         {
             phrasemid.text = quete.phraseplayer;
         }
         if (heatlhplayer.value <= 0)
         {
             heatlhplayer.value = heatlhplayer.maxValue;
             StartCoroutine(Defaite());

         }

         
     }

     public IEnumerator dodge()
     {
         phrase.text = "Vous tentez une esquive.";
         Dicej();
         yield return WaitForSeconds(3);
         if (playerData.dexterity * 2 >= dicescore)
         {
             phrase.text = "Vous avez reussis votre esquive pendant 2 attaque vous recevez <color=green>-30%</color> de degats";
             dodging = true;
             timedodge = 2;
             tourrecup = cooldown;
             dexplay.text = $"<color=green>{playerData.dexterity}</color>";
         }
         else
         {
             phrase.text = "Vous rater votre esquive";
             tourrecup = 0;
         }

         yield return WaitForSeconds(3);
         attaquemob.color = Color.red;
         phrase.text = $"{quete.name} attaque !!";
         Dice();
         yield return WaitForSeconds(3);
         contreattaque();
         EnableAttackButton();
         attaquemob.color = Color.gray;
         defensemob.color = Color.gray;
         tourrecup--;
     }

     public void restartstat()
     {
         dodging = false;
         timedodge = 2;
     }

     public IEnumerator Cast()
     {
         phrase.text = "Vous essayer D'incanter un sort puissant.";
         Dicej();
         yield return WaitForSeconds(3);
         if (dicescore < playerData.magic)
         {
             phrase.text =
                 $"Vous lancez un sort puissant et faites <color=red> {dicescore * playerData.magic * playerData.intelligence} </color> de degats";
             healthmob.value -= dicescore * playerData.magic * playerData.intelligence;
             if (healthmob.value <= 0)
             {
                 heatlhplayer.value = heatlhplayer.maxValue;
                 StartCoroutine(End1());

             }
         }
         else
         {
             phrase.text = "Votre rater votre incantation.";
             mag = true;
         }

         yield return WaitForSeconds(3);
         attaquemob.color = Color.red;
         phrase.text = $"{quete.name} contre attaque.";
         Dice();
         yield return WaitForSeconds(3);
         contreattaque();
         yield return WaitForSeconds(2);
         EnableAttackButton();
         attaquemob.color = Color.gray;
         defensemob.color = Color.gray;
         mag = false;
     }

     public void cast()
     {
         DisableAttackButton();
         StartCoroutine(Cast());
     }
}   
