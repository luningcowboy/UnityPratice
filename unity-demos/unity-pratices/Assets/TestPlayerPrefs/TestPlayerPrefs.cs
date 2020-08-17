using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerPrefs : MonoBehaviour
{
    public string playerName = "";
    // Start is called before the first frame update
    void Start()
    {
        playerName = PlayerPrefs.GetString("name");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {

        playerName = GUI.TextField(new Rect(5, 120, 100, 30), playerName);
        if (GUI.Button(new Rect(5, 180, 50, 50), "Save"))
        {
            PlayerPrefs.SetString("name", playerName);
        }
    }
}
