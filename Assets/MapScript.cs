using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapScript : MonoBehaviour
{

    private static bool calendarIconPressed = false;
    public TextMeshProUGUI WeekText;
    public TextMeshProUGUI ShortDayText;
    public TextMeshProUGUI WeekTextPopup;
    public TextMeshProUGUI ShortDayTextPopup;
    public TextMeshProUGUI CalendarWeekTextPopup;
    public TextMeshProUGUI CalendarShortDayTextPopup;
    public TextMeshProUGUI MeetNPCText;
    public TextMeshProUGUI GoodMorningText;
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
    public TextMeshProUGUI MyJournalUpdated;
    public GameObject PhoneIcon;
    public GameObject CalendarIcon;
    public GameObject CalendarMessage;
    public GameObject BackButton;
    public GameObject ExitGame;
    public GameObject NPCAndTask;
    public GameObject GoTalkButton;
    public GameObject CalendarPopup;
    public Image RashadImage;
    public Image MrsLeeImage;
    public Image MrCalindasImage;
    public Image LilaImage;
    public Image ElisaImage;
    public GameObject blackOverlay;

    // Tutorial components
    public GameObject TutorialContainerTask;
    public GameObject TutorialArrowTask;
    public Button TutorialButtonTask;
    public TextMeshProUGUI YellowTitleTask;
    public TextMeshProUGUI WhiteTitleTask;
    public TextMeshProUGUI WhiteTextTask;
    public TextMeshProUGUI ButtonTextTask;
    public GameObject TutorialContainerNeighbors;
    public Button TutorialButtonNeighbors;
    public TextMeshProUGUI YellowTitleNeighbors;
    public TextMeshProUGUI WhiteTitleNeighbors;
    public TextMeshProUGUI WhiteTextNeighbors;
    public GameObject NeighborsImage;
    public TextMeshProUGUI ButtonTextNeighbors;
    public GameObject TutorialContainerPhone;
    public GameObject TutorialArrowPhone;
    public Button TutorialButtonPhone;
    public TextMeshProUGUI YellowTitlePhone;
    public TextMeshProUGUI WhiteTitlePhone;
    public TextMeshProUGUI WhiteTextPhone;
    public TextMeshProUGUI ButtonTextPhone;
    public GameObject TaskGlow;
    public GameObject PhoneGlow;
    public GameObject HelpButton;
    public TextMeshProUGUI HelpButtonText;

    private float secondsPassed = 0.0f;

    // Start is called before the first frame update
    private IEnumerator Start() {
        Destroy (GameObject.FindGameObjectWithTag("Music"));
        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicClass>().PlayMusic();

        MeetNPCText.text = GameStrings.getString("meet") + " " + CharacterResources.GetName(GlobalGameInfo.GetCurrentNPC());

        GoodMorningText.text = GameStrings.getString("good_morning_message");
        
        WeekText.text = GameStrings.getString("week") + " " + (GlobalGameInfo.GetCurrentWeek() + 1);
        WeekTextPopup.text = GameStrings.getString("week") + " " + (GlobalGameInfo.GetCurrentWeek() + 1);
        CalendarWeekTextPopup.text = GameStrings.getString("week") + " " + (GlobalGameInfo.GetCurrentWeek() + 1);
        MyJournalUpdated.text = GameStrings.getString("journal_updated");

        string day = GlobalGameInfo.GetCurrentDayAsString("short");
        ShortDayText.text = day;
        ShortDayTextPopup.text = day;
        CalendarShortDayTextPopup.text = day;

        CurrentTaskTitle.text = GameStrings.getString("current_task");
        CurrentTask.text = GlobalGameInfo.GetCurrentTask();
        CurrentNPC.text = CharacterResources.GetName(GlobalGameInfo.GetCurrentNPC());

        BackButtonText.text = GameStrings.getString("back");
        ExitButtonText.text = GameStrings.getString("exit_game");
        NumDaysLeft.text = (4 - GlobalGameInfo.GetCurrentDay()).ToString();
        DaysLeftText.text = GameStrings.getString("days_left");
        ToBlockParty.text = GameStrings.getString("to_block_party") + " " + CharacterResources.GetName(GlobalGameInfo.GetCurrentNPC());
        
        PleaseNote.text = GameStrings.getString("please_note");
        ProgressWontSave.text = GameStrings.getString("progress_wont_save");

        // Update NPC Image
        RashadImage.enabled = false;
        MrsLeeImage.enabled = false;
        MrCalindasImage.enabled = false;
        LilaImage.enabled = false;
        ElisaImage.enabled = false;

        switch (CurrentNPC.text) {
            case "Rashad":
                RashadImage.enabled = true;
                break;
            case "Mrs. Lee":
                MrsLeeImage.enabled = true;
                break;
            case "Mr. Calindas":
                MrCalindasImage.enabled = true;
                break;
            case "Lila":
                LilaImage.enabled = true;
                break;
            case "Elisa":
                ElisaImage.enabled = true;
                break;
            default:
                break;
        }

        if (GlobalGameInfo.weekEndedFlag) {
            GlobalGameInfo.weekEndedFlag = false;
            SceneManager.LoadScene("BlockParty");
        }

        if (GlobalGameInfo.gotalkFlag == true) {
            CalendarIcon.SetActive(false);
            PhoneIcon.SetActive(false);
            this.OpenGoTalkDialog();
        } else {
            // Tutorial
            if (!GlobalGameInfo.mapFlag) {

                while (true)
                {
                    yield return new WaitForSeconds(0.1f);
                    if (secondsPassed > 1.0f)
                    {
                        break;
                    }
                    else
                    {
                        secondsPassed += 0.1f;
                    }
                }

                this.activateTutorial();

                HelpButton.SetActive(true);
                HelpButtonText.text = GameStrings.getString("tutorial_help");
            }
        }
    }

    public void activateTutorial() {
        TutorialContainerTask.SetActive(true);
        TutorialArrowTask.SetActive(true);
        TaskGlow.SetActive(true);
        TutorialButtonTask.enabled = true;

        // Text for the task container
        YellowTitleTask.text = GameStrings.getString("task_map_yellowtitle");
        WhiteTitleTask.text = GameStrings.getString("task_map_whitetitle");
        WhiteTextTask.text = GameStrings.getString("task_map_whitetext");
        ButtonTextTask.text = GameStrings.getString("task_map_buttontext");

        // Text for the neighbors container
        YellowTitleNeighbors.text = GameStrings.getString("neighbors_map_yellowtitle");
        WhiteTitleNeighbors.text = GameStrings.getString("neighbors_map_whitetitle");
        WhiteTextNeighbors.text = GameStrings.getString("neighbors_map_whitetext");
        ButtonTextNeighbors.text = GameStrings.getString("neighbors_map_buttontext");

        // Text for the phone container
        YellowTitlePhone.text = GameStrings.getString("phone_map_yellowtitle");
        WhiteTitlePhone.text = GameStrings.getString("phone_map_whitetitle");
        WhiteTextPhone.text = GameStrings.getString("phone_map_whitetext");
        ButtonTextPhone.text = GameStrings.getString("phone_map_buttontext");
    }

    public void tutorialTaskClick() {
        TutorialContainerTask.SetActive(false);
        TutorialArrowTask.SetActive(false);
        TaskGlow.SetActive(false);
        TutorialButtonTask.enabled = false;

        TutorialContainerNeighbors.SetActive(true);
        TutorialButtonNeighbors.enabled = true;
        NeighborsImage.SetActive(true);
        blackOverlay.SetActive(true);
    }
    public void tutorialNeighborsClick() {
        TutorialContainerNeighbors.SetActive(false);
        TutorialButtonNeighbors.enabled = false;
        NeighborsImage.SetActive(false);
        blackOverlay.SetActive(false);

        TutorialContainerPhone.SetActive(true);
        TutorialArrowPhone.SetActive(true);
        PhoneGlow.SetActive(true);
        TutorialButtonPhone.enabled = true;
    }
    public void tutorialPhoneClick() {
        TutorialContainerPhone.SetActive(false);
        TutorialArrowPhone.SetActive(false);
        PhoneGlow.SetActive(false);
        TutorialButtonPhone.enabled = false;

        GlobalGameInfo.mapFlag = true;
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
            if (blackOverlay != null)
            {
                blackOverlay.SetActive(true);
            }
        } else {
            NPCAndTask.transform.position = new Vector3(1024, 768, 0f);
            if (blackOverlay != null)
            {
                blackOverlay.SetActive(false);
            }
        }

        // Show back button
        BackButton.SetActive(calendarIconPressed);
        
        // Show calendar message
        CalendarMessage.SetActive(calendarIconPressed);
    }

    public void GoTalk() {
        InkFileManager ifm = new InkFileManager();
        if (!GlobalGameInfo.gotalkFlag) {
            ifm.setActiveFileIdx((-1, -1));
        }
        ifm.TryLoadVNScene(CharacterResources.GetName(GlobalGameInfo.GetCurrentNPC()));
    }

    public void GoToOpeningScreen() {
        // Go back to opening screen
        Destroy (GameObject.FindGameObjectWithTag("Music"));
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

    public void OpenGoTalkDialog() {
        CalendarPopup.SetActive(true);
        blackOverlay.SetActive(true);
        GlobalGameInfo.gotalkFlag = false;
    }
}
