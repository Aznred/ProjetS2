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
    private Slider healthChoice;
    private int ally = 0;
    public Button Attaque1;
    public Button Attaque2;
    public Button Attaque3;
    public Button Attaque4;
    public Image Choix1Mob;
    public Image Choix2Mob;
    public Image Choix3Mob;
    public List<GameObject> AbilityHere;
    public List<Item> Ability;
    public GameObject DeckCard;
    public List<Image> AbilityList;
    public List<TMP_Text> AbilityNames;
    private bool ChoixAttaque1 = false;
    private bool ChoixAttaque2 = false;
    private bool ChoixAttaque3 = false;
    private Ennemy Mob1;
    private Ennemy Mob2;
    private Ennemy Mob3;
    public GameObject ChoiceMob1;
    public GameObject ChoiceMob2;
    public GameObject ChoiceMob3;
    public TMP_Text HealthMob1;
    public TMP_Text DamageMob1;
    public TMP_Text DexterityMob1;
    public TMP_Text ResistanceMob1;
    public TMP_Text IntelligenceMob1;
    public TMP_Text MagicMob1;
    public TMP_Text HealthMob2;
    public TMP_Text DamageMob2;
    public TMP_Text DexterityMob2;
    public TMP_Text ResistanceMob2;
    public TMP_Text IntelligenceMob2;
    public TMP_Text MagicMob2;
    public TMP_Text HealthMob3;
    public TMP_Text DamageMob3;
    public TMP_Text DexterityMob3;
    public TMP_Text ResistanceMob3;
    public TMP_Text IntelligenceMob3;
    public TMP_Text MagicMob3;
    public TMP_Text HealthAlly1;
    public TMP_Text DamageAlly1;
    public TMP_Text DexterityAlly1;
    public TMP_Text ResistanceAlly1;
    public TMP_Text IntelligenceAlly1;
    public TMP_Text MagicAlly1;
    public TMP_Text HealthAlly2;
    public TMP_Text DamageAlly2;
    public TMP_Text DexterityAlly2;
    public TMP_Text ResistanceAlly2;
    public TMP_Text IntelligenceAlly2;
    public TMP_Text MagicAlly2;
    public TMP_Text HealthAlly3;
    public TMP_Text DamageAlly3;
    public TMP_Text DexterityAlly3;
    public TMP_Text ResistanceAlly3;
    public TMP_Text IntelligenceAlly3;
    public TMP_Text MagicAlly3;
    public GameObject Stat1;
    public GameObject Stat2;
    public GameObject Stat3;
    public GameObject Stat4;
    public GameObject Stat5;
    public GameObject Stat6;

    public GameObject ally1im;
    public GameObject allyim2;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
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
    public Image ally1;
    public Image ally2;
    public Image perso;
    public Image ennemy1;
    public Image ennemy2;
    public Image ennemy3;
    public AudioSource ambiance;
    public AudioSource dicesong;
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
    public Button mindButton;
    public TMP_Text phrasemid;
    public Button attackButton;
    public TMP_Text phrase;
    private int dicemonste;

    public GameObject combat;
    public TMP_Text NameMob1;
    public TMP_Text NameMob2;
    public TMP_Text NameMob3;
    public TMP_Text NameAlly;
    public TMP_Text NameAlly2;
    public TMP_Text NamePlayer;

    public Image playerim;
    public Slider healthmob;
    public Slider healthmob1;
    public Slider healthmob2;
    public Slider healthally1;
    public Slider healthally2;
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
        playerData.health = Random.Range(1,8);
        playerData.damage = Random.Range(1, 11);
        mindButton.enabled = true;
        attackButton.interactable = true;
        heatlhplayer.maxValue = playerData.health * 100;
        heatlhplayer.value = playerData.health * 100;

        GenererDay(quete);

        selectedSlot = Inventoryslots[1];
    }

    public void ShowMonsterInfo()
    {

        Ennemy monstre = quete.combatmonstre[0];


        TooltipCombat.instance.settooltip(monstre, healthmob);


        TooltipCombat.instance.gameObject.SetActive(true);
    }

    private void OnMouseOver()
    {

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
                        if (name == ele.name)
                        {


                            if (slot.acceptedItemType == ele.itemtype && slot.transform.childCount < 1)
                            {

                                SpawnItem(ele, slot);


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
            playerData.baseIntelligence = playerData.intelligence - bonusIntelligence;
            playerData.baseMagic = playerData.magic - bonusMagic;

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

                    if (name == ele.name)
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
        if (playerData.pointstat > 0 && playerData.baseDamage < 5)
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
        if (playerData.pointstat > 0 && playerData.baseDexterity < 5)
        {
            playerData.pointstat--;
            playerData.baseDexterity++;
            playerData.dexterity = playerData.baseDexterity + bonusDexterity;
            dexterité.text = playerData.dexterity.ToString();
            pointstat.text = playerData.pointstat.ToString();
        }

        UpdatePlayerData();
    }

    public void AddIntelligenceStat()
    {
        if (playerData.pointstat > 0 && playerData.baseIntelligence < 5)
        {
            playerData.pointstat--;
            playerData.baseIntelligence++;
            playerData.intelligence = playerData.baseIntelligence + bonusIntelligence;
            intelligence.text = (playerData.baseIntelligence + bonusIntelligence).ToString();

            pointstat.text = playerData.pointstat.ToString();
        }

        UpdatePlayerData();
    }

    public void AddResistanceStat()
    {
        if (playerData.pointstat > 0 && playerData.baseResistance < 5)
        {
            playerData.pointstat--;
            playerData.baseResistance++;
            playerData.resistance = playerData.baseResistance + bonusResistance;
            resistance.text = playerData.resistance.ToString();
            pointstat.text = playerData.pointstat.ToString();
        }

        UpdatePlayerData();
    }

    public void AddMagicStat()
    {
        if (playerData.pointstat > 0 && playerData.baseMagic < 5)
        {
            playerData.pointstat--;
            playerData.baseMagic++;
            playerData.magic = playerData.baseMagic + bonusMagic;
            magie.text = playerData.magic.ToString();
            pointstat.text = playerData.pointstat.ToString();
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
                if (slot.acceptedItemType == item.itemtype)
                {
                    SpawnItem(item, slot);


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
        Sprite lieu = meteo[UnityEngine.Random.Range(0, meteo.Count)];
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
            StartCoroutine(typeline(Quest.Firstdialogue, Dialoguepnj, 0.025f));


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
            DeckCard.SetActive(false);
            HealthAlly2.text = (playerData.baseHealth + bonusHealth).ToString();
            DamageAlly2.text = (playerData.baseDamage + bonusDamage).ToString();
            ResistanceAlly2.text = (playerData.baseResistance + bonusResistance).ToString();
            IntelligenceAlly2.text = (playerData.baseIntelligence + bonusIntelligence).ToString();
            MagicAlly2.text = (playerData.baseMagic + bonusMagic).ToString();
            DexterityAlly2.text = (playerData.baseDexterity + bonusDexterity).ToString();
            NamePlayer.text = playerData.playerName;

            int inndex = 0;
            int indexa = 0;
            int indexe = 0;
            int enemynum = 0;
            ally = 0;
            foreach (var ele in Deck)
            {
                if (ele.transform.childCount >= 1)
                {
                    DraggableItem draggableItem = ele.GetComponentInChildren<DraggableItem>(true);

                    Debug.Log(draggableItem.Item);
                    Ability.Add(draggableItem.Item);
                    index++;
                }
            }

            Debug.Log((Ability));

            switch (Ability.Count)
            {
                case 1:
                    AbilityList[0].sprite = Ability[0].itemImage;
                    AbilityNames[0].text = Ability[0].itemName;
                    AttackDeckChoice(Attaque1, Ability[0].itemName);
                    AbilityHere[1].SetActive(false);
                    AbilityHere[2].SetActive(false);
                    AbilityHere[3].SetActive(false);

                    break;
                case 2:

                    AbilityHere[2].SetActive(false);
                    AbilityHere[3].SetActive(false);
                    AbilityList[0].sprite = Ability[0].itemImage;
                    AbilityNames[0].text = Ability[0].itemName;
                    AbilityNames[1].text = Ability[1].itemName;
                    AbilityList[1].sprite = Ability[1].itemImage;
                    AttackDeckChoice(Attaque1, Ability[0].itemName);
                    AttackDeckChoice(Attaque2, Ability[1].itemName);
                    break;
                case 3:

                    AbilityHere[3].SetActive(false);
                    AbilityList[0].sprite = Ability[0].itemImage;
                    AbilityNames[0].text = Ability[0].itemName;
                    AbilityNames[1].text = Ability[1].itemName;
                    AbilityNames[2].text = Ability[2].itemName;
                    AbilityList[1].sprite = Ability[1].itemImage;
                    AbilityList[2].sprite = Ability[2].itemImage;
                    AttackDeckChoice(Attaque1, Ability[0].itemName);
                    AttackDeckChoice(Attaque2, Ability[1].itemName);
                    AttackDeckChoice(Attaque3, Ability[2].itemName);
                    break;
                case 4:
                    AbilityNames[0].text = Ability[0].itemName;
                    AbilityNames[1].text = Ability[1].itemName;
                    AbilityNames[2].text = Ability[2].itemName;
                    AbilityNames[3].text = Ability[3].itemName;
                    AbilityList[0].sprite = Ability[0].itemImage;
                    AbilityList[1].sprite = Ability[1].itemImage;
                    AbilityList[2].sprite = Ability[2].itemImage;
                    AbilityList[3].sprite = Ability[3].itemImage;
                    AttackDeckChoice(Attaque1, Ability[0].itemName);
                    AttackDeckChoice(Attaque2, Ability[1].itemName);
                    AttackDeckChoice(Attaque3, Ability[2].itemName);
                    AttackDeckChoice(Attaque4, Ability[3].itemName);

                    break;
            }

            foreach (var ele in Quest.combatmonstre)
            {
                if (ele.type == Ennemy.EnemyType.Ally)
                {
                    ally++;
                }
                else
                {
                    enemynum++;
                }
            }

            switch (ally)
            {
                case 0:
                    ally1im.SetActive(false);
                    allyim2.SetActive(false);
                    break;
                case 1:
                    ally1im.SetActive(true);
                    allyim2.SetActive(false);
                    break;
                case 2:
                    ally1im.SetActive(true);
                    allyim2.SetActive(true);
                    break;
            }

            switch (enemynum)
            {
                case 0:
                    enemy1.SetActive(false);
                    enemy2.SetActive(false);
                    enemy3.SetActive(false);
                    break;
                case 1:
                    enemy1.SetActive(true);
                    enemy2.SetActive(false);
                    enemy3.SetActive(false);
                    ChoiceMob1.SetActive(true);
                    ChoiceMob2.SetActive(false);
                    ChoiceMob3.SetActive(false);
                    break;
                case 2:
                    enemy1.SetActive(true);
                    enemy2.SetActive(true);
                    enemy3.SetActive(false);
                    ChoiceMob1.SetActive(true);
                    ChoiceMob2.SetActive(true);
                    ChoiceMob3.SetActive(false);
                    break;
                case 3:
                    enemy1.SetActive(true);
                    enemy2.SetActive(true);
                    enemy3.SetActive(true);
                    ChoiceMob1.SetActive(true);
                    ChoiceMob2.SetActive(true);
                    ChoiceMob3.SetActive(true);
                    break;
            }

            foreach (var ele in Quest.combatmonstre)
            {
                combat.SetActive(true);
                perso.sprite = playerim.sprite;

                if (ele.type == Ennemy.EnemyType.Ally)
                {
                    if (indexa == 0)
                    {
                        ally1.sprite = ele.Mobimage;
                        healthally1.maxValue = ele.Health * 100;
                        healthally1.value = ele.Health * 100;
                        indexa++;
                        ActuStat(ele, NameAlly, HealthAlly1, DamageAlly1, MagicAlly1, IntelligenceAlly1,
                            ResistanceAlly1, DexterityAlly1);
                    }
                    else
                    {
                        ally2.sprite = ele.Mobimage;
                        healthally2.maxValue = ele.Health * 100;
                        healthally2.value = ele.Health * 100;
                        ActuStat(ele, NameAlly2, HealthAlly3, DamageAlly3, MagicAlly3, IntelligenceAlly3,
                            ResistanceAlly3, DexterityAlly3);
                    }
                }
                else
                {
                    if (indexe == 0)
                    {
                        Mob1 = ele;
                        ennemy1.sprite = ele.Mobimage;
                        Choix1Mob.sprite = ele.Mobimage;
                        healthmob.maxValue = ele.Health * 100;
                        healthmob.value = ele.Health * 100;
                        indexe++;
                        ActuStat(ele, NameMob1, HealthMob1, DamageMob1, MagicMob1, IntelligenceMob1, ResistanceMob1,
                            DexterityMob1);
                    }
                    else if (indexe == 1)
                    {
                        Mob2 = ele;
                        ennemy2.sprite = ele.Mobimage;
                        Choix2Mob.sprite = ele.Mobimage;
                        healthmob1.maxValue = ele.Health * 100;
                        healthmob1.value = ele.Health * 100;
                        indexe++;
                        ActuStat(ele, NameMob2, HealthMob2, DamageMob2, MagicMob2, IntelligenceMob2, ResistanceMob2,
                            DexterityMob2);
                    }
                    else
                    {
                        Mob3 = ele;
                        ennemy3.sprite = ele.Mobimage;
                        Choix3Mob.sprite = ele.Mobimage;
                        healthmob2.maxValue = ele.Health * 100;
                        healthmob2.value = ele.Health * 100;
                        ActuStat(ele, NameMob3, HealthMob3, DamageMob3, MagicMob3, IntelligenceMob3, ResistanceMob3,
                            DexterityMob3);
                    }
                }
            }
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
    {
        soundtouch.Play();
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
        StartCoroutine(typelinetext(quete.Choixdial1[index], Dialoguepnj, 0.025f, 1, Dialoguejoueur));

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
        StartCoroutine(typelinetext(quete.Choixdial2[index], Dialoguepnj, 0.025f, 2, Dialoguejoueur));

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
        StartCoroutine(typelinetext(quete.choixdial3[index], Dialoguepnj, 0.025f, 3, Dialoguejoueur));

    }

    public void Continuer()
    {
        Dialoguepnj.text = string.Empty;

        continuer.GetComponent<Button>().interactable = false;
        StartCoroutine(typelinecontinuer(quete.choixdial3, Dialoguepnj, 0.025f, choix));

    }

    IEnumerator typelinetext(string lines, TMP_Text tmp, float speed, int num, TMP_Text jou)
    {
        soundtouch.Play();
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
    {
        soundtouch.Play();

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

                }

                break;

            case 2:
                lines = quete.Choixdial2;
                if (quete.dial && index >= lines.Length)
                {
                    GenererDay(quete.choix2);
                    quete = quete.choix2;

                }
                else if (index >= lines.Length)
                {
                    Histoire.SetActive(false);
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

                }

                break;


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
        if (playerData.redRubies >= quete.prix[1])
        {
            Item2.enabled = false;
            AddItemToInventory(quete.marché[1]);
            playerData.redRubies -= quete.prix[1];
            Item2.image.sprite = vendu;
            UpdateThunes();

        }


    }

    public void Achat3()
    {
        if (playerData.blueRubies >= quete.prix[2])
        {
            Item3.enabled = false;
            AddItemToInventory(quete.marché[2]);
            playerData.blueRubies -= quete.prix[2];
            Item3.image.sprite = vendu;
            UpdateThunes();

        }


    }

    public void Achat4()
    {
        if (playerData.blueRubies >= quete.prix[3])
        {
            Item4.enabled = false;
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

        intelligence.text = (playerData.baseIntelligence + bonusIntelligence).ToString();
        sante.text = (playerData.baseHealth + bonusHealth).ToString();
        magie.text = (playerData.baseMagic + bonusMagic).ToString();
        degat.text = (playerData.baseDamage + bonusDamage).ToString();
        dexterité.text = (playerData.baseDexterity + bonusDexterity).ToString();
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
        intelligence.text = (playerData.baseIntelligence + bonusIntelligence).ToString();
        sante.text = (playerData.baseHealth + bonusHealth).ToString();
        magie.text = (playerData.baseMagic + bonusMagic).ToString();
        degat.text = (playerData.baseDamage + bonusDamage).ToString();
        dexterité.text = (playerData.baseDexterity + bonusDexterity).ToString();
        resistance.text = (playerData.baseResistance + bonusResistance).ToString();
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








    public void OpenStatMob1()
    {
        Stat1.SetActive(true);
    }

    public void CloseStatMob1()
    {
        Stat1.SetActive(false);
    }

    public void OpenStatMob2()
    {
        Stat2.SetActive(true);
    }

    public void CloseStatMob2()
    {
        Stat2.SetActive(false);
    }

    public void OpenStatMob3()
    {
        Stat3.SetActive(true);
    }

    public void CloseStatMob3()
    {
        Stat3.SetActive(false);
    }

    public void OpenStatAlly1()
    {
        Stat4.SetActive(true);
    }

    public void CloseStatAlly1()
    {
        Stat4.SetActive(false);
    }

    public void CloseStatAlly2()
    {
        Stat5.SetActive(false);
    }

    public void OpenStatAlly2()
    {
        Stat5.SetActive(true);
    }

    public void CloseStatAlly3()
    {
        Stat6.SetActive(false);
    }

    public void OpenStatAlly3()
    {
        Stat6.SetActive(true);
    }





    public void ActuStat(Ennemy ennemy, TMP_Text name, TMP_Text healt, TMP_Text dam, TMP_Text mag, TMP_Text inte,
        TMP_Text res, TMP_Text dex)
    {
        name.text = ennemy.name;
        healt.text = ennemy.Health.ToString();
        dam.text = ennemy.Damage.ToString();
        mag.text = ennemy.Magic.ToString();
        inte.text = ennemy.Intelligence.ToString();
        res.text = ennemy.Resistance.ToString();
        dex.text = ennemy.Dexterity.ToString();
    }

    public void Choix1()
    {
        DeckCard.SetActive(true);
        ChoixAttaque1 = true;
        ChoixAttaque2 = false;
        ChoixAttaque3 = false;
    }

    public void Choix2()
    {
        DeckCard.SetActive(true);
        ChoixAttaque1 = false;
        ChoixAttaque2 = true;
        ChoixAttaque3 = false;
    }

    public void Choix3()
    {
        DeckCard.SetActive(true);
        ChoixAttaque1 = false;
        ChoixAttaque2 = false;
        ChoixAttaque3 = true;
    }

    public void Coup()
    {
        if (ChoixAttaque1)
        {
            healthmob.value -= playerData.damage * 10;
            ChoixAttaque1 = false;
            DeckCard.SetActive(false);
           
        }

        else if (ChoixAttaque2)
        {
            healthmob1.value -= playerData.damage * 10;
            ChoixAttaque2 = false;
            DeckCard.SetActive(false);
        }

        else if (ChoixAttaque3)
        {
            healthmob2.value -= playerData.damage * 10;
            ChoixAttaque3 = false;
            DeckCard.SetActive(false);
        }

        foreach (var ele in quete.combatmonstre)
        {
            if (ele.type == Ennemy.EnemyType.Enemy)
            {
                ennemiact(ele);
                break;
            }
        }
       
    }

    public void CoupCirculaire()
    {
    }

    public void Perforation()
    {
    }

    public void Broyage()
    {
    }

    public void Seisme()
    {
    }

    public void Charge()
    {
    }

    public void Invulnérabilté()
    {
    }

    public void ParadeDeLumiere()
    {
    }

    public void Parer()
    {
    }

    public void CriDeGuerre()
    {}
    public void Health(){}
    public void Lecture(){}
    public void Renforcement(){}

    public void OeilDeLynx()
    {
        
    }
    public void Desintegration(){}
    public void LassoDeFeu(){}
    public void LumiereDivine(){}
    public void PointeDeGlace(){}
    public void BouleDeFeu(){}
    public void Brisage(){}
    public void FlecheMagique(){}
    public void Rafale(){}
    public void TirDansLeCoeur(){}
    public  void TirDArc(){}
    public void ParadeRenforce(){}

public void AttackDeckChoice(Button button, String name)
     {
         switch (name)
         {
             case "Coup" :
                 button.onClick.AddListener(() => Coup());
                 break;
             case "Broyage" :
                 button.onClick.AddListener(() => Broyage());
                 break;
             case "Coup Circulaire" :
                 button.onClick.AddListener(() =>CoupCirculaire());
                 break;
             case "Perforation" :
                 button.onClick.AddListener(() => Perforation());
                 break;
             case "Seisme" :
                 button.onClick.AddListener(() => Seisme());
                 break;
             case "Brisage" :
                 button.onClick.AddListener(() => Brisage());
                 break;
             case "Fleche Magique" :
                 button.onClick.AddListener(() => FlecheMagique());
                 break;
             case "Rafale" :
                 button.onClick.AddListener(() =>Rafale());
                 break;
             case "Tir Dans Le Coeur" :
                 button.onClick.AddListener(() => TirDansLeCoeur());
                 break;
             case "Tir D'arc" :
                 button.onClick.AddListener(() => TirDArc());
                 break;
             case "Desintegration" :
                 button.onClick.AddListener(() => Desintegration());
                 break;
             case "Lasso De Feu" :
                 button.onClick.AddListener(() => LassoDeFeu());
                 break;
             case "Lumiere Divine" :
                 button.onClick.AddListener(() =>LumiereDivine());
                 break;
             case "Pointe De Glace" :
                 button.onClick.AddListener(() => PointeDeGlace());
                 break;
             case "Boule De Feu" :
                 button.onClick.AddListener(() => BouleDeFeu());
                 break;
             case "Cri De Guerre" :
                 button.onClick.AddListener(() => CriDeGuerre());
                 break;
             case "Soin" :
                 button.onClick.AddListener(() => Health());
                 break;
             case "Lecture" :
                 button.onClick.AddListener(() =>Lecture());
                 break;
             case "Oeil De Lynx" :
                 button.onClick.AddListener(() => OeilDeLynx());
                 break;
             case "Renforcement" :
                 button.onClick.AddListener(() => Renforcement());
                 break;
             case "Charge" :
                 button.onClick.AddListener(() => Charge());
                 break;
             case "Invunerabilite" :
                 button.onClick.AddListener(() => Invulnérabilté());
                 break;
             case "Parade De Lumiere" :
                 button.onClick.AddListener(() =>ParadeDeLumiere());
                 break;
             case "Parade Renforce" :
                 button.onClick.AddListener(() => ParadeRenforce());
                 break;
             case "Parer" :
                 button.onClick.AddListener(() => Parer());
                 break;
            
            
         }
         
     }

public float MobAttackChoice1(Ennemy ennemy, string attaque)
{
    
    int Random = 0;
    float Result = 0;
    float AttaquePoint = 0;
    float BuffPoint = 0;
    switch (ally)
    {
        case 2 :
            healthChoice = heatlhplayer;
            break;
    }
    switch (attaque)
    {
        case "Soin" :
            if (healthmob.value <= healthmob.maxValue/4)
            {
                BuffPoint += 4f ;
            }
            else if (healthmob.value <= healthmob.maxValue/2)
            {
                BuffPoint += 1f ;
            }
            else
            {
                BuffPoint += 0.5f ;
            }
            break;
        case "Attaque":
            if (healthChoice.value <= healthChoice.maxValue / 4)
            {
                AttaquePoint += 2.5f;
            }
            else if (healthChoice.value <= healthChoice.maxValue/2)
            {
                AttaquePoint += 1f;
            }
            else
            {
                AttaquePoint += 1f;
            }
            break;

    }
    Debug.Log($"{AttaquePoint}  ,   {BuffPoint}");
    Result = AttaquePoint + BuffPoint;
    return Result;
}

public void Attaque(Ennemy ennemy)
{
    heatlhplayer.value -= ennemy.Damage*10;
}

public void Soin(Ennemy ennemy)
{
    healthmob.value += ennemy.Magic * 10;
}

public void Debuff()
{

    playerData.damage -= Random.Range(1, 4);
    UpdateCombat(Mob1);
}

public void Buff(Ennemy ennemy)
{
    ennemy.Damage +=  Random.Range(1, 4);
    UpdateCombat(Mob1);
}

public void UpdateCombat(Ennemy ennemy)
{
    DamageAlly1.text = playerData.damage.ToString();
    DamageMob1.text = ennemy.Damage.ToString();

}

public void ennemiact(Ennemy ennemy)
{
    float Soin = MobAttackChoice1(ennemy, "Soin");
    float attack = MobAttackChoice1(ennemy, "Attaque");

    if (Soin > attack)
    {
        this.Soin(ennemy);
    }
    else
    {
        Attaque(ennemy);
    }
}

} 
