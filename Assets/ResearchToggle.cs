using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResearchToggle : MonoBehaviour
{

    public Text itemText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setToggle(Toggle toggle) {

        // If toggle has been changed to "ON"
        if (toggle.GetComponent<Toggle>().isOn) {

            int newValue = toggle.name[toggle.name.Length - 1] - '0';
            // Searching the journal item with the same text as description
            // and updating its learning and capability values
            for (int i = 0; i < GlobalGameInfo.infoList.Count; i++)
            {
                if (GlobalGameInfo.infoList[i].description == itemText.text) {
                    // Updating the value and saving it
                    if (toggle.transform.parent.name == "Learning") {
                        GlobalGameInfo.infoList[i].researchLearning = newValue;
                    } else if (toggle.transform.parent.name == "Capability") {
                        GlobalGameInfo.infoList[i].researchCapability = newValue;
                    }
                    // Data Collection - Recording the new value to the cloud
                    DataCollection.LogEvent("RECORDING RESEARCH DATA. Version: " + GlobalGameInfo.researchVersion + ", User code: " + GlobalGameInfo.playerCode + ", Quest Number: " + GlobalGameInfo.GetCurrentDay() + ", Journal Item: " + itemText.text + ", Category: " + toggle.transform.parent.name + ", Answer selected: " + newValue, "RESEARCH ANSWER CHANGED");

                    this.updateNumResearchQuestionsAnswered();

                    break;
                }
            }
        }
    }

    public void updateNumResearchQuestionsAnswered() {
        for (int i = 0; i < GlobalGameInfo.infoList.Count; i++)
        {
            if (GlobalGameInfo.infoList[i].researchLearning < 0 ||
                GlobalGameInfo.infoList[i].researchCapability < 0) {
                return;
            }
        }
        // All research questions (items) have been answered
        GlobalGameInfo.allResearchQuestionsAnswered = true;
    }
}


