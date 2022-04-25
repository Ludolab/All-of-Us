﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndOfQuest : MonoBehaviour
{
    [SerializeField]
    public GameObject TalkBubble;
    public TextMeshProUGUI TalkBubbleText;
    public GameObject TalkBubble2;
    public TextMeshProUGUI TalkBubble2Text;
    public Image Background;
    public Image TabBar;
    public Image NPC;
    public Sprite[] NPCImages;

    public Sprite[] TabBarImages;

    // Background Images
    public Sprite libraryBackground;
    public Sprite communityCenterBackground;
    public Sprite healthCenterBackground;

    // Stickers
    public GameObject[] NPCStickersLee1;
    public GameObject[] NPCStickersLee2;
    public GameObject[] NPCStickersCalindas1;
    public GameObject[] NPCStickersCalindas2;
    public GameObject[] NPCStickersLila1;
    public GameObject[] NPCStickersLila2;
    public GameObject[] NPCStickersElisa1;
    public GameObject[] NPCStickersElisa2;
    public GameObject[] NPCStickersRashad1;
    public GameObject[] NPCStickersRashad2;
    // Polaroids
    public GameObject[] NPCPolaroids1;
    public GameObject[] NPCPolaroids2;
    // Other elements
    public TextMeshProUGUI DaySummary;
    public TextMeshProUGUI Mon;
    public TextMeshProUGUI Tue;
    public TextMeshProUGUI Wed;
    public TextMeshProUGUI Thu;
    public TextMeshProUGUI Party;
    public TextMeshProUGUI ButtonText;
    public TextMeshProUGUI Sticker1Text;
    public TextMeshProUGUI Sticker2Text;
    public TextMeshProUGUI Week;
    public TextMeshProUGUI DayNumber;
    public TextMeshProUGUI DaysLeftText;


    // Start is called before the first frame update
    void Start()
    {

        // set texts
        DaySummary.text = GameStrings.getString("day_summary");
        Mon.text = GameStrings.getString("monday_short");
        Tue.text = GameStrings.getString("tuesday_short");
        Wed.text = GameStrings.getString("wednesday_short");
        Thu.text = GameStrings.getString("thursday_short");
        Party.text = GameStrings.getString("party");
        ButtonText.text = GameStrings.getString("continue");

        TabBar.sprite = TabBarImages[GlobalGameInfo.GetCurrentDay()];
        
        TalkBubble.SetActive(true);
        TalkBubbleText.enabled = true;

        Week.text = GameStrings.getString("week_all_caps");
        DayNumber.text = GlobalGameInfo.GetRemainDays().ToString();
        DaysLeftText.text = GameStrings.getString("days_left");

        if (GlobalGameInfo.GetRemainDays() <= 1)
        {
            DaysLeftText.text = GameStrings.getString("day_left");
        }

        switch (GlobalGameInfo.GetCurrentNPC()) {
            case CharacterResources.CHARACTERS.RASHAD:
                
                NPC.sprite = NPCImages[0];
                TalkBubbleText.text = GameStrings.getString("talk_bubble_rashad_1");
                TalkBubble2Text.text = GameStrings.getString("talk_bubble_rashad_2");
                NPCStickersRashad1[GlobalGameInfo.GetCurrentDay()].SetActive(true);
                NPCStickersRashad2[GlobalGameInfo.GetCurrentDay()].SetActive(true);
                Background.sprite = libraryBackground;

                switch (GlobalGameInfo.GetCurrentDay()) {
                    case 0:
                        Sticker1Text.text = GameStrings.getString("end_of_quest_rashad_1_sticker1");
                        Sticker2Text.text = GameStrings.getString("end_of_quest_rashad_1_sticker2");
                        break;                                            
                    case 1:
                        Sticker1Text.text = GameStrings.getString("end_of_quest_rashad_2_sticker1");
                        Sticker2Text.text = GameStrings.getString("end_of_quest_rashad_2_sticker2");
                        break;                                            
                    case 2:
                        Sticker1Text.text = GameStrings.getString("end_of_quest_rashad_3_sticker1");
                        Sticker2Text.text = GameStrings.getString("end_of_quest_rashad_3_sticker2");
                        break;                                            
                    case 3:
                        Sticker1Text.text = GameStrings.getString("end_of_quest_rashad_4_sticker1");
                        Sticker2Text.text = GameStrings.getString("end_of_quest_rashad_4_sticker2");
                        break;                                            
                }
                break;
            case CharacterResources.CHARACTERS.LILA:

                NPC.sprite = NPCImages[1];
                TalkBubbleText.text = GameStrings.getString("talk_bubble_lila_1");
                TalkBubble2Text.text = GameStrings.getString("talk_bubble_lila_2");
                NPCStickersLila1[GlobalGameInfo.GetCurrentDay()].SetActive(true);
                NPCStickersLila2[GlobalGameInfo.GetCurrentDay()].SetActive(true);
                Background.sprite = communityCenterBackground;
                
                switch (GlobalGameInfo.GetCurrentDay()) {
                    case 0:
                        Sticker1Text.text = GameStrings.getString("end_of_quest_lila_1_sticker1");
                        Sticker2Text.text = GameStrings.getString("end_of_quest_lila_1_sticker2");
                        break;                                            
                    case 1:
                        Sticker1Text.text = GameStrings.getString("end_of_quest_lila_2_sticker1");
                        Sticker2Text.text = GameStrings.getString("end_of_quest_lila_2_sticker2");
                        break;                                            
                    case 2:
                        Sticker1Text.text = GameStrings.getString("end_of_quest_lila_3_sticker1");
                        Sticker2Text.text = GameStrings.getString("end_of_quest_lila_3_sticker2");
                        break;                                            
                    case 3:
                        Sticker1Text.text = GameStrings.getString("end_of_quest_lila_4_sticker1");
                        Sticker2Text.text = GameStrings.getString("end_of_quest_lila_4_sticker2");
                        break;                                            
                }
                break;
            case CharacterResources.CHARACTERS.CALINDAS:

                NPC.sprite = NPCImages[2];
                TalkBubbleText.text = GameStrings.getString("talk_bubble_calindas_1");
                TalkBubble2Text.text = GameStrings.getString("talk_bubble_calindas_2");
                NPCStickersCalindas1[GlobalGameInfo.GetCurrentDay()].SetActive(true);
                NPCStickersCalindas2[GlobalGameInfo.GetCurrentDay()].SetActive(true);
                Background.sprite = healthCenterBackground;

                switch (GlobalGameInfo.GetCurrentDay()) {
                    case 0:
                        Sticker1Text.text = GameStrings.getString("end_of_quest_calindas_1_sticker1");
                        Sticker2Text.text = GameStrings.getString("end_of_quest_calindas_1_sticker2");
                        break;                                            
                    case 1:
                        Sticker1Text.text = GameStrings.getString("end_of_quest_calindas_2_sticker1");
                        Sticker2Text.text = GameStrings.getString("end_of_quest_calindas_2_sticker2");
                        break;                                            
                    case 2:
                        Sticker1Text.text = GameStrings.getString("end_of_quest_calindas_3_sticker1");
                        Sticker2Text.text = GameStrings.getString("end_of_quest_calindas_3_sticker2");
                        break;                                            
                    case 3:
                        Sticker1Text.text = GameStrings.getString("end_of_quest_calindas_4_sticker1");
                        Sticker2Text.text = GameStrings.getString("end_of_quest_calindas_4_sticker2");
                        break;                                            
                }
                break;
            case CharacterResources.CHARACTERS.LEE:

                NPC.sprite = NPCImages[3];
                TalkBubbleText.text = GameStrings.getString("talk_bubble_lee_1");
                TalkBubble2Text.text = GameStrings.getString("talk_bubble_lee_2");
                NPCStickersLee1[GlobalGameInfo.GetCurrentDay()].SetActive(true);
                NPCStickersLee2[GlobalGameInfo.GetCurrentDay()].SetActive(true);
                Background.sprite = communityCenterBackground;

                switch (GlobalGameInfo.GetCurrentDay()) {
                    case 0:
                        Sticker1Text.text = GameStrings.getString("end_of_quest_lee_1_sticker1");
                        Sticker2Text.text = GameStrings.getString("end_of_quest_lee_1_sticker2");
                        break;
                    case 1:
                        Sticker1Text.text = GameStrings.getString("end_of_quest_lee_2_sticker1");
                        Sticker2Text.text = GameStrings.getString("end_of_quest_lee_2_sticker2");
                        break;
                    case 2:
                        Sticker1Text.text = GameStrings.getString("end_of_quest_lee_3_sticker1");
                        Sticker2Text.text = GameStrings.getString("end_of_quest_lee_3_sticker2");
                        break;
                    case 3:
                        Sticker1Text.text = GameStrings.getString("end_of_quest_lee_4_sticker1");
                        Sticker2Text.text = GameStrings.getString("end_of_quest_lee_4_sticker2");                                            
                        break;
                }
                break;
            case CharacterResources.CHARACTERS.ELISA:
            
                NPC.sprite = NPCImages[4];
                TalkBubbleText.text = GameStrings.getString("talk_bubble_elisa_1");
                TalkBubble2Text.text = GameStrings.getString("talk_bubble_elisa_2");
                NPCStickersElisa1[GlobalGameInfo.GetCurrentDay()].SetActive(true);
                NPCStickersElisa2[GlobalGameInfo.GetCurrentDay()].SetActive(true);
                Background.sprite = libraryBackground;

                switch (GlobalGameInfo.GetCurrentDay()) {
                    case 0:
                        Sticker1Text.text = GameStrings.getString("end_of_quest_elisa_1_sticker1");
                        Sticker2Text.text = GameStrings.getString("end_of_quest_elisa_1_sticker2");
                        break;
                    case 1:
                        Sticker1Text.text = GameStrings.getString("end_of_quest_elisa_2_sticker1");
                        Sticker2Text.text = GameStrings.getString("end_of_quest_elisa_2_sticker2");
                        break;
                    case 2:
                        Sticker1Text.text = GameStrings.getString("end_of_quest_elisa_3_sticker1");
                        Sticker2Text.text = GameStrings.getString("end_of_quest_elisa_3_sticker2");
                        break;
                    case 3:
                        Sticker1Text.text = GameStrings.getString("end_of_quest_elisa_4_sticker1");
                        Sticker2Text.text = GameStrings.getString("end_of_quest_elisa_4_sticker2");                                            
                        break;
                }
                break;
            default:
                throw new System.Exception("Cannot find Character. Check EndOfQuest.cs");
        }

        var questTitle = GlobalGameInfo.GetCurrentTask();
        GlobalGameInfo.FinishTask(questTitle);
        // Data collection
        DataCollection.LogEvent("Quest Completed! Title: " + questTitle + ", Character: " + GlobalGameInfo.GetCurrentNPC(), "QUEST COMPLETION");
    }

    public void ButtonClick()
    {
        if (ButtonText.text != GameStrings.getString("finish_day")) {
            TalkBubble.SetActive(false);
            TalkBubbleText.enabled = false;

            TalkBubble2.SetActive(true);
            TalkBubble2Text.enabled = true;

            Sticker1Text.enabled = false;
            Sticker2Text.enabled = false;

            ButtonText.text = GameStrings.getString("finish_day");
        } else {
            // Increase day gets updated in the saving class below

            // Reset number of journal items learned today
            GlobalGameInfo.journalItemsLearnedTodayNum = 0;

            // Saving the game progress
            SavingGame.SaveGameProgress();

            // Go to saving scene
            SceneManager.LoadScene("Saving");
        }
    }

}
