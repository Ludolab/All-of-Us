using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapScript : MonoBehaviour
{

    public TextMeshProUGUI WeekText;
    public TextMeshProUGUI ShortDayText;
    public TextMeshProUGUI CurrentTaskTitle;
    public TextMeshProUGUI CurrentTask;
    public TextMeshProUGUI CurrentNPC;
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

        // Update NPC Image

    }

    void CalendarIcon()
    {
        // Remove phone icon

        // Remove calendar icon

        // Move object of NPC and task
        
        // Show back button
        
        // Show calendar pop up

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
