using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class buttonchoice : MonoBehaviour
{
    public GameObject croix1;
    public GameObject croix2;

    public void choice1()
    {
        croix1.SetActive(true);
    }

    public void choice2()
    {
        croix2.SetActive(true);
    }

   
}
