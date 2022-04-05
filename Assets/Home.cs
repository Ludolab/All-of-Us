using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Reflection;
using System.Threading;
public class Home : MonoBehaviour {

    public GameObject goToSleepButton;
    public TextMeshProUGUI WeekText;
    public TextMeshProUGUI DayText;
    public TextMeshProUGUI CommunityManagerText;
    public TextMeshProUGUI NameText;
    public TextMeshProUGUI DaySummaryText;
    public TextMeshProUGUI GoToSleepText;
    public GameObject blackOverlay;
    // Day data
    public TextMeshProUGUI NewJournalEntriesText;
    public TextMeshProUGUI NewJournalEntriesValue;
    public TextMeshProUGUI BlockPartyPreparationsText;
    public TextMeshProUGUI BlockPartyPreparationsValue;
    public TextMeshProUGUI SucculentsPlantedText;
    public TextMeshProUGUI SucculentsPlantedValue;
    public TextMeshProUGUI CommunityEngagementText;
    public TextMeshProUGUI CommunityEngagementValue;

    private void Start() {

        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicClass>().PlayMusic();

        WeekText.text = GameStrings.getString("week") + " " + (GlobalGameInfo.GetCurrentWeek() + 1);
        DayText.text = GlobalGameInfo.GetCurrentDayAsString("long");
        CommunityManagerText.text = GameStrings.getString("comm_manager");
        DaySummaryText.text = GameStrings.getString("day_summary");
        GoToSleepText.text = GameStrings.getString("go_to_sleep");

        NameText.SetText(GlobalGameInfo.name);

        if (blackOverlay != null)
        {
            blackOverlay.SetActive(true);
        }

        // Stats
        
        NewJournalEntriesText.text = GameStrings.getString("new_journal_entries");
        NewJournalEntriesValue.text = GlobalGameInfo.journalItemsLearnedTodayNum.ToString();
        BlockPartyPreparationsText.text = GameStrings.getString("block_party_preparations");
        BlockPartyPreparationsValue.text = ((GlobalGameInfo.GetCurrentDay() + 1) * 25).ToString() + "%";
        SucculentsPlantedText.text = GameStrings.getString("succulents_planted");
        SucculentsPlantedValue.text = Random.Range(2, 10).ToString();
        CommunityEngagementText.text = GameStrings.getString("community_engagement");
        int communityEngagementLevel = ((GlobalGameInfo.GetCurrentWeek()) * 20 + (GlobalGameInfo.GetCurrentDay() + 1) * 5);
        CommunityEngagementValue.text = communityEngagementLevel.ToString() + "%";

        if (communityEngagementLevel == 100) {
            GlobalGameInfo.gameEndedFlag = true;
        }
    }

    
    public void goToSleep() {
        // Increase day gets updated in the saving class below

        // Reset number of journal items learned today
        GlobalGameInfo.journalItemsLearnedTodayNum = 0;

        // Saving the game progress
        SavingGame.SaveGameProgress();
        // Go to saving scene
        SceneManager.LoadScene("Saving");
    }

}
