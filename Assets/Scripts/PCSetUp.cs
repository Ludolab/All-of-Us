using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System.IO;
using System.Collections.Generic;

public class PCSetUp : MonoBehaviour
{
    public InputField nameInputField;
    public TextMeshProUGUI WelcomeTitle;
    public TextMeshProUGUI WelcomeText;
    public TextMeshProUGUI NameText;
    public TextMeshProUGUI PronounsText;
    public TextMeshProUGUI LanguageText;
    public TextMeshProUGUI ContinueText;
    public TextMeshProUGUI InactiveContinueText;
    public TextMeshProUGUI BackButtonText;
    public InputField codeInputField;
    public TextMeshProUGUI codeText;
    public Text codeFieldPlaceholder;
    public Text pronounsDropDownLabel;
    public Text languageDropDownLabel;
    public Text nameFieldPlaceholder;
    public Dropdown pronounsDropDown;
    public Dropdown languageDropDown;
    public GameObject backButton;
    public Image NameError;
    public TextMeshProUGUI NameErrorText;
    public Button continueButton;
    public Button inactiveContinueButton;
    private string firstName = "";
    private string playerCode = "";
    private string pronouns;
    private string language;
    
    // Start is called before the first frame update
    void Start()
    {

        NameText.text = GameStrings.getString("name_field");
        codeText.text = GameStrings.getString("code_field");
        PronounsText.text = GameStrings.getString("pronouns_field");
        LanguageText.text = GameStrings.getString("language_field");
        nameFieldPlaceholder.text = GameStrings.getString("first_name");
        BackButtonText.text = GameStrings.getString("back");

        // Setting dropdown lists' options is done in the script PCSetUpDropdowns

        string buttonText = "";
        if (SceneManager.GetActiveScene().name == "PCSetUp") {
            buttonText = GameStrings.getString("continue");
            WelcomeTitle.text = GameStrings.getString("welcome_title");
            WelcomeText.text = GameStrings.getString("welcome_text");

            // Control continue buttons
            continueButton.gameObject.SetActive(false);
            inactiveContinueButton.gameObject.SetActive(true);
        } else {

            // Populate data from current settings
            firstName = GlobalGameInfo.name;
            playerCode = GlobalGameInfo.playerCode;
            nameInputField.text = firstName;
            codeInputField.text = playerCode;

            pronounsDropDown.value = GlobalGameInfo.pronounsInt;
            languageDropDown.value = GlobalGameInfo.languageInt;

            buttonText = GameStrings.getString("save");

            // Control continue buttons
            continueButton.gameObject.SetActive(true);
            inactiveContinueButton.gameObject.SetActive(false);
        }

        ContinueText.text = buttonText;
        InactiveContinueText.text = buttonText;

    }

    // Update is called once per frame
    public void Update()
    {
        firstName = nameInputField.GetComponent<InputField>().text;
        playerCode = codeInputField.GetComponent<InputField>().text;

        if (firstName != null && !firstName.Equals("") && pronounsDropDown.value != 0 && languageDropDown.value != 0 && playerCode != null) {
            continueButton.gameObject.SetActive(true);
            inactiveContinueButton.gameObject.SetActive(false);
        } else {
            continueButton.gameObject.SetActive(false);
            inactiveContinueButton.gameObject.SetActive(true);
        }
    }

    public void onEditData() {
        NameError.gameObject.SetActive(false);
        NameErrorText.text = "";
    }

    public void goBack() {
        SceneManager.LoadScene("OpeningScene");
    }

    public void Submit()
    {
        string previousName = GlobalGameInfo.name;

        if (SceneManager.GetActiveScene().name == "PCSetUp" && isTaken(firstName)
        || previousName != firstName && isTaken(firstName)) {
            NameError.gameObject.SetActive(true);
            NameErrorText.text = GameStrings.getString("name_taken");
            return;
        }

        GlobalGameInfo.name = firstName;
        GlobalGameInfo.playerCode = playerCode;
        GlobalGameInfo.pronouns = GetPronouns(pronounsDropDown.value);
        GlobalGameInfo.language = GetLanguages(languageDropDown.value);
        GlobalGameInfo.pronounsInt = pronounsDropDown.value;
        GlobalGameInfo.languageInt = languageDropDown.value;

        // TODO consider moving some parts here to the SavingGame script
        if (SceneManager.GetActiveScene().name == "PCSetUp") {
            // Add new player to saved data
            Dictionary<string, SavedGame> currentData = GlobalGameInfo.gameData;
            if (currentData == null) {
                currentData = new Dictionary<string, SavedGame>();
                GlobalGameInfo.gameData = currentData;
            }
            SavedGame newPlayer = new SavedGame(firstName);

            GlobalGameInfo.savedGame = newPlayer;
            currentData.Add(firstName, newPlayer);
            SaveSerial.SaveGame(currentData);
            
            // Coming from PCsetup scene
            GlobalGameInfo.goToSelectProfileFlag = true;
            SceneManager.LoadScene("StartWeek");
        } else {
            Dictionary<string, SavedGame> currentData = GlobalGameInfo.gameData;
            SavedGame current = GlobalGameInfo.savedGame;
            current.setName(GlobalGameInfo.name);
            current.setPronouns(GlobalGameInfo.pronouns);
            current.setLanguage(GlobalGameInfo.language);
            current.setPronounsInt(GlobalGameInfo.pronounsInt);
            current.setLanguageInt(GlobalGameInfo.languageInt);

            currentData.Remove(previousName);
            currentData.Add(GlobalGameInfo.name, current);
            // Pronouns are not used currently in the game
            SaveSerial.SaveGame(currentData);

            // Coming from phone scene
            SceneManager.LoadScene("Map");
        }
    }

    private bool isTaken(string name) {
        Dictionary<string, SavedGame> data = GlobalGameInfo.gameData;
        if (data == null) return false;
        foreach(KeyValuePair<string, SavedGame> pair in data) {
            if (pair.Value.getName().Equals(name)) return true;
        }
        return false;
    }

    private string GetPronouns(int intPronouns)
    {
        switch (intPronouns)
        {
            case 1:
                return GameStrings.getString("she_her");
            case 2:
                return GameStrings.getString("he_his");
            case 3:
                return GameStrings.getString("they_them");
            case 4:
                return GameStrings.getString("other");
            default:
                return null;
        }
    }

    private string GetLanguages(int intLanguage)
    {
        switch (intLanguage)
        {
            case 1:
                return GameStrings.getString("english");
            case 2:
                return GameStrings.getString("spanish");
            default:
                return null;
        }
    }
}
