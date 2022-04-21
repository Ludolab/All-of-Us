using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

//this script grabs the InfoItems from GlobalGameInfo
//and then instantiates the journal prefabs from them
//it replaces the information in the prefabs with the saved info
public class InfoManager : MonoBehaviour
{
    private static Transform lastItem = null;

    public Transform infoListLineDivider;
    public Transform infoListLineItem;
    public Transform ResearchQuestion;

    GameObject phone;
    GameObject phoneContainer;
    CharacterResources cr;

    void Start()
    {
        phone = GameObject.Find("Child Container");
        phoneContainer = GameObject.Find("Phone");
        cr = new CharacterResources();
    }

    public void setDetails(string characterName, List<GlobalGameInfo.InfoItem> items)
    {

        if (cr == null)
        {
            cr = new CharacterResources();
        }

        // Set the notes header name, pic and background color corresponding to the person
        if (GlobalGameInfo.researchVersion <= 0) {
            Transform charName = this.transform.Find("Header/PersonText");
            Transform charPic = this.transform.Find("Header/PersonIcon");
            Transform charBackground = this.transform.Find("Header");
            charPic.gameObject.GetComponent<Image>().sprite = cr.GetSmallIcon(items[0].characterEnum);
            charName.gameObject.GetComponent<Text>().text = characterName.ToUpper();
            charBackground.gameObject.GetComponent<Image>().color = cr.GetColor(items[0].characterEnum);
        }
        
        Transform go = this.gameObject.transform.Find("InfoList");

        Transform newItem;
        for (int i = 0; i < items.Count; i++)
        {
            if (GlobalGameInfo.researchVersion <= 0) {
                newItem = Instantiate(infoListLineItem, go);
            } else {
                newItem = Instantiate(ResearchQuestion, go);
            }
            newItem.GetComponent<InfoListLineManager>().setInfo(items[i]);
            if (i != items.Count - 1)
            {
                Instantiate(infoListLineDivider, go);
            }
        }
    }

}