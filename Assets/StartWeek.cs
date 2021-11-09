﻿using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;
using System.Threading;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class StartWeek : MonoBehaviour
{

    static public List<GameObject> savedGamesUI;
    public GameObject prefabSavedGameItem;
    public GameObject BackButton;
    public TextMeshProUGUI Title;
    public GameObject ScrollView;
    public string[][] savedGamesInfo = new string[6][];
    public GameObject SelectProfile;
    public GameObject StartWeekContainer;
    public TextMeshProUGUI SelectProfileText;
    public TextMeshProUGUI SelectedNPC;
    
    // NPC images
    public GameObject Rashad0;
    public GameObject Rashad1;
    public TextMeshProUGUI RashadCompleted;
    public GameObject Lila0;
    public GameObject Lila1;
    public TextMeshProUGUI LilaCompleted;
    public GameObject Elisa0;
    public GameObject Elisa1;
    public TextMeshProUGUI ElisaCompleted;
    public GameObject MrCalindas0;
    public GameObject MrCalindas1;
    public TextMeshProUGUI MrCalindasCompleted;
    public GameObject MrsLee0;
    public GameObject MrsLee1;
    public TextMeshProUGUI MrsLeeCompleted;

    // Character Cards
    public GameObject ElisaCard;
    public GameObject RashadCard;
    public GameObject LilaCard;
    public GameObject MrCalindasCard;
    public GameObject MrsLeeCard;

    public TextMeshProUGUI CharacterCardName;
    public TextMeshProUGUI CharacterCardAgePronouns;
    public TextMeshProUGUI CharacterCardTitle;
    public TextMeshProUGUI CharacterCardDescription;


    public Lang LangClass = new Lang(false);
    SavedGame currentGame;
    
    // Start is called before the first frame update
    void Start()
    {

        // List<SavedGame> dataToStore = new List<SavedGame>();
        // exampleSG.setCharacterDone("Rashad");
        // exampleSG.incDay();
        // exampleSG.incWeek();
        // dataToStore.Add(exampleSG);
        // dataToStore.Add(exampleSG2);
        // dataToStore.Add(exampleSG3);
        // SaveSerial.SaveGame(dataToStore);

        List<SavedGame> data = SaveSerial.LoadGame();

        Title.text = LangClass.getString("saved_games");

        int y_location = 152;
        int gameNum = 1;

        foreach(SavedGame savedGame in data) {
            GameObject savedGameItem = Instantiate(prefabSavedGameItem, new Vector3(-330f, y_location, 0f), Quaternion.identity);

            UnityEngine.UI.Button btn = savedGameItem.GetComponent<Button>();
            btn.onClick.AddListener(delegate{clickOnSavedGame(savedGame);});

            if (savedGameItem != null) {
                savedGameItem.transform.SetParent (GameObject.FindGameObjectWithTag("Content").transform, false);
                
                TextMeshProUGUI playerText = savedGameItem.transform.Find("Player").GetComponent<TextMeshProUGUI>();
                playerText.text = savedGame.getName();

                TextMeshProUGUI weekAndDay = savedGameItem.transform.Find("Week and Day").GetComponent<TextMeshProUGUI>();
                weekAndDay.text = "Week " + savedGame.getWeek() + ", Day " + savedGame.getDay();
                
                TextMeshProUGUI numberText = savedGameItem.transform.Find("Number Text").GetComponent<TextMeshProUGUI>();
                numberText.text = gameNum.ToString();
            }
            y_location -= 135;
            gameNum++;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void clickOnSavedGame(SavedGame savedGame) {

        // Change view to selecting a profile
        Title.text = LangClass.getString("next_npc");
        ScrollView.SetActive(false);
        currentGame = savedGame;

        SelectProfile.SetActive(true);
        SelectProfileText.enabled = true;

        RashadCompleted.enabled = (savedGame.getProgress()["Rashad"] == 1);
        Rashad0.SetActive(savedGame.getProgress()["Rashad"] == 0);
        Rashad1.SetActive(savedGame.getProgress()["Rashad"] == 1);

        MrsLeeCompleted.enabled = (savedGame.getProgress()["MrsLee"] == 1);
        MrsLee0.SetActive(savedGame.getProgress()["MrsLee"] == 0);
        MrsLee1.SetActive(savedGame.getProgress()["MrsLee"] == 1);

        MrCalindasCompleted.enabled = (savedGame.getProgress()["MrCalindas"] == 1);
        MrCalindas0.SetActive(savedGame.getProgress()["MrCalindas"] == 0);
        MrCalindas1.SetActive(savedGame.getProgress()["MrCalindas"] == 1);

        LilaCompleted.enabled = (savedGame.getProgress()["Lila"] == 1);
        Lila0.SetActive(savedGame.getProgress()["Lila"] == 0);
        Lila1.SetActive(savedGame.getProgress()["Lila"] == 1);

        ElisaCompleted.enabled = (savedGame.getProgress()["Elisa"] == 1);
        Elisa0.SetActive(savedGame.getProgress()["Elisa"] == 0);
        Elisa1.SetActive(savedGame.getProgress()["Elisa"] == 1);

    }

    public void resetCharacterCards() {
        RashadCard.SetActive(false);
        LilaCard.SetActive(false);
        ElisaCard.SetActive(false);
        MrCalindasCard.SetActive(false);
        MrsLeeCard.SetActive(false);
    }
    public void selectNPC(string NPC) {

        // Show NPC's character card
        StartWeekContainer.SetActive(true);
        SelectedNPC.text = NPC + "?";
        GlobalGameInfo.SetCurrentNPC(NPC);
        this.resetCharacterCards();

        // Update the current NPC in the global script
        switch (NPC) {
            case "Rashad":
                RashadCard.SetActive(true);
                CharacterCardName.text = LangClass.getString("rashad_name");
                CharacterCardAgePronouns.text = LangClass.getString("rashad_age_pronouns");
                CharacterCardTitle.text = LangClass.getString("rashad_title");
                CharacterCardDescription.text = LangClass.getString("rashad_description");
                break;
            case "Lila":
                LilaCard.SetActive(true);
                CharacterCardName.text = LangClass.getString("lila_name");
                CharacterCardAgePronouns.text = LangClass.getString("lila_age_pronouns");
                CharacterCardTitle.text = LangClass.getString("lila_title");
                CharacterCardDescription.text = LangClass.getString("lila_description");
                break;
            case "Elisa":
                ElisaCard.SetActive(true);
                CharacterCardName.text = LangClass.getString("elisa_name");
                CharacterCardAgePronouns.text = LangClass.getString("elisa_age_pronouns");
                CharacterCardTitle.text = LangClass.getString("elisa_title");
                CharacterCardDescription.text = LangClass.getString("elisa_description");
                break;
            case "Mr. Calindas":
                MrCalindasCard.SetActive(true);
                CharacterCardName.text = LangClass.getString("mrcalindas_name");
                CharacterCardAgePronouns.text = LangClass.getString("mrcalindas_age_pronouns");
                CharacterCardTitle.text = LangClass.getString("mrcalindas_title");
                CharacterCardDescription.text = LangClass.getString("mrcalindas_description");
                break;
            case "Mrs. Lee":
                MrsLeeCard.SetActive(true);
                CharacterCardName.text = LangClass.getString("mrslee_name");
                CharacterCardAgePronouns.text = LangClass.getString("mrslee_age_pronouns");
                CharacterCardTitle.text = LangClass.getString("mrslee_title");
                CharacterCardDescription.text = LangClass.getString("mrslee_description");
                break;
            default:
                break;
        }
        
        // Rashad0.gameObject.transform.localScale += new Vector3(0.2f, 0.2f, 0);
    }

    public void GoToOpeningScreen() {
        // Go back to opening screen
        SceneManager.LoadScene("OpeningScene");
    }

    public void GoToMapScene() {
        // Go back to opening screen
        SceneManager.LoadScene("Basic2DMap");
    }
}
