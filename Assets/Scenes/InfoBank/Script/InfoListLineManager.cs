﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InfoListLineManager : MonoBehaviour
{
    private GlobalGameInfo.InfoItem item;
    private bool isLast;
    private bool buttonToggledOn = true;
    public void setInfo(GlobalGameInfo.InfoItem item, bool isLast)
    {
        this.item = item;
        this.isLast = isLast;
        // Update the detail page manager
        GetComponent<DetailPageManager>().setInfo(item);
        CharacterResources cr = new CharacterResources();

        this.transform.Find("Content/Text").GetComponent<Text>().text = item.description;
        // If its the last note, we don't want the divider
        if(isLast && GlobalGameInfo.researchInt <= 1)
        {
            this.transform.Find("Divider").gameObject.SetActive(false);
        }
        // If we have already viewed it before, don't have the red circle next to the line
        // Will only be 1, the first time we click the notes/journal app
        if (item.timesViewed != 1 && GlobalGameInfo.researchInt <= 1)
        {
            this.transform.Find("Content/Image").gameObject.SetActive(false);
        }

        if (GlobalGameInfo.researchInt > 1) {
            this.transform.Find("Content/NPCImage").gameObject.GetComponent<Image>().sprite = cr.GetSmallIcon(item.characterEnum);
        }
    }

    void Update()
    {
        // Will only be 1, the first time we click the notes/journal app
        if (item != null && item.timesViewed != 1 && buttonToggledOn && GlobalGameInfo.researchInt <= 1)
        {
            this.transform.Find("Content/Image").gameObject.SetActive(false);
            buttonToggledOn = false;
        } 
    }

}
