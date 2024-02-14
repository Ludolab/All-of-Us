using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Opening : MonoBehaviour
{
    public TextMeshProUGUI ContinueButtonText;
    public TextMeshProUGUI CreditsButton;
    public TextMeshProUGUI NewGameButton;
    public GameObject ContinueButton;
    public bool IgnoreSaveData = false;

    void Start()
    {

        Debug.Log(Application.persistentDataPath);

        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicClass>().PlayMusic();
        
        ContinueButtonText.text = GameStrings.getString("continue");
        NewGameButton.text = GameStrings.getString("new_game");
        CreditsButton.text = GameStrings.getString("credits");

#if UNITY_EDITOR
        SaveSerial.IgnoreSaveData = IgnoreSaveData;
#endif

        // Loading game data
        GlobalGameInfo.gameData = SaveSerial.LoadGame();


        // Show continue button
        if (GlobalGameInfo.gameData != null) {
            ContinueButton.SetActive(true);
        }

    }


    public void onNewGameClick() {

        //set a session id if not there yet
        ResetGame.startGame();

        SceneManager.LoadScene("PCSetUp");
    }

    public void onContinueClick() {

        SceneManager.LoadScene("StartWeek");
    }
    
    public void onCreditsClick() {

        SceneManager.LoadScene("Credits");
    }
    
}
