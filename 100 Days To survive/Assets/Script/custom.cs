using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

[Serializable]
public class PlayerData
{
    
    public string playerName;
    public int currentPageIndex;
    public List<Item> inventory;
    public int health;
    public int damage;
    public int dexterity;
    public int intelligence;
    public int resistance;
    public int magic;
    public int blueRubies;
    public int redRubies;
    public int epee;
    public int arc;
    public int baton;
    public int bouclier;
    public int hache;
    public int massue;
    public int jour;
    public int pointarme;
    public int pointstat;
    public Dictionary<string, float> weaponSkills;
    public List<Item> armoritem = new List<Item>();
    public Dictionary<string, Item> itemarmor = new Dictionary<string, Item>();
    public Dictionary<string, Item> iteninventory = new Dictionary<string, Item>();
    public string armjson = "";
    public string heyjson;
    public List<string> invstr = new List<string>();
    public List<string> arminv= new List<string>();
    public string quete = "Day1";
    public int baseHealth;
    public int baseDamage;
    public int baseDexterity;
    public int baseResistance;
    public int baseMagic;
    public int baseIntelligence;
    public List<Item> deck = new List<Item>();
    public List<string> skillnames = new List<string>();
    public List<string> decknames = new List<string>();

    public PlayerData()
    {
        
        baseHealth = 1;
        baseDamage = 1;
        baseDexterity = 1;
        baseIntelligence = 1;
        baseMagic = 1;
        baseResistance = 1;
        jour = 1;
        playerName = "Luc";
        currentPageIndex = 0;
        health = baseHealth;
        damage = baseDamage;
        dexterity = baseDexterity;
        intelligence = baseIntelligence;
        resistance = baseResistance;
        magic = baseMagic;
        blueRubies = 10;
        redRubies = 5;
        epee = 1;
        arc = 1;
        bouclier = 1;
        baton = 1;
        hache = 1;
        massue = 1;
        pointstat = 100;
        pointarme = 100;

    }
}

public class custom : MonoBehaviour
{
    public GameObject[] pages; 
    private int currentPageIndex = 0;
    public TMP_Text text;
    private string playerName = "luc";
    public TMP_InputField nom;
    private PlayerData playerData;
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
    public TMP_Text pointarme;
    public TMP_Text pointstat;
    public GameObject page;
    public List<Item> inventory;
    public List<Item> Deck;
    public List<inventoryslot> equippedarmor  ;
    public Dictionary<string, Item> iteninventory = new Dictionary<string, Item>();
    public GameObject buttonhealth;
    public GameObject buttondam;
    public GameObject buttres;
    public GameObject butdex;
    public GameObject butint;
    public GameObject butmag;

    private void Start()
    {
        
        LoadPlayerData();
    }

    public void Update()
    {
        text.text = currentPageIndex.ToString();
        playerName = nom.text;
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
    }

   
    public void PreviousPage()
    {
      
        if (currentPageIndex > 0)
        {
            pages[currentPageIndex].SetActive(false); 
            currentPageIndex--; 
            pages[currentPageIndex].SetActive(true); 
        }
    }
 
    public void NextPage()
    {
       
        if (currentPageIndex < pages.Length - 1)
        {
            pages[currentPageIndex].SetActive(false); 
            currentPageIndex++; 
            pages[currentPageIndex].SetActive(true); 
        }
    }

  
    public void SavePlayerData()
    {
       
        playerData.playerName = playerName;
        playerData.currentPageIndex = currentPageIndex;
        playerData.inventory = inventory;
        playerData.deck = Deck;
        foreach (var item in inventory)
        {
            playerData.invstr.Add(item.name);
        }

        foreach (var skill in Deck)
        {
            playerData.skillnames.Add(skill.name);
        }

     

       
        string playerDataJson = JsonUtility.ToJson(playerData);
        PlayerPrefs.SetString("PlayerData", playerDataJson);
        PlayerPrefs.Save();
    }

    
    private void LoadPlayerData()
    {
       
        string playerDataJson = PlayerPrefs.GetString("PlayerData", "");
        if (!string.IsNullOrEmpty(playerDataJson))
        {
            playerData = JsonUtility.FromJson<PlayerData>(playerDataJson);
        }
        else
        {
         
            playerData = new PlayerData();
        }

       
        nom.text = playerData.playerName;
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
        pointarme.text = playerData.pointarme.ToString();
        pointstat.text = playerData.pointstat.ToString();

      
        if (playerData.currentPageIndex >= 0 && playerData.currentPageIndex < pages.Length)
        {
            currentPageIndex = playerData.currentPageIndex;
            for (int i = 0; i < pages.Length; i++)
            {
                pages[i].SetActive(i == currentPageIndex);
            }
        }
    }

    public void changescene()
    {
        SceneManager.LoadScene("Game");
    }

    public void AddHealthStat()
    {
       
        if (playerData.pointstat > 0 && playerData.baseHealth < 5)
        {
            playerData.pointstat--;
            playerData.baseHealth++;
            playerData.health = playerData.baseHealth;
            sante.text = playerData.health.ToString();
            pointstat.text = playerData.pointstat.ToString();
        }
    }

    public void AddDamageStat()
    {
        if (playerData.pointstat > 0&& playerData.baseDamage < 5)
        {
            playerData.pointstat--;
            playerData.baseDamage++;
            playerData.damage = playerData.baseDamage;
            degat.text = playerData.damage.ToString();
            pointstat.text = playerData.pointstat.ToString();
        }
    }

    public void AddDexterityStat()
    {
        if (playerData.pointstat > 0&& playerData.baseDexterity < 5)
        {
            playerData.pointstat--;
            playerData.baseDexterity++;
            playerData.dexterity = playerData.baseDexterity;
            dexterité.text = playerData.dexterity.ToString();
            pointstat.text =  playerData.pointstat.ToString();
        }
    }

    public void AddIntelligenceStat()
    {
        if (playerData.pointstat > 0&& playerData.baseIntelligence < 5)
        {
            playerData.pointstat--;
            playerData.baseIntelligence++;
            playerData.intelligence = playerData.baseIntelligence;
            intelligence.text = playerData.intelligence.ToString();
            pointstat.text =  playerData.pointstat.ToString();
        }
    }

    public void AddResistanceStat()
    {
        if (playerData.pointstat > 0&& playerData.baseResistance < 5)
        {
            playerData.pointstat--;
            playerData.baseResistance++;
            playerData.resistance = playerData.baseResistance;
            resistance.text = playerData.resistance.ToString();
            pointstat.text =  playerData.pointstat.ToString();
        }
    }

    public void AddMagicStat()
    {
        if (playerData.pointstat > 0&& playerData.baseMagic < 5)
        {
            playerData.pointstat--;
            playerData.baseMagic++;
            playerData.magic = playerData.baseMagic;
            magie.text = playerData.magic.ToString();
            pointstat.text =  playerData.pointstat.ToString();
        }
    }
    

    public void AddEpeeStat()
    {
        if (playerData.pointarme > 0)
        {
            playerData.pointarme--;
            playerData.epee++;
            epee.text = playerData.epee.ToString();
            pointarme.text =  playerData.pointarme.ToString();
        }
    }

    public void AddArcStat()
    {
        if (playerData.pointarme > 0)
        {
            playerData.pointarme--;
            playerData.arc++;
            arc.text = playerData.arc.ToString();
            pointarme.text =  playerData.pointarme.ToString();
        }
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
    }

    public void AddBouclierStat()
    {
        if (playerData.pointarme > 0)
        {
            playerData.pointarme--;
            playerData.bouclier++;
            bouclier.text = playerData.bouclier.ToString();
            pointarme.text =  playerData.pointarme.ToString();
        }
    }

    public void AddHacheStat()
    {
        if (playerData.pointarme > 0)
        {
            playerData.pointarme--;
            playerData.hache++;
            hache.text = playerData.hache.ToString();
            pointarme.text =  playerData.pointarme.ToString();
        }
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
    }

    public void Next()
    {
        page.SetActive(false);
    }

    public void Back()
    {
        page.SetActive(true);
    }
}


