﻿using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Opening : MonoBehaviour
{
    public TextMeshProUGUI ContinueButton;
    public TextMeshProUGUI NewGameButton;
    public TextMeshProUGUI TutorialButton;


    // Localization Feature
    public Lang LangClass = new Lang(false);


    void Start()
    {
        LangClass.setLanguage(GlobalGameInfo.language);
        
        ContinueButton.text = LangClass.getString("continue");
        NewGameButton.text = LangClass.getString("new_game");
        TutorialButton.text = LangClass.getString("tutorial");

        // Loading game data
        Dictionary<string, SavedGame> data = SaveSerial.LoadGame();
        GlobalGameInfo.gameData = data;
    }


    public void onNewGameClick() {

        //set a session id if not there yet
        ResetGame.startGame();

        SceneManager.LoadScene("Backstories");
    }

    public void onTutorialClick() {

        //set a session id if not there yet

        // ResetGame.startGame();
        // SceneManager.LoadScene("Tutorial");
    }

    public void onContinueClick() {

        SceneManager.LoadScene("StartWeek");
    }
    
    
}
