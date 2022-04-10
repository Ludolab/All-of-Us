using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

// NEED TO CHANGE SO DOESN'T CHECK ALL ACTIVE QUESTS
// should just change questgiver string to Quest object

/// <summary>
/// Contains info for each quest
/// </summary>

[System.Serializable]
public class Quest {
    public string questId; // used to identify quests behind the scenes
    public CharacterResources.CHARACTERS questGiver; // the NPC who assigned the quest
    public string description; // description of the quest. Used for UI
    public bool incHealth; // does this quest increase the giver's health stat?
    public bool incTime; // increase the giver's time stat?
    public bool incTech; // increase the giver's tech stat?
    public bool incResources; // increase the giver's resources stat?
    public int optionNumber; // 0 indicates no option number given. Possible numbers are 1,2,3,4 (for the research version) 


    public static bool questsAreEqual(Quest q1, Quest q2)
    {
        if (q1 == null && q2 == null)
        {
            return true;
        }
        if (q1 == null || q2 == null)
        {
            return false;
        }
        if (string.Equals(q1.questId, q2.questId) && q1.questGiver == q2.questGiver && string.Equals(q1.description, q2.description)
            && q1.incHealth == q2.incHealth && q1.incTime == q2.incTime && q1.incTech == q2.incTech 
            && q1.incResources == q2.incResources)
        {
            return true;
        }
        return false;
    }
}

/// <summary>
/// Handles a lot of the variables and methods regarding quests.
/// </summary>
public class QuestManager : MonoBehaviour 
{
    public enum SubmitStatus {
        not_submitted,
        correct,
        incorrect
    }

    /// <summary>
    /// Flowchart containing methods for handling "correct" and
    /// "incorrect" quest submissions.
    /// </summary>
    public Flowchart redeem_fc;

    public static int _optionNumber = 0;
    
    public static QuestManager instance;

    /// <summary>
    /// Contains a list of every active quest
    /// </summary>
    private static List<Quest> activeQuests = new List<Quest>();

    /// <summary>
    /// Used on Start to determine if we just got back from
    /// submitting a quest.
    /// </summary>
    public static SubmitStatus _status;
    /// <summary>
    /// Contains the ID of the quest we tried to solve.
    /// Used when returning to VN scene.
    /// </summary>
    public static Quest submittedQuest;
    private static Quest prevSubmittedQuest;
    /// <summary>
    /// Contains the name of the person whose quest we're about to solve.
    /// Used when going to turnin scene.
    /// </summary>
    public static CharacterResources.CHARACTERS questGiver;

    private string turninScenceName = "Turnin";

    public void Awake() {
        instance = this;
    }

  

    private void Start() {
        // adjust the variables in the Flowchart for if a quest was submitted
        // the Variables Flowchart object currently takes care of handling

        if (redeem_fc != null) {
            switch (_status)
            {
                case SubmitStatus.correct:
                    _status = SubmitStatus.not_submitted;
                    redeem_fc.SetIntegerVariable("optionNumber", _optionNumber);
                    redeem_fc.SetBooleanVariable("wasQuestSubmitted", true);
                    redeem_fc.SetBooleanVariable("wasSubmitCorrect", true);
                    Debug.Log("Option Number: " + _optionNumber);
                    Debug.Log("INFO1 + " + submittedQuest.description);
                    prevSubmittedQuest = submittedQuest;
                    submittedQuest = null;
                   
                    Debug.Log("Correct Quest!");
                    break;
               case SubmitStatus.not_submitted:
                    redeem_fc.SetBooleanVariable("wasQuestSubmitted", false);
                    break;
            }
        }
    }

    public void CorrectOption()
    {
        Debug.Log("INFO2 + " + prevSubmittedQuest.description);
        RemoveQuest(prevSubmittedQuest);
        InkFileManager.OnQuestCompleted(prevSubmittedQuest.questGiver);
        IncreaseExpValues(prevSubmittedQuest);
        InkFileManager.completedQuestString = prevSubmittedQuest.questId;
    }

    private void IncreaseExpValues(Quest q) {
        // would have met character by now
        try {
            if (q.incHealth)
                GlobalGameInfo.contactsList[q.questGiver].UpdateStat("health");
            if (q.incTime)
                GlobalGameInfo.contactsList[q.questGiver].UpdateStat("time");
            if (q.incTech)
                GlobalGameInfo.contactsList[q.questGiver].UpdateStat("tech");
            if (q.incResources)
                GlobalGameInfo.contactsList[q.questGiver].UpdateStat("resources");
        } catch {
            Debug.LogError("Character " +
                HelperFunctions.StringFromCharacter(q.questGiver) +
                " not met yet.");
        }
    }

    /// <summary>
    /// Updates questGiver
    /// </summary>
    public void UpdateLastSpeaker() {
        SayDialog sd = FindObjectOfType<SayDialog>();
        if (sd == null)
            return;
        string nameText = sd.NameText;
        if (nameText != null && nameText != "")
            questGiver = HelperFunctions.CharacterFromString(nameText);
    }

    /// <summary>
    /// Opens the quest turnin scene
    /// </summary>
    public void OpenTurninScene() {
        FindObjectOfType<SceneChangeDemoController>().OpenScene(turninScenceName);
    }

    /// <summary>
    /// Adds a quest to the quest list with the in put parameters
    /// </summary>
    /// <param name="questId">The questId of the new quest.</param>
    /// <param name="questGiver">The questGiver of the new quest.</param>
    /// <param name="description">The description of the new quest.</param>
    public static void AddQuest(string questId, string questGiver, string description) {
        AddQuest(questId, HelperFunctions.CharacterFromString(questGiver), description);
    }

    public static void AddQuest(string questId, CharacterResources.CHARACTERS questGiver,
        string description) {
        foreach (Quest q in activeQuests) {
            if (q.questId == questId)
                return;
        }
        Quest newQuest = new Quest();
        
        newQuest.questId = questId;
        newQuest.questGiver = questGiver;
        newQuest.description = description;

        activeQuests.Add(newQuest);
    }

    public static void AddQuest(Quest q) {
        activeQuests.Add(q);
    }

    /// <summary>
    /// Removes a quest from questList whose questId matches the input questId
    /// </summary>
    /// <param name="q">The q to search for in the list</param>
    public static void RemoveQuest(Quest quest) {
        // i'm not just doing list.contains here because the references will
        // be different
        foreach (Quest q in activeQuests) {
            if (q.questId == quest.questId) {
                activeQuests.Remove(q);
                return;
            }
        }
    }

    /// <summary>
    /// Used in turnin scene. Submits the selected piece of journal info and
    /// determines if the information was correct or not.
    /// </summary>
    /// <param name="questId">The questId to compare against. If this is the active quest,
    /// the answer is "correct." Else, it is "incorrect."</param>
    public static void SubmitQuest(Quest quest) {
        _status = SubmitStatus.incorrect;

        // i'm not just doing list.contains here because the references will
        // be different
        try {
            foreach (Quest q in activeQuests) {
                if (q.questId == quest.questId) {
                    _status = SubmitStatus.correct;
                    _optionNumber = q.optionNumber;
                    submittedQuest = quest;
                    break;
                }
            }
        } catch {

        }
        SceneChangeDemoController.LoadPreviousSceneStatic();
    }

    /// <summary>
    /// Finds character's active quest in activeQuests. Assumes each character
    /// can only have one active quest at a time.
    /// </summary>
    /// <param name="character">The character to search for in activeQuests</param>
    /// <returns></returns>
    public static Quest FindQuestByCharacter(string character) {
        return activeQuests.Find(item => item.questGiver ==
            HelperFunctions.CharacterFromString(character));
    }

    /// <summary>
    /// Finds a quest in activeQuests by searching by questId.
    /// </summary>
    /// <param name="questId">The quest id to search for in activeQuests</param>
    /// <returns></returns>
    public static Quest FindQuestById(string questId) {
        return activeQuests.Find(item => item.questId == questId);
    }
}
