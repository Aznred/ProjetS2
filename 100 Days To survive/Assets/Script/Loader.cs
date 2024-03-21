using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEditor;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;


[Serializable]
[SerializeField]
public class Loader : MonoBehaviour
{
    private List<Ennemy> _ennemieslist = new List<Ennemy>();
    private bool endcombat = false;
    public List<Combatant> combatants = new List<Combatant>();
    private Queue<Combatant> turnQueue;

    public TMP_Text textcombat;
    private string attack;
    private int EnemyChoice;
    public List<Item> attacklist;
    public List<GameObject> boucliermdr;
    public List<Button> Deckbutton;
    public GameObject DeckCombat;
    public List<Item> AttackCapacity;
    public List<Item> DebufCapacity;
    public List<Item> BuffCapacity;
    public List<GameObject> bouclierlist;
    public List<Image> combatlist;
    public List<Slider> combathealth;
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
                                playerData.damage -= ele.bonusdegat;
                                playerData.health -= ele.bonusvie;
                                playerData.dexterity -= ele.bonusdexterité;
                                playerData.resistance -= ele.bonusresistance;
                                playerData.intelligence -= ele.bonusintelligence;
                                playerData.magic -= ele.bonusmagie;
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
           
            endcombat = false;
            textcombat.text = "";
            Item spell = null;
            combat.SetActive(true);
            for (int k = 0; k < playerData.decknames.Count; k++)
            {
                
                foreach (var s in skilldata)
                {
                    if (s.name == playerData.decknames[k])
                    {
                        spell = s;
                        attacklist.Add(s);
                        Deckbutton[k].image.sprite = spell.itemImage;
                        Deckbutton[k].GetComponentInChildren<TMP_Text>().text = spell.itemName;
                        Deckbutton[k].gameObject.SetActive(true);
                    }
                    
                }
               
            }

            foreach (var e in boucliermdr)
            {
                e.SetActive((false));
            }
            DeckCombat.SetActive(true);
            int j = 0;
            int i = 0;
            UpdatePlayerData();
            combatlist[4].sprite = imageequip.sprite;
            combathealth[4].maxValue = playerData.health * 10;   
            combathealth[4].value = playerData.health * 10;
            bouclierlist[3].SetActive(false);
            bouclierlist[5].SetActive(false);
           
            foreach (var e in Quest.Ennemies)
            {
                
                if (e.type == Ennemy.EnemyType.Enemy)
                {
                    i++;
                   _ennemieslist.Add(e);
                    switch (i)
                    {
                        case 1:
                            combatlist[1].sprite = e.Mobimage;
                            combatlist[7].sprite = e.Mobimage;
                            combathealth[1].maxValue = e.Health * 10;   
                            combathealth[1].value = e.Health * 10;
                            bouclierlist[0].SetActive(false);
                            bouclierlist[2].SetActive(false);
                           
                            break;
                        case 2:
                            combatlist[6].sprite = e.Mobimage;
                            combatlist[0].sprite = e.Mobimage;
                            combathealth[0].maxValue = e.Health * 10;   
                            combathealth[0].value = e.Health * 10;
                            bouclierlist[0].SetActive(true);
                          
                            break;
                        case 3:
                            combatlist[8].sprite = e.Mobimage;
                            combatlist[2].sprite = e.Mobimage;
                            combathealth[2].maxValue = e.Health * 10;   
                            combathealth[2].value = e.Health * 10;
                            bouclierlist[2].SetActive(true);
                          
                            break;
                    }
                }
                else
                {
                    j++;
                    switch (i)
                    {
                        
                          
                        case 1:
                            combatlist[3].sprite = e.Mobimage;
                            combathealth[3].maxValue = e.Health * 10;   
                            combathealth[3].value = e.Health * 10;
                            bouclierlist[3].SetActive(true);
                            bouclierlist[5].SetActive(false);
                            break;
                        case 2:
                            combatlist[5].sprite = e.Mobimage;
                            combathealth[5].maxValue = e.Health * 10;   
                            combathealth[5].value = e.Health * 10;
                            bouclierlist[3].SetActive(true);
                            bouclierlist[5].SetActive(true);
                            break;
                    }
                }
            }
            victoire.SetActive(false);
            defaite.SetActive(false);
           
        
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

     private IEnumerator Wait()
     {
         yield return WaitForSeconds(5);
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
     

   
   

  

     private IEnumerator WaitForSeconds(float seconds)
     {
         yield return new WaitForSeconds(seconds);
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
        private void EnnemyAttack(int E,string spell,Ennemy A)
    {
        throw new NotImplementedException();
    }

    private void EnnemyAttackPlayer(string spell,Ennemy A)
    {
        StartCoroutine(Coup(2,1,A));
    }

    private void EnnemyBuff(int E,string spell,Ennemy A)
    {
        StartCoroutine(Health(1,E,A));
    }

    private void EnnemyDebuffPlayer(string spell,Ennemy A)
    {
        StartCoroutine(Coup(2,1,A));
    }
    
    private void EnnemyDebuff(int E,string spell,Ennemy A)
    {
        throw new NotImplementedException();
    }
    
    public void EnnemyActionChoice(Ennemy ennemy)
    {
        List<Ennemy> enemies = new List<Ennemy>();
        List<Ennemy> allies = new List<Ennemy>();
        foreach (var E in quete.Ennemies)
        {
            if (E.type == Ennemy.EnemyType.Ally)
            {
                allies.Add(E);
            }
            else
            {
                enemies.Add(E);
            }
        }
        int l_e = enemies.Count;
        int r_e = Random.Range(0, l_e);
        int l_a = allies.Count+1;
        int r_a = Random.Range(0, l_a);
        int sr = Random.Range(0, ennemy.deck.Length);
        foreach (var s in skilldata)
        {
            if (s.name== ennemy.deck[sr])
            {
                switch (s.spelltype)
                {
                    case capicitytype.Buff:
                        EnnemyBuff(r_e,s.name,ennemy);
                        break;


                    case capicitytype.Debuff:
                        switch (r_a)
                        {
                            case 0:
                                EnnemyDebuffPlayer(s.name,ennemy);
                                break;
                            case 1:
                                EnnemyDebuff(3,s.name,ennemy);
                                break;
                            case 2:
                                EnnemyDebuff(5,s.name,ennemy);
                                break;
                        }

                        break;
                    case capicitytype.Attack:
                        switch (r_a)
                        {
                            case 0:
                                EnnemyAttackPlayer(s.itemName,ennemy);
                                break;
                            case 1:
                                EnnemyAttack(3,s.itemName,ennemy);
                                break;
                            case 2:
                                EnnemyAttack(5,s.itemName,ennemy);
                                break;
                        }
                        break;
                }
            }
        }
    }

    private IEnumerator Coup(int player,int ennemy,Ennemy attaquant)
    {
        int j = 0;
        int i = 0;
        switch (player)
        {
            case 0:
               Dicej();
               yield return WaitForSeconds(2.5f);
               if (dicescore == 20)
               {
                   textcombat.text = $"{playerData.playerName} utilise coup\n" + $"Le score du dé est de <color=yellow>{dicescore}</color>\n" + "C'est une réussite critique"; 
                   combathealth[ennemy].value -= (int)(playerData.damage * 5);
                   
                 
                   
               }
               else if (dicescore == 1)
               {
                   textcombat.text = $"{playerData.playerName} utilise coup\n" + $"Le score du dé est de <color=purple>{dicescore}</color>\n" + "C'est un échec critique"; 
                   combathealth[4].value -= (int)(playerData.damage * 2.5);
                 
                  
                  
               }
               else if (dicescore >=10)
               {
                   textcombat.text = $"{playerData.playerName} utilise coup\n" + $"Le score du dé est de <color=green>{dicescore}</color>\n" + "C'est une réussite"; 
                   combathealth[ennemy].value -= (int)(playerData.damage * 2.5);
                   
                  
               }
               else
               {
                   textcombat.text = $"{playerData.playerName} utilise coup\n" + $"Le score du dé est de <color=red>{dicescore}</color>\n" + "C'est un échec"; 
               }
               foreach (var B in Deckbutton)
               {
                   B.interactable = false;
               }
               StartCoroutine( Turn());

              
               
               
                break;
            case 1:
                yield return WaitForSeconds(2.5f);
                Dice();
                yield return WaitForSeconds(2.5f);

                if (dicemonste == 20)
                {
                    textcombat.text = $"{attaquant.name} utilise coup\n" + $"Le score du dé est de <color=yellow>{dicemonste}</color>\n" + "C'est une réussite critique"; 
                    combathealth[ennemy].value -= (int)(attaquant.Damage* 5);
                }
                else if (dicemonste == 1)
                {
                    textcombat.text = $"{attaquant.name} utilise coup\n" + $"Le score du dé est de <color=purple>{dicemonste}</color>\n" + "C'est un échec critique"; 
                    combathealth[i].value -= (int)(attaquant.Damage* 2.5);
                }
                else if (dicemonste >= 10)
                {
                    textcombat.text = $"{attaquant.name} utilise coup\n" + $"Le score du dé est de <color=green>{dicemonste}</color>\n" + "C'est une réussite"; 
                    combathealth[ennemy].value -= (int)(attaquant.Damage * 2.5);
                }
                else
                {
                    textcombat.text = $"{attaquant.name} utilise coup\n" + $"Le score du dé est de <color=red>{dicemonste}</color>\n" + "C'est un échec"; 
                }
               
      
                break;
            case 2:
                yield return WaitForSeconds(2.5f);
                Dice();
                yield return WaitForSeconds(2.5f);

                if (dicemonste == 20)
                {
                    textcombat.text = $"{attaquant.name} utilise coup\n" + $"Le score du dé est de <color=yellow>{dicemonste}</color>\n" + "C'est une réussite critique"; 
                    combathealth[4].value -= (int)(attaquant.Damage * 5);
                }
                else if (dicemonste == 1)
                {
                    textcombat.text = $"{attaquant.name} utilise coup\n" + $"Le score du dé est de <color=purple>{dicemonste}</color>\n" + "C'est un échec critique"; 
                    combathealth[i].value -= (int)(attaquant.Damage* 2.5);
                }
                else if (dicemonste >= 10)
                {
                    textcombat.text = $"{attaquant.name} utilise coup\n" + $"Le score du dé est de <color=green>{dicemonste}</color>\n" + "C'est une réussite"; 
                    combathealth[4].value -= (int)(attaquant.Damage * 2.5);
                }
                else
                {
                    textcombat.text = $"{attaquant.name} utilise coup\n" + $"Le score du dé est de <color=red>{dicemonste}</color>\n" + "C'est un échec"; 
                    
                }
                break;
                
        }
        DeckCombat.SetActive(true);

    }

  
    private IEnumerator Health(int player, int ennemy,Ennemy attaquant)
    {
        int r = Random.Range(0, quete.Ennemies.Count + 1);
        
        switch (player)
        { 
              
            case 0:
                Dicej();
                yield return WaitForSeconds(2.5f);
                if (dicescore == 20)
                {
                    textcombat.text = $"{playerData.playerName} utilise soin\n" + $"Le score du dé est de <color=yellow>{dicescore}</color>\n" + "C'est une réussite critique"; 
                    combathealth[4].value += (int)(playerData.magic * 4);
                   
                }
                else if(dicescore == 1)
                {
                    textcombat.text = $"{playerData.playerName} utilise soin\n" + $"Le score du dé est de <color=purple>{dicescore}</color>\n" + "C'est un échec critique"; 
                    combathealth[r].value += (int)(playerData.magic * 4);
                    
                }
                else if (dicescore >= 10)
                {
                    textcombat.text = $"{playerData.playerName} utilise soin\n" + $"Le score du dé est de <color=green>{dicescore}</color>\n" + "C'est une réussite"; 
                    combathealth[4].value += (int)(playerData.magic * 2);
                    
                }
                else
                {
                    textcombat.text = $"{playerData.playerName} utilise soin\n" + $"Le score du dé est de <color=red>{dicescore}</color>\n" + "C'est un échec"; 
                }
                foreach (var B in Deckbutton)
                {
                    B.interactable = false;
                }
               StartCoroutine( Turn());
                break;
            case 1:
               
                yield return WaitForSeconds(2.5f);
                Dice();
                yield return WaitForSeconds(2.5f);
                if (dicemonste == 20)
                {
                    textcombat.text = $"{attaquant.name} utilise soin\n" + $"Le score du dé est de <color=yellow>{dicemonste}</color>\n" + "C'est une réussite critique"; 
                    combathealth[ennemy].value += attaquant.Magic * 4;    
                }

                else if (dicemonste == 1)
                {
                    textcombat.text = $"{attaquant.name} utilise soin\n" + $"Le score du dé est de <color=purple>{dicemonste}</color>\n" + "C'est un échec critique"; 
                    combathealth[r].value += attaquant.Magic * 4;
                }
                else if ( dicemonste>= 10 )
                {
                    textcombat.text = $"{attaquant.name} utilise soin\n" + $"Le score du dé est de <color=green>{dicemonste}</color>\n" + "C'est une réussite"; 
                    combathealth[ennemy].value += attaquant.Magic * 2;
                }
                else
                {
                    textcombat.text = $"{attaquant.name} utilise coup\n" + $"Le score du dé est de <color=red>{dicemonste}</color>\n" + "C'est un échec"; 
                }
                break;
            
            
        }
        DeckCombat.SetActive(true);
    }

    public void ChoiceAttack1()
    {
        foreach (var test in boucliermdr)
        {
            test.SetActive(false);
        }
        EnemyChoice = 0;
        switch (attack)
        {
            case "Coup":
                StartCoroutine(Coup(0,EnemyChoice,null));
                break;
            case "Health":
                StartCoroutine( Health(0,EnemyChoice,null));
                break;
        }
    }
    public void ChoiceAttack2()
    {
        foreach (var test in boucliermdr)
        {
            test.SetActive(false);
        }
       
        EnemyChoice = 1;
        switch (attack)
        {
            case "Coup":
                StartCoroutine(Coup(0,EnemyChoice,null));
                break;
            case "Health":
                StartCoroutine( Health(0,EnemyChoice,null));
                break;
        }
    }
    public void ChoiceAttack3()
    {
        foreach (var test in boucliermdr)
        {
            test.SetActive(false);
        }
        EnemyChoice = 2;
        switch (attack)
        {
            case "Coup":
                StartCoroutine(Coup(0,EnemyChoice,null));
                break;
            case "Health":
                StartCoroutine( Health(0,EnemyChoice,null));
                break;
        }
    }

    public void Attack1()
    {
        attack = attacklist[0].name;
        DeckCombat.SetActive(false);
        int enemycount = 0;
        foreach (var e in quete.Ennemies)
        {
            if (e.type == Ennemy.EnemyType.Enemy)
            {
                enemycount++;
            }
        }
        switch (enemycount)
        {
            case 1:
                boucliermdr[1].SetActive(true);
                break;
            case 2:
                boucliermdr[0].SetActive(true);
                boucliermdr[1].SetActive(true);
                break;
            case 3:
                boucliermdr[0].SetActive(true);
                boucliermdr[1].SetActive(true);
                boucliermdr[2].SetActive(true);
                break;
        }

    }
    public void Attack2()
    {
        DeckCombat.SetActive(false);
        attack = attacklist[1].name;
        int enemycount = 0;
        foreach (var e in quete.Ennemies)
        {
            if (e.type == Ennemy.EnemyType.Enemy)
            {
                enemycount++;
            }
        }
        switch (enemycount)
        {
            case 1:
                boucliermdr[1].SetActive(true);
                break;
            case 2:
                boucliermdr[0].SetActive(true);
                boucliermdr[1].SetActive(true);
                break;
            case 3:
                boucliermdr[0].SetActive(true);
                boucliermdr[1].SetActive(true);
                boucliermdr[2].SetActive(true);
                break;
        }

    }
    public void Attack3()
    {
        DeckCombat.SetActive(false);
        attack = attacklist[2].name;
        int enemycount = 0;
        foreach (var e in quete.Ennemies)
        {
            if (e.type == Ennemy.EnemyType.Enemy)
            {
                enemycount++;
            }
        }
        switch (enemycount)
        {
            case 1:
                boucliermdr[1].SetActive(true);
                break;
            case 2:
                boucliermdr[0].SetActive(true);
                boucliermdr[1].SetActive(true);
                break;
            case 3:
                boucliermdr[0].SetActive(true);
                boucliermdr[1].SetActive(true);
                boucliermdr[2].SetActive(true);
                break;
        }


    }
    public void Attack4()
    {
        DeckCombat.SetActive(false);
        attack = attacklist[3].name;
        int enemycount = 0;
        foreach (var e in quete.Ennemies)
        {
            if (e.type == Ennemy.EnemyType.Enemy)
            {
                enemycount++;
            }
        }
        switch (enemycount)
        {
            case 1:
                boucliermdr[1].SetActive(true);
                break;
            case 2:
                boucliermdr[0].SetActive(true);
                boucliermdr[1].SetActive(true);
                break;
            case 3:
                boucliermdr[0].SetActive(true);
                boucliermdr[1].SetActive(true);
                boucliermdr[2].SetActive(true);
                break;
        }
    }








    private IEnumerator Turn()
    {
        
        combatants = new List<Combatant>();
        int combatcount = 0;
        int ally = 1;
        foreach (var VARIABLE in quete.Ennemies)
        {
            if (VARIABLE.type == Ennemy.EnemyType.Enemy)
            {
                combatcount++;
            }
            else
            {
                ally++;
            }
           
        }

        

        switch (ally)
        {
            case 1:
                if ( combathealth[4].value <= 0)
                {
                    endcombat = true;
                    defaite.SetActive(true);
                }
                break;
            case 2:
                if (combathealth[3].value <= 0 && combathealth[4].value <= 0)
                {
                    endcombat = true;
                    defaite.SetActive(true);
                }
                break;
            case 3:
                if (combathealth[3].value <= 0 && combathealth[4].value <= 0 && combathealth[5].value <= 0)
                {
                    endcombat = true;
                    defaite.SetActive(true);
                }
                break;
        }

        switch (combatcount)
        {
            case 1:
                if ( combathealth[1].value <= 0)
                {
                    endcombat = true;
                    victoire.SetActive(true);
                    bonusitemvie.text = quete.recompense.bonusvie.ToString();
                    bonusitemdex.text = quete.recompense.bonusdexterité.ToString();
                    bonusitemdam.text = quete.recompense.bonusdegat.ToString();
                    bonusitemres.text = quete.recompense.bonusresistance.ToString();
                    bonusitemmag.text = quete.recompense.bonusmagie.ToString();
                    bonusitemint.text = quete.recompense.bonusintelligence.ToString();
                    req.sprite = quete.recompense.itemImage;
                    requiert.text = quete.recompense.requiert.ToString();
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

                }
                break;
            case 2:
                if (combathealth[0].value <= 0 && combathealth[1].value <= 0)
                {
                    endcombat = true;
                    victoire.SetActive(true);
                    bonusitemvie.text = quete.recompense.bonusvie.ToString();
                    bonusitemdex.text = quete.recompense.bonusdexterité.ToString();
                    bonusitemdam.text = quete.recompense.bonusdegat.ToString();
                    bonusitemres.text = quete.recompense.bonusresistance.ToString();
                    bonusitemmag.text = quete.recompense.bonusmagie.ToString();
                    bonusitemint.text = quete.recompense.bonusintelligence.ToString();
                    req.sprite = quete.recompense.itemImage;
                    requiert.text = quete.recompense.requiert.ToString();
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

                }
                break;
            case 3:
                if (combathealth[0].value <= 0 && combathealth[1].value <= 0 && combathealth[2].value <= 0)
                {
                    endcombat = true;
                    victoire.SetActive(true);
                    bonusitemvie.text = quete.recompense.bonusvie.ToString();
                    bonusitemdex.text = quete.recompense.bonusdexterité.ToString();
                    bonusitemdam.text = quete.recompense.bonusdegat.ToString();
                    bonusitemres.text = quete.recompense.bonusresistance.ToString();
                    bonusitemmag.text = quete.recompense.bonusmagie.ToString();
                    bonusitemint.text = quete.recompense.bonusintelligence.ToString();
                    req.sprite = quete.recompense.itemImage;
                    requiert.text = quete.recompense.requiert.ToString();
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

                }
                break;
        }
        switch (combatcount)
        {
            case 2:
                if (combathealth[1].value <= 0)
                {
                    _ennemieslist.Remove(_ennemieslist[0]);
                }

                if (combathealth[0].value <= 0 && _ennemieslist.Count == 2)
                {
                    _ennemieslist.Remove(_ennemieslist[1]);
                }
                break;
            case 3:
                if (combathealth[1].value <= 0)
                {
                    _ennemieslist.Remove(_ennemieslist[0]);
                }

                if (combathealth[0].value <= 0 && _ennemieslist.Count > 2)
                {
                    _ennemieslist.Remove(_ennemieslist[1]);
                }

                if (combathealth[2].value <= 0 && _ennemieslist.Count == 3)
                {
                    _ennemieslist.Remove(_ennemieslist[2]);
                }
                break;
        }
        foreach (var E in  _ennemieslist)
        {
            Combatant c = new Combatant();
            c.Name = E.name;
            c.Dexterity = E.Dexterity;
            combatants.Add(c);
        }
        combatants.Sort((a, b) => b.Dexterity.CompareTo(a.Dexterity));
        foreach (var ele in combatants)
        {
            Debug.Log(combatants.Count);
            Debug.Log($"{ele.Name},{ele.Dexterity}");    
        }
        
        turnQueue = new Queue<Combatant>(combatants);
        while (turnQueue.Count > 0 && endcombat == false )
        {
            Combatant currentCombatant = turnQueue.Dequeue();
           Debug.Log(turnQueue.Count);
          foreach (var E in quete.Ennemies)
          {
                  
              if (E.Dexterity == currentCombatant.Dexterity && E.name == currentCombatant.Name)
              {
                 
                  Debug.Log(true);
                  EnnemyActionChoice(E);
                  yield return WaitForSeconds(6f);
                  
              }

            
          }
         
            
         
        }
        foreach (var B in Deckbutton)
        {
            B.interactable = true;   
        }
       
        
        
    }
    public class Combatant
    {
        public string Name { get; set; }
        public int Dexterity { get; set; }
    }

}   
