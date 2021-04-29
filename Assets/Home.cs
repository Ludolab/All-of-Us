﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Reflection;
using System.Threading;
public class Home : MonoBehaviour {

    public GameObject infoButton;
    public GameObject goToSleepButton;
    public GameObject backButton;
    public GameObject yellowContainer;
    public GameObject whiteContainer;
    public GameObject separatingLines;
    public GameObject statTitles;
    public GameObject yellowContainerText;
    public GameObject TitleText;
    public GameObject commEngageVal;
    public GameObject questsCompletedVal;
    public GameObject journalEntriesVal;
    public GameObject customTagsVal;
    public GameObject daysUntilBlockPartyVal;

    private void Start() {

        // TitleText.enabled = false;
        // yellowContainerText.enabled = false;
        
        commEngageVal.GetComponent<UnityEngine.UI.Text>().text = GlobalGameInfo.GetEngagement().ToString() + "%";
        questsCompletedVal.GetComponent<UnityEngine.UI.Text>().text = (GlobalGameInfo.GetEngagement() / 5).ToString() + "/20";
        journalEntriesVal.GetComponent<UnityEngine.UI.Text>().text = GlobalGameInfo.infoList.Count.ToString();
        customTagsVal.GetComponent<UnityEngine.UI.Text>().text = TagManager.customTags.Count.ToString();
        daysUntilBlockPartyVal.GetComponent<UnityEngine.UI.Text>().text = GlobalGameInfo.GetRemainDays().ToString();

        // commEngageVal.enabled = false;
        // questsCompletedVal.enabled = false;
        // journalEntriesVal.enabled = false;
        // customTagsVal.enabled = false;
        // daysUntilBlockPartyVal.enabled = false;

        // yellowContainer.SetActive(false);
        // whiteContainer.SetActive(false);
        // backButton.SetActive(false);
        // separatingLines.SetActive(false);
        // statTitles.SetActive(false);
        
        // infoButton.SetActive(true);
        // goToSleepButton.SetActive(true);

    }
    
    public void showInfo() {

        TitleText.SetActive(true);
        yellowContainerText.SetActive(true);

        // commEngageVal.enabled = true;
        // questsCompletedVal.enabled = true;
        // journalEntriesVal.enabled = true;
        // customTagsVal.enabled = true;
        // daysUntilBlockPartyVal.enabled = true;

        commEngageVal.SetActive(true);
        questsCompletedVal.SetActive(true);
        journalEntriesVal.SetActive(true);
        customTagsVal.SetActive(true);
        daysUntilBlockPartyVal.SetActive(true);

        yellowContainer.SetActive(true);
        whiteContainer.SetActive(true);
        backButton.SetActive(true);
        separatingLines.SetActive(true);
        statTitles.SetActive(true);

        infoButton.SetActive(false);
        goToSleepButton.SetActive(false);
    }

    public void hideInfo() {

        TitleText.SetActive(false);
        yellowContainerText.SetActive(false);

        // commEngageVal.enabled = false;
        // questsCompletedVal.enabled = false;
        // journalEntriesVal.enabled = false;
        // customTagsVal.enabled = false;
        // daysUntilBlockPartyVal.enabled = false;

        commEngageVal.SetActive(false);
        questsCompletedVal.SetActive(false);
        journalEntriesVal.SetActive(false);
        customTagsVal.SetActive(false);
        daysUntilBlockPartyVal.SetActive(false);

        yellowContainer.SetActive(false);
        whiteContainer.SetActive(false);
        backButton.SetActive(false);
        separatingLines.SetActive(false);
        statTitles.SetActive(false);
        
        infoButton.SetActive(true);
        goToSleepButton.SetActive(true);
    }

    public void goToSleep() {
        // Only if PC has finished the 5 quests for the day
        if (InkFileManager.CanAdvanceDay()) {

            // Increase day by one
            GlobalGameInfo.IncreaseDay();

            // Go back to map
            SceneManager.LoadScene("Basic2DMap");

            // Toggle new day (triggers hint bubble to say "Good Morning")
            GlobalGameInfo.toggleNewDay();
        }
    }

}
