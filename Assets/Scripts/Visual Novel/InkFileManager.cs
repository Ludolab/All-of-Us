﻿using System.Collections;
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
                //case CharacterResources.CHARACTERS.LEE:
                //    return leeQuests;
                default:
                    return rashadQuests;
            }
        } }

    public static string ActiveFileName { get {
            try {
                return ActivePersonQuestList[activeFileIdx.Item1][activeFileIdx.Item2];
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

    public static InkFileManager instance;

    private void Awake() {
        if (!instance) {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.activeSceneChanged += OnSceneChanged;
            activeFileIdx = (-1, -1);
        }
    }

    // Start is called before the first frame update
    void Start() {
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
        if (!GetVisualNovelComponents())
            return;
        
        _fc.ExecuteBlock("On Variables Loaded");
    }

    /// <summary>
    /// Returns true if you can start a quest for character
    /// </summary>
    /// <returns></returns>
    public bool CanStartQuest(CharacterResources.CHARACTERS character) {
        // a quest is already active
        if (activeFileIdx != (-1, -1))
            return false;

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
            //case CharacterResources.CHARACTERS.LEE:
            //    return !completedDailyLee;
        }
        return false;
    }

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
            return true;
        } else {
            return false;
        }
    }

    /// <summary>
    /// Returns true if all quests for the day have been completed
    /// </summary>
    /// <returns></returns>
    public bool CanAdvanceDay() {
        return completedDailyCalindas && completedDailyElisa &&
            completedDailyLee && completedDailyRashad && completedDailyLila;
    }

    public void TryLoadVNScene(string person) {
        CharacterResources.CHARACTERS character =
            HelperFunctions.CharacterFromString(person);

        // try start a new quest
        if (CanStartQuest(character)) {
            const int DAY_TEST = 1;

            activeFileIdx = (DAY_TEST - 1, 0);

            NarrativeDirector.staticInk = Resources.Load<TextAsset>(InkToJson(ActiveFileName));
            // for now
            SceneManager.LoadScene("LibraryVN");
        } else {
            int questNum = activeFileIdx.Item1;
            int chapterNum = activeFileIdx.Item2;
            string fileToLoad = ActivePersonQuestList[questNum][chapterNum];
            // is this the next person to speak to for the quest?
            if (character == GetSpeakerFromFile(fileToLoad)) {
                NarrativeDirector.staticInk = Resources.Load<TextAsset>(InkToJson(ActiveFileName));
                // for now
                SceneManager.LoadScene("LibraryVN");
            }
        }
    }

    private string InkToJson(string inkFilename) {
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
    private CharacterResources.CHARACTERS GetSpeakerFromFile(string fileName) {
        char sep = Path.DirectorySeparatorChar;
        string pwd = Directory.GetCurrentDirectory() + sep;
        string dir = pwd + "Assets" + sep + "Story Files" + sep + "Resources" +
            sep + fileName;

        using (StreamReader reader = File.OpenText(dir)) {
            string line;
            while ((line = reader.ReadLine()) != null) {
                string[] splitLine = line.Split('?');
                if (splitLine.Length >= 2) {
                    reader.Close();
                    return HelperFunctions.CharacterFromString(splitLine[0]);
                }
            }
            reader.Close();
            Debug.LogError("Couldn't find speaker in file " + fileName);
            return CharacterResources.CHARACTERS.RASHAD;
        }

    }

    private static readonly string[] rashadQuest1Files = {
        "Rashad_1_delivery.ink", "Rashad_1_info1.ink",
        "Rashad_1_completion.ink" };
    private static readonly string[] rashadQuest2Files = {
        "Rashad_2_delivery.ink", "Rashad_2_info1.ink",
        "Rashad_2_info2.ink", "Rashad_2_completion.ink" };
    private static readonly string[] rashadQuest3Files = {
        "Rashad_3_delivery.ink", "Rashad_3_info1.ink",
        "Rashad_3_info2.ink", "Rashad_3_completion.ink" };
    private static readonly string[] rashadQuest4Files = {
        "Rashad_4_delivery.ink", "Rashad_4_info1.ink",
        "Rashad_4_info2.ink", "Rashad_4_completion.ink" };
    private static readonly string[][] rashadQuests = { rashadQuest1Files,
        rashadQuest2Files, rashadQuest3Files, rashadQuest4Files};

    private static readonly string[] calindasQuest1Files = {
        "Calindas_1_delivery.ink", "Calindas_1_info1.ink",
        "Calindas_1_info2.ink", "Calindas_1_completion.ink" };
    private static readonly string[] calindasQuest2Files = {
        "Calindas_2_delivery.ink", "Calindas_2_info1.ink",
        "Calindas_2_info2.ink", "Calindas_2_completion.ink" };
    private static readonly string[] calindasQuest3Files = {
        "Calindas_3_delivery.ink", "Calindas_3_info1.ink",
        "Calindas_3_info2.ink", "Calindas_3_completion.ink" };
    private static readonly string[] calindasQuest4Files = {
        "Calindas_4_delivery.ink", "Calindas_4_info1.ink",
        "Calindas_4_info2.ink", "Calindas_4_completion.ink" };
    private static readonly string[][] calindasQuests = { calindasQuest1Files,
        calindasQuest2Files, calindasQuest3Files, calindasQuest4Files};

    private static readonly string[] elisaQuest1Files = {
        "Elisa_1_delivery.ink", "Elisa_1_info1.ink",
        "Elisa_1_info2.ink", "Elisa_1_completion.ink" };
    private static readonly string[] elisaQuest2Files = {
        "Elisa_2_delivery.ink", "Elisa_2_info1.ink",
        "Elisa_2_completion.ink" };
    private static readonly string[] elisaQuest3Files = {
        "Elisa_3_delivery.ink", "Elisa_3_info1.ink",
        "Elisa_3_info2.ink", "Elisa_3_completion.ink" };
    private static readonly string[] elisaQuest4Files = {
        "Elisa_4_delivery.ink", "Elisa_4_info1.ink",
        "Elisa_4_info2.ink", "Elisa_4_completion.ink" };
    private static readonly string[][] elisaQuests = { elisaQuest1Files,
        elisaQuest2Files, elisaQuest3Files, elisaQuest4Files};

    private static readonly string[] leeQuest1Files = {
        "Mrslee_1_delivery.ink", "Mrslee_1_info1.ink",
        "Mrslee_1_info2.ink", "Mrslee_1_completion.ink" };
    private static readonly string[] leeQuest2Files = {
        "Mrslee_2_delivery.ink", "Mrslee_2_info1.ink",
        "Mrslee_2_info2.ink", "Mrslee_2_completion.ink" };
    private static readonly string[] leeQuest3Files = {
        "Mrslee_3_delivery.ink", "Mrslee_3_info1.ink",
        "Mrslee_3_info2.ink", "Mrslee_3_completion.ink" };
    private static readonly string[] leeQuest4Files = {
        "Mrslee_4_delivery.ink", "Mrslee_4_info1.ink",
        "Mrslee_4_info2.ink", "Mrslee_4_completion.ink" };
    private static readonly string[][] leeQuests = { leeQuest1Files,
        leeQuest2Files, leeQuest3Files, leeQuest4Files};

    private static readonly string[] lilaQuest1Files = {
        "Lila_1_delivery.ink", "Lila_1_info1.ink",
        "Lila_1_info2.ink", "Lila_1_completion.ink" };
    private static readonly string[] lilaQuest2Files = {
        "Lila_2_delivery.ink", "Lila_2_info1.ink",
        "Lila_2_info2.ink", "Lila_2_completion.ink" };
    private static readonly string[] lilaQuest3Files = {
        "Lila_3_delivery.ink", "Lila_3_info1.ink",
        "Lila_3_info2.ink", "Lila_3_completion.ink" };
    private static readonly string[] lilaQuest4Files = {
        "Lila_4_delivery.ink", "Lila_4_info1.ink",
        "Lila_4_info2.ink", "Lila_4_completion.ink" };
    private static readonly string[][] lilaQuests = { lilaQuest1Files,
        lilaQuest2Files, lilaQuest3Files, lilaQuest4Files};
}
