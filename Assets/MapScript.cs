using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapScript : MonoBehaviour
{

    public bool calendarIconPressed = false;
    public TextMeshProUGUI WeekText;
    public TextMeshProUGUI ShortDayText;
    public TextMeshProUGUI CurrentTaskTitle;
    public TextMeshProUGUI CurrentTask;
    public TextMeshProUGUI CurrentNPC;
    public TextMeshProUGUI BackButtonText;
    public TextMeshProUGUI ExitButtonText;
    public TextMeshProUGUI NumDaysLeft;
    public TextMeshProUGUI DaysLeftText;
    public TextMeshProUGUI ToBlockParty;
    public TextMeshProUGUI PleaseNote;
    public TextMeshProUGUI ProgressWontSave;
    public GameObject PhoneIcon;
    public GameObject CalendarIcon;
    public GameObject CalendarMessage;
    public GameObject BackButton;
    public GameObject ExitGame;
    public GameObject NPCAndTask;
    public Image NPCImage;
    
    // Localization Feature
    public Lang LangClass = new Lang(false);

    // Start is called before the first frame update
    private void Start() {
        LangClass.setLanguage(GlobalGameInfo.language);

        WeekText.text = LangClass.getString("week") + " " + (GlobalGameInfo.GetCurrentWeek() + 1);
        ShortDayText.text = LangClass.getString("wednesday_short");
        CurrentTaskTitle.text = LangClass.getString("current_task");
        CurrentTask.text = GlobalGameInfo.GetCurrentTask();
        CurrentNPC.text = GlobalGameInfo.GetCurrentNPC();

        BackButtonText.text = LangClass.getString("back");
        ExitButtonText.text = LangClass.getString("exit_game");
        NumDaysLeft.text = (4 - GlobalGameInfo.GetCurrentDay()).ToString();
        DaysLeftText.text = LangClass.getString("days_left");
        ToBlockParty.text = LangClass.getString("to_block_party") + " " + GlobalGameInfo.GetCurrentNPC();
        
        PleaseNote.text = LangClass.getString("please_note");
        ProgressWontSave.text = LangClass.getString("progress_wont_save");

        // Update NPC Image

    }

    public void toggleCalendarIcon()
    {
        // Update calendar pressed flag
        calendarIconPressed = !calendarIconPressed;

        // Remove phone icon
        PhoneIcon.SetActive(!calendarIconPressed);

        // Remove calendar icon
        CalendarIcon.SetActive(!calendarIconPressed);

        // Move object of NPC and task
        if (calendarIconPressed) {
            NPCAndTask.transform.position = new Vector3(1324, 768, 0f);
        } else {
            NPCAndTask.transform.position = new Vector3(1024, 768, 0f);
        }

        // Show back button
        BackButton.SetActive(calendarIconPressed);
        
        // Show calendar message
        CalendarMessage.SetActive(calendarIconPressed);


    }

    public void GoToOpeningScreen() {
        // Go back to opening screen
        SceneManager.LoadScene("OpeningScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Awake() {
        if (GlobalGameInfo.getNewDayVariable()) {
            HintBubbleManager.ActivateHintBubble("Good Morning!", "It's a new day in Bloomwood!");
            GlobalGameInfo.toggleNewDay();
        }
        
    }
}
