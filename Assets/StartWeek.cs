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
    public TextMeshProUGUI StartWeekText1;
    public TextMeshProUGUI StartWeekText2;
    
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

    public GameObject blackOverlay;
    
    // Tutorial components
    public GameObject TutorialContainer;
    public GameObject TutorialArrow;
    public Button TutorialButton;
    public TextMeshProUGUI YellowTitle;
    public TextMeshProUGUI WhiteTitle;
    public TextMeshProUGUI WhiteText;
    public TextMeshProUGUI ButtonText;
    public GameObject Glow;


    public Lang LangClass = new Lang(false);
    
    // Start is called before the first frame update
    void Start()
    {

        // If arrived from PCSetup, go to select profile
        if (GlobalGameInfo.goToSelectProfileFlag) {
            GlobalGameInfo.goToSelectProfileFlag = false;
            this.clickOnSavedGame(GlobalGameInfo.savedGame);
        }

        // If arrived from ending a week in the game, go to select profile
        if (GlobalGameInfo.weekEndedFlag) {
            GlobalGameInfo.weekEndedFlag = false;
            this.clickOnSavedGame(GlobalGameInfo.savedGame);
        }

        Title.text = LangClass.getString("saved_games");

        int y_location = 152;
        int gameNum = 1;

        foreach(KeyValuePair<string, SavedGame> pair in GlobalGameInfo.gameData) {
            GameObject savedGameItem = Instantiate(prefabSavedGameItem, new Vector3(-330f, y_location, 0f), Quaternion.identity);

            UnityEngine.UI.Button btn = savedGameItem.GetComponent<Button>();

            if (savedGameItem != null) {

                btn.onClick.AddListener(delegate{clickOnSavedGame(pair.Value);});
                
                savedGameItem.transform.SetParent (GameObject.FindGameObjectWithTag("Content").transform, false);
                
                TextMeshProUGUI playerText = savedGameItem.transform.Find("Player").GetComponent<TextMeshProUGUI>();
                playerText.text = "Player: " + pair.Value.getName();

                TextMeshProUGUI weekAndDay = savedGameItem.transform.Find("Week and Day").GetComponent<TextMeshProUGUI>();
                weekAndDay.text = "Week " + (pair.Value.getWeek() + 1) + ", Day " + (pair.Value.getDay() + 1);
                
                TextMeshProUGUI numberText = savedGameItem.transform.Find("Number Text").GetComponent<TextMeshProUGUI>();
                numberText.text = gameNum.ToString();

                TextMeshProUGUI completedText = savedGameItem.transform.Find("Completed Text").GetComponent<TextMeshProUGUI>();
                completedText.text = (pair.Value.getWeek()) + "/5 " + LangClass.getString("completed");

                this.loadCompletedBarImage(savedGameItem, pair.Value.getWeek());
            }

            y_location -= 135;
            gameNum++;
        }
    }

    public void loadCompletedBarImage(GameObject savedGameItem, int week) {
        Image completedBar = savedGameItem.transform.Find("Completed Bar").GetComponent<Image>();
        completedBar.sprite = Resources.Load<Sprite>("Sprites/Completed" + week);

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void clickOnSavedGame(SavedGame savedGame) {

        GlobalGameInfo.savedGame = savedGame;
        // Change view to selecting a profile
        Title.text = LangClass.getString("next_npc");
        // Load game slot into Global Game Info
        SavingGame.LoadGameProgress(savedGame);

        // If player is in the middle of quest - go back to open quest
        if (savedGame.isInMiddleOFQuest()) {
            this.goBackToOpenQuest(savedGame.getNPCForWeek());
        }

        // Updating local variables
        ScrollView.SetActive(false);
        blackOverlay.SetActive(true);
        SelectProfile.SetActive(true);
        SelectProfileText.enabled = true;

        // Tutorial
        if (!GlobalGameInfo.startWeekFlag) {
            TutorialContainer.SetActive(true);
            TutorialArrow.SetActive(true);
            Glow.SetActive(true);
            TutorialButton.enabled = true;

            YellowTitle.text = LangClass.getString("tutorial_startweek_yellowtitle");
            WhiteTitle.text = LangClass.getString("tutorial_startweek_whitetitle");
            WhiteText.text = LangClass.getString("tutorial_startweek_whitetext_1") + GlobalGameInfo.name + LangClass.getString("tutorial_startweek_whitetext_2");
            ButtonText.text = LangClass.getString("tutorial_startweek_buttontext");
        }

        RashadCompleted.enabled = (savedGame.getProgress()[CharacterResources.CHARACTERS.RASHAD] == 2);
        Rashad0.SetActive(savedGame.getProgress()[CharacterResources.CHARACTERS.RASHAD] == 0);
        Rashad1.SetActive(savedGame.getProgress()[CharacterResources.CHARACTERS.RASHAD] == 2);

        MrsLeeCompleted.enabled = (savedGame.getProgress()[CharacterResources.CHARACTERS.LEE] == 2);
        MrsLee0.SetActive(savedGame.getProgress()[CharacterResources.CHARACTERS.LEE] == 0);
        MrsLee1.SetActive(savedGame.getProgress()[CharacterResources.CHARACTERS.LEE] == 2);

        MrCalindasCompleted.enabled = (savedGame.getProgress()[CharacterResources.CHARACTERS.CALINDAS] == 2);
        MrCalindas0.SetActive(savedGame.getProgress()[CharacterResources.CHARACTERS.CALINDAS] == 0);
        MrCalindas1.SetActive(savedGame.getProgress()[CharacterResources.CHARACTERS.CALINDAS] == 2);

        LilaCompleted.enabled = (savedGame.getProgress()[CharacterResources.CHARACTERS.LILA] == 2);
        Lila0.SetActive(savedGame.getProgress()[CharacterResources.CHARACTERS.LILA] == 0);
        Lila1.SetActive(savedGame.getProgress()[CharacterResources.CHARACTERS.LILA] == 2);

        ElisaCompleted.enabled = (savedGame.getProgress()[CharacterResources.CHARACTERS.ELISA] == 2);
        Elisa0.SetActive(savedGame.getProgress()[CharacterResources.CHARACTERS.ELISA] == 0);
        Elisa1.SetActive(savedGame.getProgress()[CharacterResources.CHARACTERS.ELISA] == 2);

        LangClass.setLanguage(GlobalGameInfo.language);

    }

    public void tutorialClick() {
        TutorialContainer.SetActive(false);
        TutorialArrow.SetActive(false);
        Glow.SetActive(false);
        TutorialButton.enabled = false;
        GlobalGameInfo.startWeekFlag = true;
    }

    public void resetCharacterCards() {
        RashadCard.SetActive(false);
        LilaCard.SetActive(false);
        ElisaCard.SetActive(false);
        MrCalindasCard.SetActive(false);
        MrsLeeCard.SetActive(false);
    }
    
    public void goBackToOpenQuest(CharacterResources.CHARACTERS NPCOfCurrentQuest) {
        GlobalGameInfo.SetCurrentNPC(NPCOfCurrentQuest);
        GlobalGameInfo.gotalkFlag = true;
        SceneManager.LoadScene("Basic2DMap");
    }

    public void selectNPC(string NPC) {

        // Show NPC's character card
        StartWeekContainer.SetActive(true);
        StartWeekText1.text = LangClass.getString("startweek_text1") + " " + NPC + " " + LangClass.getString("startweek_text2");
        StartWeekText2.text = LangClass.getString("startweek_text3");
        GlobalGameInfo.SetCurrentNPC(CharacterResources.GetCharacterFromString(NPC));
        GlobalGameInfo.gotalkFlag = true;
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
        SavingGame.setNPCOfCurrentQuest(GlobalGameInfo.GetCurrentNPC());
        // Go back to opening screen
        SceneManager.LoadScene("Basic2DMap");
    }

    public void GoToPCSetupScene() {
        // Go back to opening screen
        SceneManager.LoadScene("PCSetUp");
    }
}
