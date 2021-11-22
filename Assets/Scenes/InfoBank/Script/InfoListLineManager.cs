using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InfoListLineManager : MonoBehaviour
{
    public void setInfo(GlobalGameInfo.InfoItem item, bool isLast)
    {

        this.transform.Find("Content/Text").GetComponent<Text>().text = item.description;
        // If its the last note, we don't want to the divider
        if(isLast)
        {
            this.transform.Find("Divider").gameObject.SetActive(false);
        } 
    }
}
