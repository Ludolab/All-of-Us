using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InkFungus;
using Fungus;
using UnityEngine.SceneManagement;
using System.IO;

public class InkFileManager : MonoBehaviour {
    [Tooltip("Ink-Fungus narrative director for this scene.")]
    private NarrativeDirector narrativeDirector;
    [Tooltip("Fungus flowchart containing relevant info.")]
    private Flowchart _fc;
    private static CharacterResources.CHARACTERS activeQuestGiver;
    private static (int, int) activeFileIdx;
    private static CharacterResources.CHARACTERS alreadySpokenTo;
    private static int speakingToFileIndex = 0;
    private static string[][] ActivePersonQuestList { get {
            switch (activeQuestGiver) {
                case CharacterResources.CHARACTERS.RASHAD:
                    return rashadQuests;
                case CharacterResources.CHARACTERS.LILA:
                    return lilaQuests;
                case CharacterResources.CHARACTERS.ELISA:
                    return elisaQuests;
                case CharacterResources.CHARACTERS.CALINDAS:
                    return calindasQuests;
                case CharacterResources.CHARACTERS.LEE:
                    return leeQuests;
                default:
                    return rashadQuests;
            }
        } }

    public static string ActiveFileName { get {
            try {
                if (activeFileIdx.Item2 == ActivePersonQuestList[activeFileIdx.Item1].Length - 1 || activeFileIdx.Item2 == 0)
                {
                    return ActivePersonQuestList[activeFileIdx.Item1][activeFileIdx.Item2];
                }
                else
                {
                    return ActivePersonQuestList[activeFileIdx.Item1][speakingToFileIndex];
                }
            } catch {
                Debug.LogWarning("Tried to access ActiveFileName with no active quest.");
                return null;
            }
        } }

    private static bool completedDailyRashad;
    private static bool completedDailyElisa;
    private static bool completedDailyLila;
    private static bool completedDailyCalindas;
    private static bool completedDailyLee;
    public static int DailyQuestsCompleted { get {
            return (completedDailyRashad ? 1 : 0) +
                (completedDailyElisa ? 1 : 0) +
                (completedDailyLila ? 1 : 0) +
                (completedDailyCalindas ? 1 : 0) +
                (completedDailyLee ? 1 : 0);
        } }

    public static InkFileManager instance;
    private static bool didAdd = false;
    public static string completedQuestString = null;

    public void setActiveFileIdx((int, int) value) {
        activeFileIdx = value;
    }

    private void Awake() {
        if (!didAdd) {
            SceneManager.activeSceneChanged += OnSceneChanged;
            activeFileIdx = (-1, -1);
            didAdd = true;
        }
        instance = this;
    }

    // Start is called before the first frame update
    void Start() {
        alreadySpokenTo = CharacterResources.CHARACTERS.NONE;
        _fc = GetComponent<Flowchart>();
        if (!GetVisualNovelComponents()) // if we couldn't find the VN components
            return;
    }

    /// <summary>
    /// Sets the NarrativeDirector and Flowchart variables to those in the scene.
    /// </summary>
    /// <returns>true if both components are found, false otherwise</returns>
    bool GetVisualNovelComponents() {
        try {
            _fc = GameObject.Find("Variables Flowchart").
                GetComponent<Flowchart>();
            narrativeDirector = FindObjectOfType<NarrativeDirector>();
        } catch {
            return false;
        }        
        return (_fc && narrativeDirector);
    }

    private void OnSceneChanged(Scene prev, Scene next) {
        EndOfQuest eoq = null;
        if ((eoq = FindObjectOfType<EndOfQuest>()) &&
            completedQuestString != null && completedQuestString != "") {
            eoq.EndQuest(completedQuestString);
            completedQuestString = null;
        }
        if (!GetVisualNovelComponents())
            return;

        _fc.SetStringVariable("player_name", GlobalGameInfo.name);
        _fc.ExecuteBlock("On Variables Loaded");

    }

    public static void OnQuestCompleted(CharacterResources.CHARACTERS questGiver) {
        switch (questGiver) {
            case CharacterResources.CHARACTERS.RASHAD:
                completedDailyRashad = true;
                break;
            case CharacterResources.CHARACTERS.LILA:
                completedDailyLila = true;
                break;
            case CharacterResources.CHARACTERS.ELISA:
                completedDailyElisa = true;
                break;
            case CharacterResources.CHARACTERS.CALINDAS:
                completedDailyCalindas = true;
                break;
            case CharacterResources.CHARACTERS.LEE:
                completedDailyLee = true;
                break;
        }

        // progress bar?
        // do something once all 5 are done for the day
        // GlobalGameInfo.IncreaseEngagement();
        activeFileIdx = (-1, -1);
    }


    private static bool CanStartSubsequentQuest(CharacterResources.CHARACTERS character)
    {
        return GlobalGameInfo.GetCurrentNPC() == character;
    }
    /// <summary>
    /// Returns true if you can start a quest for character
    /// </summary>
    /// <returns></returns>
    private static bool CanStartQuest(CharacterResources.CHARACTERS character) {

        // a quest is already active
        if (activeFileIdx != (-1, -1))
        {
            return false;
        }

        return character == GlobalGameInfo.GetCurrentNPC();
        /*
        // have we already done their quest for the day?
        switch (character) {
            case CharacterResources.CHARACTERS.RASHAD:
                return !completedDailyRashad;
            case CharacterResources.CHARACTERS.LILA:
                return !completedDailyLila;
            case CharacterResources.CHARACTERS.ELISA:
                return !completedDailyElisa;
            case CharacterResources.CHARACTERS.CALINDAS:
                return !completedDailyCalindas;
            case CharacterResources.CHARACTERS.LEE:
                return !completedDailyLee;
        }
        return false;
        */
    }

    // Basically the same as CanStartQuestion but we don't care if a question is currently active.
    
    
    /// <summary>
    /// If possible, advances the progress of the quest file system. returns
    /// a bool representing if progress actually occurred
    /// </summary>
    /// <returns></returns>
    public bool TryAdvanceQuest() {
        if (activeFileIdx == (-1, -1))
            return false;

        int questNum = activeFileIdx.Item1;
        int chapterNum = activeFileIdx.Item2;

        // are we are still able to advance in a quest?
        // i.e. is there still at least one more ink file to read?
        if (chapterNum < ActivePersonQuestList[questNum].Length - 1) {
            activeFileIdx.Item2++;
            // The next time, will be a completion. Thus, clear the already spoken to variable we added
            if (activeFileIdx.Item2 == ActivePersonQuestList[questNum].Length - 1)
            {
                alreadySpokenTo = CharacterResources.CHARACTERS.NONE;
            }
            return true;
        } else {
            return false;
        }
    }

    /// <summary>
    /// Returns true if all quests for the day have been completed
    /// </summary>
    /// <returns></returns>
    public static bool CanAdvanceDay() {
        return completedDailyCalindas && completedDailyElisa &&
            completedDailyLee && completedDailyRashad && completedDailyLila;
    }

    public static void ResetDailyBools() {
        completedDailyCalindas = false;
        completedDailyRashad = false;
        completedDailyElisa = false;
        completedDailyLila = false;
        completedDailyLee = false;
    }

    public static bool CanSpeakToForCurrentQuestOrNewQuest(CharacterResources.CHARACTERS character)
    {
        // If there is no active quest
        if (activeFileIdx == (-1, -1))
        {
            // First one is a brand new quest, second one is the character is the current NPC, and we can start a new quest with them
            return CanStartQuest(character);
        }
        else
        {
            
            int questNum = activeFileIdx.Item1;
            int chapterNum = activeFileIdx.Item2;
            string fileToLoad = "";
            string fileToLoad1 = "";
            string fileToLoad2 = "";
            try
            {
                fileToLoad = ActivePersonQuestList[questNum][chapterNum];
                fileToLoad1 = ActivePersonQuestList[questNum][1];
                fileToLoad2 = ActivePersonQuestList[questNum][2];
            }
            catch (System.IndexOutOfRangeException)
            {

            }
            // One of the other two people player has to talk to (not quest giver delivery or completion)
            // If ActivePersonQuestList[questNum].Length - 1 == 2, then there is only one middle person to talk to, so this case doesn't apply
            if (ActivePersonQuestList[questNum].Length - 1 != 2 && chapterNum != ActivePersonQuestList[questNum].Length - 1 && chapterNum != 0)
            {
                if (character != alreadySpokenTo && ((character == GetSpeakerFromFile(fileToLoad1)) || (character == GetSpeakerFromFile(fileToLoad2))))
                {
                    return true;
                }
            }
            // Else case, then it is the delivery or completion
            else
            {
                if (character == GetSpeakerFromFile(fileToLoad))
                {
                    return true;
                }
            }
            // is this the next person to speak to for the quest?
            
            return false;
        }
    }



    public void TryGoHome() {
        // if (CanAdvanceDay()) {
            SceneManager.LoadScene("Home");
        // }
    }

    public void TryLoadVNScene(string person) {
        CharacterResources.CHARACTERS character =
            HelperFunctions.CharacterFromString(person);
        
        GlobalGameInfo.initializeContactsList();
       
        // try start a new quest
        if (CanStartQuest(character)) {
            activeFileIdx = (GlobalGameInfo.GetCurrentDay(), 0);
            activeQuestGiver = character;

            NarrativeDirector.staticInk = Resources.Load<TextAsset>(InkToJson(ActiveFileName));
            switch (character) {
                case CharacterResources.CHARACTERS.RASHAD:
                    SceneManager.LoadScene("LibraryVN");
                    break;
                case CharacterResources.CHARACTERS.ELISA:
                    SceneManager.LoadScene("LibraryVN");
                    break;
                case CharacterResources.CHARACTERS.CALINDAS:
                    SceneManager.LoadScene("HealthVN");
                    break;
                case CharacterResources.CHARACTERS.LILA:
                    SceneManager.LoadScene("CommunityVN");
                    break;
                case CharacterResources.CHARACTERS.LEE:
                    SceneManager.LoadScene("CommunityVN");
                    break;
            }
        } else {
            int questNum = activeFileIdx.Item1;
            int chapterNum = activeFileIdx.Item2;
            string fileToLoad = "";
            try {
                fileToLoad = ActivePersonQuestList[questNum][chapterNum];
            } catch (System.IndexOutOfRangeException){

            }
            // is this the next person to speak to for the quest?
            if (CanSpeakToForCurrentQuestOrNewQuest(character))
            {
                alreadySpokenTo = character;
                if (chapterNum != ActivePersonQuestList[questNum].Length - 1 && chapterNum != 0)
                {
                    string fileToLoad1 = ActivePersonQuestList[questNum][1];
                    string fileToLoad2 = ActivePersonQuestList[questNum][2];
                    if (character == GetSpeakerFromFile(fileToLoad1))
                    {
                        speakingToFileIndex = 1;
                    }
                    if (character == GetSpeakerFromFile(fileToLoad2))
                    {
                        speakingToFileIndex = 2;
                    }
                }
                NarrativeDirector.staticInk = Resources.Load<TextAsset>(InkToJson(ActiveFileName));
                switch (character) {
                    case CharacterResources.CHARACTERS.RASHAD:
                        SceneManager.LoadScene("LibraryVN");
                        break;
                    case CharacterResources.CHARACTERS.ELISA:
                        SceneManager.LoadScene("LibraryVN");
                        break;
                    case CharacterResources.CHARACTERS.CALINDAS:
                        SceneManager.LoadScene("HealthVN");
                        break;
                    case CharacterResources.CHARACTERS.LILA:
                        SceneManager.LoadScene("CommunityVN");
                        break;
                    case CharacterResources.CHARACTERS.LEE:
                        SceneManager.LoadScene("CommunityVN");
                        break;
                }
            }
        }
    }

    private string InkToJson(string inkFilename) {
        // turns out we don't actually need .json
        return inkFilename.Split(new string[] { ".ink" },
            System.StringSplitOptions.None)[0];
    }

    /// <summary>
    /// Takes an ink fileName and reads through to find out who is the speaker
    /// for the .ink file
    /// </summary>
    /// <param name="fileName">name of a .ink file located in
    /// Assets/Story Files/Resources</param>
    /// <returns>The primary speaking character for the .ink file</returns>
    private static CharacterResources.CHARACTERS GetSpeakerFromFile(string fileName) {
        string[] splitLine = fileName.Split('_');
        string[] splitSecondLine = splitLine[3].Split('.');
        return HelperFunctions.CharacterFromString(splitSecondLine[0]);


//         char sep = Path.DirectorySeparatorChar;
//         string pwd = Directory.GetCurrentDirectory() + sep;
//         string dir;
// #if UNITY_EDITOR
//         dir = pwd + "Assets" + sep + "Story Files" + sep + "Resources" +
//             sep + fileName;
// #elif UNITY_STANDALONE_OSX
//         dir = pwd + "\"Bloomwood Stories Block Party.app\"" + sep +
//         "Contents" + sep + "Resources" + sep + fileName;
// #endif

//         using (StreamReader reader = File.OpenText(dir)) {
//             string line;
//             while ((line = reader.ReadLine()) != null) {
//                 string[] splitLine = line.Split('?');
//                 if (splitLine.Length >= 2) {
//                     reader.Close();
//                     return HelperFunctions.CharacterFromString(splitLine[0]);
//                 }
//             }
//             reader.Close();
//             Debug.LogError("Couldn't find speaker in file " + fileName);
//             return CharacterResources.CHARACTERS.RASHAD;
//         }

    }

    private static readonly string[] rashadQuest1Files = {
        "Rashad_1_delivery_Rashad.ink", "Rashad_1_info1_Elisa.ink",
        "Rashad_1_completion_Rashad.ink" };
    private static readonly string[] rashadQuest2Files = {
        "Rashad_2_delivery_Rashad.ink", "Rashad_2_info1_Mrcalindas.ink",
        "Rashad_2_info2_Lila.ink", "Rashad_2_completion_Rashad.ink" };
    private static readonly string[] rashadQuest3Files = {
        "Rashad_3_delivery_Rashad.ink", "Rashad_3_info1_Lila.ink",
        "Rashad_3_info2_Mrcalindas.ink", "Rashad_3_completion_Rashad.ink" };
    private static readonly string[] rashadQuest4Files = {
        "Rashad_4_delivery_Rashad.ink", "Rashad_4_info1_Elisa.ink",
        "Rashad_4_info2_Mrslee.ink", "Rashad_4_completion_Rashad.ink" };
    private static readonly string[][] rashadQuests = { rashadQuest1Files,
        rashadQuest2Files, rashadQuest3Files, rashadQuest4Files};

    private static readonly string[] calindasQuest1Files = {
        "Mrcalindas_1_delivery_Mrcalindas.ink", "Mrcalindas_1_info1_Lila.ink",
        "Mrcalindas_1_info2_Rashad.ink", "Mrcalindas_1_completion_Mrcalindas.ink" };
    private static readonly string[] calindasQuest2Files = {
        "Mrcalindas_2_delivery_Mrcalindas.ink", "Mrcalindas_2_info1_Mrslee.ink",
        "Mrcalindas_2_info2_Lila.ink", "Mrcalindas_2_completion_Mrcalindas.ink" };
    private static readonly string[] calindasQuest3Files = {
        "Mrcalindas_3_delivery_Mrcalindas.ink", "Mrcalindas_3_info1_Elisa.ink",
        "Mrcalindas_3_info2_Rashad.ink", "Mrcalindas_3_completion_Mrcalindas.ink" };
    private static readonly string[] calindasQuest4Files = {
        "Mrcalindas_4_delivery_Mrcalindas.ink", "Mrcalindas_4_info1_Rashad.ink",
        "Mrcalindas_4_info2_Lila.ink", "Mrcalindas_4_completion_Mrcalindas.ink" };
    private static readonly string[][] calindasQuests = { calindasQuest1Files,
        calindasQuest2Files, calindasQuest3Files, calindasQuest4Files};

    private static readonly string[] elisaQuest1Files = {
        "Elisa_1_delivery_Elisa.ink", "Elisa_1_info1_Rashad.ink",
        "Elisa_1_info2_Lila.ink", "Elisa_1_completion_Elisa.ink" };
    private static readonly string[] elisaQuest2Files = {
        "Elisa_2_delivery_Elisa.ink", "Elisa_2_info1_Mrcalindas.ink",
        "Elisa_2_completion_Elisa.ink" };
    private static readonly string[] elisaQuest3Files = {
        "Elisa_3_delivery_Elisa.ink", "Elisa_3_info1_Lila.ink",
        "Elisa_3_info2_Mrcalindas.ink", "Elisa_3_completion_Elisa.ink" };
    private static readonly string[] elisaQuest4Files = {
        "Elisa_4_delivery_Elisa.ink", "Elisa_4_info1_Mrcalindas.ink",
        "Elisa_4_info2_Rashad.ink", "Elisa_4_completion_Elisa.ink" };
    private static readonly string[][] elisaQuests = { elisaQuest1Files,
        elisaQuest2Files, elisaQuest3Files, elisaQuest4Files};

    private static readonly string[] leeQuest1Files = {
        "Mrslee_1_delivery_Mrslee.ink", "Mrslee_1_info1_Lila.ink",
        "Mrslee_1_info2_Mrcalindas.ink", "Mrslee_1_completion_Mrslee.ink" };
    private static readonly string[] leeQuest2Files = {
        "Mrslee_2_delivery_Mrslee.ink", "Mrslee_2_info1_Rashad.ink",
        "Mrslee_2_info2_Mrcalindas.ink", "Mrslee_2_completion_Mrslee.ink" };
    private static readonly string[] leeQuest3Files = {
        "Mrslee_3_delivery_Mrslee.ink", "Mrslee_3_info1_Lila.ink",
        "Mrslee_3_info2_Elisa.ink", "Mrslee_3_completion_Mrslee.ink" };
    private static readonly string[] leeQuest4Files = {
        "Mrslee_4_delivery_Mrslee.ink", "Mrslee_4_info1_Rashad.ink",
        "Mrslee_4_info2_Lila.ink", "Mrslee_4_completion_Mrslee.ink" };
    private static readonly string[][] leeQuests = { leeQuest1Files,
        leeQuest2Files, leeQuest3Files, leeQuest4Files};

    private static readonly string[] lilaQuest1Files = {
        "Lila_1_delivery_Lila.ink", "Lila_1_info1_Elisa.ink",
        "Lila_1_info2_Rashad.ink", "Lila_1_completion_Lila.ink" };
    private static readonly string[] lilaQuest2Files = {
        "Lila_2_delivery_Lila.ink", "Lila_2_info1_Rashad.ink",
        "Lila_2_info2_Mrcalindas.ink", "Lila_2_completion_Lila.ink" };
    private static readonly string[] lilaQuest3Files = {
        "Lila_3_delivery_Lila.ink", "Lila_3_info1_Mrcalindas.ink",
        "Lila_3_info2_Mrslee.ink", "Lila_3_completion_Lila.ink" };
    private static readonly string[] lilaQuest4Files = {
        "Lila_4_delivery_Lila.ink", "Lila_4_info1_Mrslee.ink",
        "Lila_4_info2_Elisa.ink", "Lila_4_completion_Lila.ink" };
    private static readonly string[][] lilaQuests = { lilaQuest1Files,
        lilaQuest2Files, lilaQuest3Files, lilaQuest4Files};
}
