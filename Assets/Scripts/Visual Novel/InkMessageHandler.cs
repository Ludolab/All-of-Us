﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

/// <summary>
/// Handles the receiving functions for the Flowchart Ink message handlers.
/// </summary>
[RequireComponent(typeof(Flowchart))]
public class InkMessageHandler : MonoBehaviour
{
    private Flowchart _fc;

    private void Start() {
        _fc = GetComponent<Flowchart>();
    }

    /// <summary>
    /// Adds a new notifcation to the notifications list
    /// </summary>
    public void AddNotification() {
        string notifString = _fc.GetStringVariable("notification");
        string[] notifInfo = notifString.Split('_');

        try {
            if (notifInfo.Length == 3) {
                GlobalGameInfo.addNewItemToInfoList(notifInfo[0], notifInfo[1],
                    notifInfo[2]);
            } else if (notifInfo.Length == 4) {
                GlobalGameInfo.addNewItemToInfoList(notifInfo[0], notifInfo[1],
                    notifInfo[2], notifInfo[3]);
                // QuestManager.AddQuest(notifInfo[3]);
            } else {
                throw new System.Exception();
            }
        } catch {
            string errormsg = "Error parsing new notification string.\n " +
                "Expected string of the form character_day_description " +
                "or character_day_description_questId\n" +
                "Instead received:";
            foreach (string s in notifInfo) {
                errormsg += "\n" + s;
            }
            Debug.LogError(errormsg);
        }
    }

    /// <summary>
    /// Adds a a new contact to the contacts list
    /// </summary>
    public void AddContact() {
        string contactString = _fc.GetStringVariable("new_contact");
        if (contactString.ToLower().Contains("rashad")) {
            GlobalGameInfo.addNewItemToContactsList(
                "Rashad Williams",
                "Rashad Williams was born and raised in Bloomwood, and moved back after getting his Master’s Degree in Library Science. He is married with 2 children(wife Cheryl, children Octavia and Charles) and started out as the popular Young Adult Librarian for Bloomwood Library. Since being promoted to Head Librarian last year, he hasn’t been able to hold his popular story hour in the children's wing. He enjoys comic books, science fiction, and is an avid runner.",
                "Head Librarian", "Bloomwood Library",
                "He/Him/His",
                42, 0.6f, 0.2f, 0.9f, 0.95f);
        }
        // else if blah blah blah
    }

    /// <summary>
    /// Adds a quest to the quest list. Currently should just be the name of the quest
    /// that we'll look up later.
    /// </summary>
    public void AddQuest() {
        string questName = _fc.GetStringVariable("new_quest");
        string[] questInfo = questName.Split('_');
        try {
            QuestManager.AddQuest(questInfo[0], questInfo[1], questInfo[2]);
        } catch {
            string errormsg = "Error parsing new quest string.\n " +
                "Expected string of the form questId_questGiver\n " +
                "Instead received:";
            foreach (string s in questInfo) {
                errormsg += "\n" + s;
            }
            Debug.LogError(errormsg);
        }
    }
}
