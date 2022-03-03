﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;


public class PCSetUpDropdowns : MonoBehaviour
{
    public Dropdown pronounsDropDown;
    public Dropdown languageDropDown;
    
    // Localization Feature
    public Lang LangClass = new Lang();

    // Start is called before the first frame update
    void Start()
    {
        

        // Setting dropdown lists
        List<string> pronounsDropDownOptions = new List<string> { "", LangClass.getString("she_her"), LangClass.getString("he_his"), LangClass.getString("they_them"), LangClass.getString("other")};
        List<string> languageDropDownOptions = new List<string> { "", LangClass.getString("english"), LangClass.getString("spanish")};

        pronounsDropDown.AddOptions(pronounsDropDownOptions);
        languageDropDown.AddOptions(languageDropDownOptions);
    }
}
