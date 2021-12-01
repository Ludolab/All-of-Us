﻿using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Backstories : MonoBehaviour

{
    private int current_text_counter = 1;
    public Text Textfield;
    public TextMeshProUGUI NextText;
    public GameObject NextButton;

    // Localization Feature
    public Lang LangClass = new Lang(false);

    void Start()
    {
        LangClass.setLanguage(GlobalGameInfo.language);

        Textfield.text = LangClass.getString("backstories_1");
        NextText.text = LangClass.getString("next");
    }


    public void setNextText() {
        switch (current_text_counter) {
            case 1:
                Textfield.text = LangClass.getString("backstories_2");
                current_text_counter++;
                break;
            case 2:
                Textfield.text = LangClass.getString("backstories_3");
                current_text_counter++;
                break;
            case 3:
                Textfield.text = LangClass.getString("backstories_4");
                current_text_counter++;
                break;
            default:
                SceneManager.LoadScene("PCSetup");
                current_text_counter = 1;
                break;
        }
            
    }
    
}