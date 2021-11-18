﻿using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System.IO;
using System.Collections.Generic;

public class PCSetUp : MonoBehaviour
{
    public InputField nameInputField;
    public TextMeshProUGUI TitleText;
    public TextMeshProUGUI NameText;
    public TextMeshProUGUI PronounsText;
    public TextMeshProUGUI LanguageText;
    public TextMeshProUGUI ContinueText;
    public TextMeshProUGUI InactiveContinueText;
    public Text pronounsDropDownLabel;
    public Text languageDropDownLabel;
    public Text nameFieldPlaceholder;
    public Dropdown pronounsDropDown;
    public Dropdown languageDropDown;
    public GameObject backButton;
    public Button continueButton;
    public Button inactiveContinueButton;
    private string firstName = "";
    private int intPronouns = 0;
    private string pronouns;
    private int intLanguage = 0;
    private string language;
    
    // Localization Feature
    public Lang LangClass = new Lang(false);

    // Start is called before the first frame update
    void Start()
    {
        LangClass.setLanguage(GlobalGameInfo.language);
        
        // Setting texts from Strings.xml
        NameText.text = LangClass.getString("name_field");
        PronounsText.text = LangClass.getString("pronouns_field");
        LanguageText.text = LangClass.getString("language_field");
        nameFieldPlaceholder.text = LangClass.getString("first_name");

        // Control continue buttons
        continueButton.gameObject.SetActive(false);
        inactiveContinueButton.gameObject.SetActive(true);

        // Setting dropdown lists
        List<string> pronounsDropDownOptions = new List<string> { LangClass.getString("choose_one"), LangClass.getString("she_her"), LangClass.getString("he_his"), LangClass.getString("they_them")};
        List<string> languageDropDownOptions = new List<string> { LangClass.getString("choose_one"), LangClass.getString("english"), LangClass.getString("spanish")};

        pronounsDropDown.ClearOptions();
        pronounsDropDown.AddOptions(pronounsDropDownOptions);
        languageDropDown.ClearOptions();
        languageDropDown.AddOptions(languageDropDownOptions);


        string buttonText = "";
        if (SceneManager.GetActiveScene().name == "PCSetUp") {
            buttonText = LangClass.getString("continue");
            TitleText.text = LangClass.getString("pc_setup_title");
        } else {
            // Populate data from current settings
            firstName = GlobalGameInfo.name;
            nameInputField.text = GlobalGameInfo.name;

            intPronouns = GlobalGameInfo.pronounsInt;
            pronounsDropDown.value = intPronouns;

            intLanguage = GlobalGameInfo.languageInt;
            languageDropDown.value = intLanguage;

            buttonText = LangClass.getString("save");
        }

        ContinueText.text = buttonText;
        InactiveContinueText.text = buttonText;

    }

    // Update is called once per frame
    void Update()
    {
        firstName = nameInputField.GetComponent<InputField>().text;
        intPronouns = pronounsDropDown.value;
        intLanguage = languageDropDown.value;

        if (firstName != null && !firstName.Equals("") && intPronouns != 0 && intLanguage != 0)
        {
            continueButton.gameObject.SetActive(true);
            inactiveContinueButton.gameObject.SetActive(false);
        } else {
            continueButton.gameObject.SetActive(false);
            inactiveContinueButton.gameObject.SetActive(true);
        }
    }

    public void goBack() {
        SceneManager.LoadScene("OpeningScene");
    }

    public void Submit()
    {
        if (firstName == null || firstName.Equals("") || intPronouns == 0 || intLanguage == 0)
        {
            Debug.Log("Name, Pronouns, and Language cannot be empty");
            return;
        }

        if (isTaken(firstName)) {
            Debug.Log("Name is already taken");
            return;
        }

        GlobalGameInfo.name = firstName;
        GlobalGameInfo.pronouns = GetPronouns(intPronouns);
        GlobalGameInfo.language = GetLanguages(intLanguage);
        GlobalGameInfo.pronounsInt = pronounsDropDown.value;
        GlobalGameInfo.languageInt = languageDropDown.value;

        // Change the language globally
        LangClass.setLanguage(GetLanguages(intLanguage));
        
        // Add new player to saved data
        Dictionary<string, SavedGame> currentData = SaveSerial.LoadGame();
        if (currentData == null) {
            currentData = new Dictionary<string, SavedGame>();
        }
        SavedGame newPlayer = new SavedGame(firstName);
        newPlayer.setLanguage(GetLanguages(intLanguage));
        GlobalGameInfo.savedGame = newPlayer;
        currentData.Add(firstName, newPlayer);
        SaveSerial.SaveGame(currentData);
        
        if (SceneManager.GetActiveScene().name != "PCSetUp") {
            // Coming from phone scene
            SceneManager.LoadScene("Basic2DMap");
        } else {
            // Coming from PCsetup scene
            GlobalGameInfo.pcsetupCalled = true;
            SceneManager.LoadScene("StartWeek");
        }


    }

    private bool isTaken(string name) {
        Dictionary<string, SavedGame> data = SaveSerial.LoadGame();
        if (data == null) return false;
        foreach(KeyValuePair<string, SavedGame> pair in data) {
            if (pair.Value.getName() == name) return true;
        }
        return false;
    }

    private string GetPronouns(int intPronouns)
    {
        switch (intPronouns)
        {
            case 1:
                return LangClass.getString("she_her");
            case 2:
                return LangClass.getString("he_his");
            case 3:
                return LangClass.getString("they_them");
            default:
                return null;
        }
    }

    private string GetLanguages(int intLanguage)
    {
        switch (intLanguage)
        {
            case 1:
                return LangClass.getString("english");
            case 2:
                return LangClass.getString("spanish");
            default:
                return null;
        }
    }
}
