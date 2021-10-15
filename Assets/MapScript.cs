using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public GameObject PhoneIcon;
    public GameObject CalendarIcon;
    public GameObject CalendarMessage;
    public GameObject BackButton;
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
        // NPCAndTask.transform.position = NPCAndTask.transform.position + new Vector3 (1f, 0f, 0f);

        // Show back button
        BackButton.SetActive(calendarIconPressed);
        
        // Show calendar message
        CalendarMessage.SetActive(calendarIconPressed);


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
