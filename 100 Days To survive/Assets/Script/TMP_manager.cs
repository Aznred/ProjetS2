using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class TMP_manager : MonoBehaviour
{
    public TMP_Text tmpmanager;

    public string[] lines;

    public float textspeed;

    private int index;
    // Start is called before the first frame update
    void Start()
    {
        tmpmanager.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void StartDialogue()
    {
        index = 0;
        StartCoroutine(typeline());
    }

    IEnumerator typeline()
    {
        foreach (var c in lines[index].ToCharArray())
        {
            tmpmanager.text += c;
            yield return new WaitForSeconds(textspeed);
        }
    }
}
