using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndOfQuest : MonoBehaviour
{
    private static Dictionary<string, Quest> questMap = new Dictionary<string, Quest>();

    [SerializeField]
    public GameObject endOfQuest;
    public TextMeshProUGUI remainDays;
    public TextMeshProUGUI daysText;
    public TextMeshProUGUI title;
    public TextMeshProUGUI description;
    public GameObject[] pictures;
    public GameObject[] upcomingDays;
    public GameObject[] currentDays;
    public GameObject[] pastDays;

    // Start is called before the first frame update
    void Start()
    {

        if (questMap == null || questMap.Count == 0) {
            questMap = new Dictionary<string, Quest>();
            BuildQuestMap();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndQuest(string questTitle)
    {
        Quest quest;
        if (!questMap.TryGetValue(questTitle, out quest))
        {
            throw new System.Exception("Cannot find the Quest Title \"" +
                questTitle + "\"");
        }

        // set texts
        title.text = questTitle;
        description.text = quest.description;
        remainDays.text = GlobalGameInfo.GetRemainDays().ToString();
        if (GlobalGameInfo.GetRemainDays() <= 1)
        {
            daysText.text = GameStrings.getString("day");
        }

        // set character and picture
        for (int i = 0; i < pictures.Length; i++)
        {
            pictures[i].SetActive(false);
        }
        switch (quest.character) {
            case "Rashad":
                pictures[0].SetActive(true);
                break;
            case "Lila":
                pictures[1].SetActive(true);
                break;
            case "Calindas":
                pictures[2].SetActive(true);
                break;
            case "Lee":
                pictures[3].SetActive(true);
                break;
            case "Elisa":
                pictures[4].SetActive(true);
                break;
            default:
                throw new System.Exception("Cannot find Character. Check EndOfQuest.cs");
        }

        // set bottom days
        int today = GlobalGameInfo.GetCurrentDay();

        for (int i = 0; i <= today; i++)
        {
            upcomingDays[i].SetActive(false);
        }
        for (int i = today + 1; i < upcomingDays.Length; i++)
        {
            upcomingDays[i].SetActive(true);
        }
        for (int i = 0; i < currentDays.Length; i++)
        {
            if (i == today)
            {
                currentDays[i].SetActive(true);
            }
            else
            {
                currentDays[i].SetActive(false);
            }
        }

        // activate the screen
        endOfQuest.SetActive(true);
        
        Debug.Log(questTitle);
        GlobalGameInfo.FinishTask(questTitle);
        // Data collection
        DataCollection.LogEvent("Quest Completed! Title: " + questTitle + ", Character: " + quest.character, "QUEST COMPLETION");
    }

    public void CloseEndOfQuest()
    {
        // endOfQuest.SetActive(false);
        Destroy (GameObject.FindGameObjectWithTag("Music"));
        SceneManager.LoadScene("Home");

    }

    public class Quest
    {
        public string description;
        public string character;

        public Quest(string newDescription, string newCharacter)
        {
            description = newDescription;
            character = newCharacter;
        }
    }

    private void BuildQuestMap()
    {
        questMap.Add(GameStrings.getString("end_of_quest_rashad_1_title"), new Quest(GameStrings.getString("end_of_quest_rashad_1_desc"), "Rashad"));
        questMap.Add(GameStrings.getString("end_of_quest_rashad_2_title"), new Quest(GameStrings.getString("end_of_quest_rashad_2_desc"), "Rashad"));
        questMap.Add(GameStrings.getString("end_of_quest_rashad_3_title"), new Quest(GameStrings.getString("end_of_quest_rashad_3_desc"), "Rashad"));
        questMap.Add(GameStrings.getString("end_of_quest_rashad_4_title"), new Quest(GameStrings.getString("end_of_quest_rashad_4_desc"), "Rashad"));

        questMap.Add(GameStrings.getString("end_of_quest_lila_1_title"), new Quest(GameStrings.getString("end_of_quest_lila_1_desc"), "Lila"));
        questMap.Add(GameStrings.getString("end_of_quest_lila_2_title"), new Quest(GameStrings.getString("end_of_quest_lila_2_desc"), "Lila"));
        questMap.Add(GameStrings.getString("end_of_quest_lila_3_title"), new Quest(GameStrings.getString("end_of_quest_lila_3_desc"), "Lila"));
        questMap.Add(GameStrings.getString("end_of_quest_lila_4_title"), new Quest(GameStrings.getString("end_of_quest_lila_4_desc"), "Lila"));

        questMap.Add(GameStrings.getString("end_of_quest_calindas_1_title"), new Quest(GameStrings.getString("end_of_quest_calindas_1_desc"), "Calindas"));
        questMap.Add(GameStrings.getString("end_of_quest_calindas_2_title"), new Quest(GameStrings.getString("end_of_quest_calindas_2_desc"), "Calindas"));
        questMap.Add(GameStrings.getString("end_of_quest_calindas_3_title"), new Quest(GameStrings.getString("end_of_quest_calindas_3_desc"), "Calindas"));
        questMap.Add(GameStrings.getString("end_of_quest_calindas_4_title"), new Quest(GameStrings.getString("end_of_quest_calindas_4_desc"), "Calindas"));

        questMap.Add(GameStrings.getString("end_of_quest_lee_1_title"), new Quest(GameStrings.getString("end_of_quest_lee_1_desc"), "Lee"));
        questMap.Add(GameStrings.getString("end_of_quest_lee_2_title"), new Quest(GameStrings.getString("end_of_quest_lee_2_desc"), "Lee"));
        questMap.Add(GameStrings.getString("end_of_quest_lee_3_title"), new Quest(GameStrings.getString("end_of_quest_lee_3_desc"), "Lee"));
        questMap.Add(GameStrings.getString("end_of_quest_lee_4_title"), new Quest(GameStrings.getString("end_of_quest_lee_4_desc"), "Lee"));

        questMap.Add(GameStrings.getString("end_of_quest_elisa_1_title"), new Quest(GameStrings.getString("end_of_quest_elisa_1_desc"), "Elisa"));
        questMap.Add(GameStrings.getString("end_of_quest_elisa_2_title"), new Quest(GameStrings.getString("end_of_quest_elisa_2_desc"), "Elisa"));
        questMap.Add(GameStrings.getString("end_of_quest_elisa_3_title"), new Quest(GameStrings.getString("end_of_quest_elisa_3_desc"), "Elisa"));
        questMap.Add(GameStrings.getString("end_of_quest_elisa_4_title"), new Quest(GameStrings.getString("end_of_quest_elisa_4_desc"), "Elisa"));

    }
}
