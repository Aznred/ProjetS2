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
    public inventoryslot[] deckslot;
    public Sprite vendu;
    public AudioSource soundtouch;
    private int choix = 0;
    public TMP_Text Choix1act;
    public TMP_Text Choix2act;
    public GameObject choix1;
    public GameObject choix2;
    public GameObject choix3;
    public GameObject continuer;
    private int index = 0;
    public GameObject Histoire;
    public TMP_Text Dialoguepnj;
    public TMP_Text Dialoguejoueur;
    public Image pnj;
    public Image persohist;
    public TMP_Text namejoueur;
    public TMP_Text namepnj;
    public Image Transparent;
    public TMP_Text Marketrubyred;
    public TMP_Text Marketrubybleu;
    public GameObject Market;
    public Button Item1;
    public Button Item2;
    public Button Item3;
    public Button Item4;
    public TMP_Text healthstatitem1;
    public TMP_Text damagestatitem1;
    public TMP_Text dexteritystatitem1;
    public TMP_Text resistancestatitem1;
    public TMP_Text intelligencestatitem1;
    public TMP_Text magicstatitem1;
    public TMP_Text healthstatitem2;
    public TMP_Text damagestatitem2;
    public TMP_Text dexteritystatitem2;
    public TMP_Text resistancestatitem2;
    public TMP_Text intelligencestatitem2;
    public TMP_Text magicstatitem2;
    public TMP_Text healthstatitem3;
    public TMP_Text damagestatitem3;
    public TMP_Text dexteritystatitem3;
    public TMP_Text resistancestatitem3;
    public TMP_Text intelligencestatitem3;
    public TMP_Text magicstatitem3;
    public TMP_Text healthstatitem4;
    public TMP_Text damagestatitem4;
    public TMP_Text dexteritystatitem4;
    public TMP_Text resistancestatitem4;
    public TMP_Text intelligencestatitem4;
    public TMP_Text magicstatitem4;
    public TMP_Text nommarcand;
    public Image imMarchand;

    public List<Item> ArmorList = new List<Item>();
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

    public PlayerData playerData;
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
    public GameObject pageinv;
    public List<inventoryslot> skillinventorymelee;
    public List<inventoryslot> skillinventorymage;
    public List<inventoryslot> skillinventoryarc;
    public List<inventoryslot> skillinventoryshield;
    public List<inventoryslot> skillinventorybuff;
    public List<Item> skilldata;
    public List<inventoryslot> Deck;
    private void Awake()
    {
        pageinv.SetActive(true);
        LoadPlayerData();
        
        pageinv.SetActive(false);
    }

        private void Start()
        {
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
        playerData.deck.Clear();
        playerData.arminv.Clear();
        playerData.invstr.Clear();
        playerData.skillnames.Clear();
        playerData.decknames.Clear();
        playerData.quete = quete.name; 
      
        foreach (var slot in equippedarmor)
        {
            if (slot.transform.childCount > 0)
            {
                
                DraggableItem itemInSlot = slot.GetComponentInChildren<DraggableItem>();
                if (itemInSlot != null)
                {
                    playerData.arminv.Add(itemInSlot.Item.name);
                  
                }
                
            }
        }

        foreach (var slot in Deck)
        {
            if (slot.transform.childCount > 0)
            {
                
                DraggableItem itemInSlot = slot.GetComponentInChildren<DraggableItem>();
                if (itemInSlot != null)
                {
                    playerData.decknames.Add(itemInSlot.Item.name);
                  
                }
                
            }
        }
        
  
        foreach (inventoryslot slot in deckslot)
        {
            DraggableItem itemInSlot = slot.GetComponentInChildren<DraggableItem>();
            if (itemInSlot != null)
            {
                
                playerData.skillnames.Add(itemInSlot.Item.name);
               
            }
        }
      
       

        foreach (inventoryslot slot in Inventoryslots)
        {
            DraggableItem itemInSlot = slot.GetComponentInChildren<DraggableItem>();
            if (itemInSlot != null)
            {
                
                playerData.invstr.Add(itemInSlot.Item.name);
               
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
                   
                    foreach (var ele in dataitem)
                    {  
                        if (name== ele.name)
                        {
                        
                       
                            if (slot.acceptedItemType == ele.itemtype && slot.transform.childCount < 1)
                            {
                               
                                SpawnItem(ele,slot);
                                
                               
                            }
                        }
                    }
                
                }
            
            }

            foreach (var name in playerData.decknames)
            {
               
                foreach (var slot in Deck)
                {
                    DraggableItem itemInSlot = slot.GetComponentInChildren<DraggableItem>();
                    if (itemInSlot != null && itemInSlot.Item.name == name)
                    {
                        Destroy(itemInSlot.gameObject);
                    }
                }

                
                foreach (var ele in skilldata)
                {
                    if (name == ele.name)
                    {
                       
                        foreach (var slot in Deck)
                        {
                            DraggableItem itemInSlot = slot.GetComponentInChildren<DraggableItem>();
                            if (itemInSlot == null)
                            {
                                SpawnItem(ele, slot);
                                break;
                            }
                        }
                    }
                }
            }
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
                    ArmorList.Add(draggableItem.Item);
                    bonusDamage += draggableItem.Item.bonusdegat;
                    bonusHealth += draggableItem.Item.bonusvie;
                    bonusDexterity += draggableItem.Item.bonusdexterité;
                    bonusResistance += draggableItem.Item.bonusresistance;
                    bonusMagic += draggableItem.Item.bonusmagie;
                    bonusIntelligence += draggableItem.Item.bonusintelligence;
                }
            }

            playerData.baseDamage = playerData.damage - bonusDamage;
            playerData.baseHealth = playerData.health - bonusHealth;
            playerData.baseDexterity = playerData.dexterity - bonusDexterity;
            playerData.baseResistance = playerData.resistance - bonusResistance;
            playerData.baseIntelligence = playerData.intelligence- bonusIntelligence;
            playerData.baseMagic = playerData.magic -bonusMagic;

            playerData.damage = playerData.baseDamage + bonusDamage;
            playerData.health = playerData.baseHealth + bonusHealth;
            playerData.dexterity = playerData.baseDexterity + bonusDexterity;
            playerData.resistance = playerData.baseResistance + bonusResistance;
            playerData.intelligence = playerData.baseIntelligence + bonusIntelligence;
            playerData.magic = playerData.baseMagic + bonusMagic;
         
            playerNameText.text = playerData.playerName;
            epee.text = playerData.epee.ToString();
            arc.text = playerData.arc.ToString();
            hache.text = playerData.hache.ToString();
            baton.text = playerData.baton.ToString();
            bouclier.text = playerData.bouclier.ToString();
            massue.text = playerData.massue.ToString();
           
            rubybleu.text = playerData.blueRubies.ToString();
            rubyred.text = playerData.redRubies.ToString();
            jour.text = playerData.jour.ToString();
            total.text = (playerData.redRubies + playerData.blueRubies).ToString();
            pointarme.text = playerData.pointarme.ToString();
            pointstat.text = playerData.pointstat.ToString();
            
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
               
                foreach (var ele in dataitem)
                {
                    
                    if (name== ele.name)
                    {
                        AddItemToInventory(ele);
                    }
                }
                
            }

            foreach (var name in playerData.skillnames)
            {
                foreach (var ele in skilldata)
                {
                    if (name == ele.name)
                    {
                        AddToDeck(ele);
                       
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

    public void AddToDeck(Item item)
    {
        for (int i = 0; i < deckslot.Length; i++)
        {
            inventoryslot slot = deckslot[i];
            DraggableItem itemInSlot = slot.GetComponentInChildren<DraggableItem>();
            if (itemInSlot != null && itemInSlot.Item == item)
            {
     
                return;
            }

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
        
        Choix1act.text = Quest.choix_1;
        Choix2act.text = Quest.choix_2;
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
            UpdatePlayerData();
            Histoire.SetActive(true);
            Dialoguejoueur.text = string.Empty;
            Dialoguepnj.text = string.Empty;
            index = 0;
            choix1.SetActive(true);
            choix2.SetActive(true);
            choix3.SetActive(true);
            continuer.SetActive(false);
            choix1.GetComponent<Button>().interactable = false;
            choix2.GetComponent<Button>().interactable = false;
            choix3.GetComponent<Button>().interactable = false;
            StartCoroutine(typeline(Quest.Firstdialogue,Dialoguepnj,0.025f));
          
            
            choix1.GetComponent<Button>().GetComponentInChildren<TMP_Text>().text = Quest.act1[0];
            choix2.GetComponent<Button>().GetComponentInChildren<TMP_Text>().text = Quest.act2[0];

            choix3.GetComponent<Button>().GetComponentInChildren<TMP_Text>().text = Quest.act3[0];
            namejoueur.text = playerData.playerName;
            namepnj.text = Quest.name;
            persohist.sprite = imageequip.sprite;
            pnj.sprite = Quest.perso;
            
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
            Market.SetActive(true);
            UpdatePlayerData();
            UpdateThunes();
            nommarcand.text = Quest.name;
            imMarchand.sprite = Quest.perso;
            Item1.image.sprite = Quest.marché[0].itemImage;
            Item2.image.sprite = Quest.marché[1].itemImage;
            Item3.image.sprite = Quest.marché[2].itemImage;
            Item4.image.sprite = Quest.marché[3].itemImage;
            Item1.GetComponentInChildren<TMP_Text>().text = Quest.prix[0].ToString();
            Item2.GetComponentInChildren<TMP_Text>().text = Quest.prix[1].ToString();
            Item3.GetComponentInChildren<TMP_Text>().text = Quest.prix[2].ToString();
            Item4.GetComponentInChildren<TMP_Text>().text = Quest.prix[3].ToString();
            healthstatitem1.text = Quest.marché[0].bonusvie.ToString();
            damagestatitem1.text = Quest.marché[0].bonusdegat.ToString();
            dexteritystatitem1.text = Quest.marché[0].bonusdexterité.ToString();
            resistancestatitem1.text = Quest.marché[0].bonusresistance.ToString();
            intelligencestatitem1.text = Quest.marché[0].bonusintelligence.ToString();
            magicstatitem1.text = Quest.marché[0].bonusmagie.ToString();
            healthstatitem2.text = Quest.marché[1].bonusvie.ToString();
            damagestatitem2.text = Quest.marché[1].bonusdegat.ToString();
            dexteritystatitem2.text = Quest.marché[1].bonusdexterité.ToString();
            resistancestatitem2.text = Quest.marché[1].bonusresistance.ToString();
            intelligencestatitem2.text = Quest.marché[1].bonusintelligence.ToString();
            magicstatitem2.text = Quest.marché[1].bonusmagie.ToString();
            healthstatitem3.text = Quest.marché[2].bonusvie.ToString();
            damagestatitem3.text = Quest.marché[2].bonusdegat.ToString();
            dexteritystatitem3.text = Quest.marché[2].bonusdexterité.ToString();
            resistancestatitem3.text = Quest.marché[2].bonusresistance.ToString();
            intelligencestatitem3.text = Quest.marché[2].bonusintelligence.ToString();
            magicstatitem3.text = Quest.marché[2].bonusmagie.ToString();
            healthstatitem4.text = Quest.marché[3].bonusvie.ToString();
            damagestatitem4.text = Quest.marché[3].bonusdegat.ToString();
            dexteritystatitem4.text = Quest.marché[3].bonusdexterité.ToString();
            resistancestatitem4.text = Quest.marché[3].bonusresistance.ToString();
            intelligencestatitem4.text = Quest.marché[3].bonusintelligence.ToString();
            magicstatitem4.text = Quest.marché[3].bonusmagie.ToString();
        }

        if (Quest.typedequete == Day.DayType.Quete)
        {
            
        }

      







    }
  

    IEnumerator typeline(string lines, TMP_Text tmp, float speed)
    { soundtouch.Play();
        foreach (var c in lines.ToCharArray())
        {
            
            tmp.text += c;
            yield return new WaitForSeconds(speed);
           
        }
        choix1.GetComponent<Button>().interactable = true;
        choix2.GetComponent<Button>().interactable = true;
        choix3.GetComponent<Button>().interactable = true;
        soundtouch.Stop();
    }

    public void Dialogue1()
    {
        choix = 1;
        Dialoguejoueur.text = string.Empty;
        Dialoguepnj.text = string.Empty;
        choix1.SetActive(false);
        choix2.SetActive(false);
        choix3.SetActive(false);
        continuer.SetActive(true);
        continuer.GetComponent<Button>().interactable = false;
        StartCoroutine(typelinetext(quete.Choixdial1[index], Dialoguepnj, 0.025f,1,Dialoguejoueur));
      
    }
    public void Dialogue2()
    {
        choix = 2;
        Dialoguejoueur.text = string.Empty;
        Dialoguepnj.text = string.Empty;
        choix1.SetActive(false);
        choix2.SetActive(false);
        choix3.SetActive(false);
        continuer.SetActive(true);
        continuer.GetComponent<Button>().interactable = false;
        StartCoroutine(typelinetext(quete.Choixdial2[index], Dialoguepnj, 0.025f,2,Dialoguejoueur));
    
    }
    public void Dialogue3()
    {
        choix = 3;
        Dialoguejoueur.text = string.Empty;
        Dialoguepnj.text = string.Empty;
        choix1.SetActive(false);
        choix2.SetActive(false);
        choix3.SetActive(false);
        continuer.SetActive(true);
        continuer.GetComponent<Button>().interactable = false;
        StartCoroutine(typelinetext(quete.choixdial3[index], Dialoguepnj, 0.025f,3,Dialoguejoueur));
   
    }

    public void Continuer()
    {
        Dialoguepnj.text = string.Empty;
      
        continuer.GetComponent<Button>().interactable = false;
        StartCoroutine(typelinecontinuer(quete.choixdial3, Dialoguepnj, 0.025f,choix));
       
    }
    IEnumerator typelinetext(string lines, TMP_Text tmp, float speed, int num,TMP_Text jou)
    {soundtouch.Play();
        switch (num)
        {
            case 1:
                foreach (var s in quete.act1[1])
                {  
                    jou.text += s;
                    yield return new WaitForSeconds(speed);
                   
                }
                break;
            case 2:
                foreach (var s in quete.act2[1])
                {  
                    jou.text += s;
                    yield return new WaitForSeconds(speed);
                    
                }
                break;
            case 3:
                foreach (var s in quete.act3[1])
                {  
                    jou.text += s;
                    yield return new WaitForSeconds(speed);
                  
                }
                break;
        }
        foreach (var c in lines.ToCharArray())
        { 
            tmp.text += c;
            yield return new WaitForSeconds(speed);
           
        }

        index++;
        continuer.GetComponent<Button>().interactable = true;
        soundtouch.Stop();
    }
    IEnumerator typelinecontinuer(string[] lines, TMP_Text tmp, float speed, int num)
    { soundtouch.Play();
        
        switch (num)
        {
            case 1:
                lines = quete.Choixdial1;
                if (quete.dial && index >= lines.Length)
                {
                    GenererDay(quete.choix1);
                    quete = quete.choix1;
                }
                else if (index >= lines.Length)
                {
                    Histoire.SetActive(false);
                    GenererDay(quete.choix1);
                    quete = quete.choix1;
                  
                    jour.text = playerData.jour.ToString();
                    
                }
                else
                {
                    
                    foreach (var c in lines[index].ToCharArray())
                    {  
                        tmp.text += c;
                        yield return new WaitForSeconds(speed);
                    
                    }
                   
                } break;
               
            case 2:
                lines = quete.Choixdial2;
                if (quete.dial && index >= lines.Length)
                {
                    GenererDay(quete.choix2); quete = quete.choix2;
                    
                }
                else if (index >= lines.Length)
                {Histoire.SetActive(false);
                    GenererDay(quete.choix2);
                    quete = quete.choix2;
                    
                    
                }
                else
                {
                   
                    foreach (var c in lines[index].ToCharArray())
                    { 
                        tmp.text += c;
                        yield return new WaitForSeconds(speed);
                    
                    }
                    
                }break;
               
            
            case 3:
                lines = quete.choixdial3;
                if (quete.dial && index >= lines.Length)
                {
                   GenererDay(quete.choix3);
                   quete = quete.choix3;
                }
                else if (index >= lines.Length)
                {
                    Histoire.SetActive(false);
                    GenererDay(quete.choix3);
                    quete = quete.choix3;
                   
                   
                }
                else
                {
                    foreach (var c in lines[index].ToCharArray())
                    {  
                        tmp.text += c;
                        yield return new WaitForSeconds(speed);
                   
                    }
                    
                }
                break;
               
        }
        

        index++;
        continuer.GetComponent<Button>().interactable = true;
        soundtouch.Stop();
    }
    public void Achat1()
    {
        if (playerData.redRubies >= quete.prix[0])
        {
            Item1.enabled = false;
            AddItemToInventory(quete.marché[0]);
            playerData.redRubies -= quete.prix[0];
            UpdateThunes();
            Item1.image.sprite = vendu;
           
        }


    }
    public void Achat2()
    {
        if (playerData.redRubies >=quete.prix[1])
        {Item2.enabled = false;
            AddItemToInventory(quete.marché[1]);
            playerData.redRubies -= quete.prix[1];
            Item2.image.sprite = vendu;
            UpdateThunes();
            
        }


    }
    public void Achat3()
    {
        if (playerData.blueRubies >= quete.prix[2])
        {Item3.enabled = false;
            AddItemToInventory(quete.marché[2]);
            playerData.blueRubies -= quete.prix[2];
            Item3.image.sprite = vendu;
            UpdateThunes();
            
        }


    }
    public void Achat4()
    {
        if (playerData.blueRubies >= quete.prix[3])
        {Item4.enabled = false;
            AddItemToInventory(quete.marché[3]);
            playerData.blueRubies -= quete.prix[3];
            Item4.image.sprite = vendu;
            UpdateThunes();
            
        }


    }

    public void ExitMarket()
    {
        Market.SetActive(false);
    }

    public void UpdateThunes()
    {
        rubybleu.text = playerData.blueRubies.ToString();
        rubyred.text = playerData.redRubies.ToString();
        Marketrubybleu.text = playerData.blueRubies.ToString();
        Marketrubyred.text = playerData.redRubies.ToString();
    }

   public void Actualize()
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
                    ArmorList.Add(draggableItem.Item);
                }
            }

            foreach (var ele in ArmorList)
            {
               
                bonusDamage += ele.bonusdegat;
                bonusHealth += ele.bonusvie;
                bonusDexterity += ele.bonusdexterité;
                bonusResistance += ele.bonusresistance;
                bonusIntelligence += ele.bonusintelligence;
                bonusMagic += ele.bonusmagie;
            }

            playerData.damage = playerData.baseDamage + bonusDamage;
            playerData.health = playerData.baseHealth + bonusHealth;
            playerData.dexterity = playerData.baseDexterity + bonusDexterity;
            playerData.resistance = playerData.baseResistance + bonusResistance;
            playerData.intelligence = playerData.baseIntelligence + bonusIntelligence;
            playerData.magic = playerData.baseMagic + bonusMagic;

           
  
        }
        intelligence.text = ( playerData.baseIntelligence + bonusIntelligence).ToString();
        sante.text = (playerData.baseHealth + bonusHealth).ToString();
        magie.text = (playerData.baseMagic + bonusMagic).ToString();
        degat.text = (playerData.baseDamage + bonusDamage).ToString();
        dexterité.text = (playerData.baseDexterity + bonusDexterity ).ToString();
        resistance.text = (playerData.baseResistance + bonusResistance).ToString();
      
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
