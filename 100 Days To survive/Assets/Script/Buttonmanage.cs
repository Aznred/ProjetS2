    using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttonmanage : MonoBehaviour
{
    public Button load;
    private void Update()
    {
        if (!PlayerPrefs.HasKey("PlayerData"))
        {
            load.interactable = false;
        }
        else
        {
            load.interactable = true;
        }
    }

    public void NewGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Customize");
    }

    public void Load()
    {
        SceneManager.LoadScene("Game");
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
}
