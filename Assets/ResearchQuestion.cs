using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResearchQuestion : MonoBehaviour
{

    public GameObject selectButton;
    public Toggle learningFirstOption;
    public Toggle learningSecondOption;
    public Toggle learningThirdOption;
    public Toggle capabilityFirstOption;
    public Toggle capabilitySecondOption;
    public Toggle capabilityThirdOption;
    public ToggleGroup learningToggleGroup;
    public ToggleGroup capabilityToggleGroup;
    public Text journalItemText;

    // Start is called before the first frame update
    void Start()
    {
        if (GlobalGameInfo.researchVersion == 2) {
            // Disabling the toggles so users cannot change the toggles
            learningFirstOption.enabled = false;
            learningSecondOption.enabled = false;
            learningThirdOption.enabled = false;
            capabilityFirstOption.enabled = false;
            capabilitySecondOption.enabled = false;
            capabilityThirdOption.enabled = false;

            // Hard coded part just for the research version:
            // Setting the options according to a pre-defined selection
            switch (journalItemText.text) {
                // Quest 1
                // 1-1
                case "Mrs. Lee could ask Lila to pick up the prescription for her":
                    learningSecondOption.GetComponent<Toggle>().isOn = true;
                    capabilityFirstOption.GetComponent<Toggle>().isOn = true;
                    break;
                // 1-2
                case "Mrs. Lee could ask Lila to come to the pharmacy with her so she has support asking clarifying questions":
                    learningFirstOption.GetComponent<Toggle>().isOn = true;
                    capabilityFirstOption.GetComponent<Toggle>().isOn = true;
                    break;
                // 1-3
                case "Mrs. Lee can learn to use a secure online portal to look up drug information from a safe resource":
                    learningFirstOption.GetComponent<Toggle>().isOn = true;
                    capabilityFirstOption.GetComponent<Toggle>().isOn = true;
                    break;
                 // 1-4
                case "Mrs. Lee can use Google to find a reliable resource to provide information about Eddie’s medication":
                    learningThirdOption.GetComponent<Toggle>().isOn = true;
                    capabilitySecondOption.GetComponent<Toggle>().isOn = true;
                    break;

                // Quest 2
                // 2-1
                case "Mrs. Lee can go to the health programming workshop at the library and ask for help":
                    learningFirstOption.GetComponent<Toggle>().isOn = true;
                    capabilityFirstOption.GetComponent<Toggle>().isOn = true;                    
                    break;
                // 2-2
                case "Mrs. Lee can ask Rashad to schedule her appointment":
                    learningThirdOption.GetComponent<Toggle>().isOn = true;
                    capabilityFirstOption.GetComponent<Toggle>().isOn = true;                      
                    break;
                // 2-3
                case "Mrs. Lee should make an appointment to meet a new primary care doctor and ask the new doctor about her headaches":
                    learningFirstOption.GetComponent<Toggle>().isOn = true;
                    capabilityFirstOption.GetComponent<Toggle>().isOn = true;                      
                    break;
                // 2-4
                 case "Mrs. Lee could go to Urgent Care to see someone about her headaches":
                    learningSecondOption.GetComponent<Toggle>().isOn = true;
                    capabilitySecondOption.GetComponent<Toggle>().isOn = true;                     
                    break;
                    
                // Quest 3
                // 3-1
                case "Mrs. Lee could call Eddie and practice her questions with him":
                    learningFirstOption.GetComponent<Toggle>().isOn = true;
                    capabilityFirstOption.GetComponent<Toggle>().isOn = true;                    
                    break;
                // 3-2
                case "Mrs. Lee could ask Mrs. Lee to go to her doctor appointment":
                    learningThirdOption.GetComponent<Toggle>().isOn = true;
                    capabilitySecondOption.GetComponent<Toggle>().isOn = true;                      
                    break;
                // 3-3
                case "Mrs. Lee can create a list of questions and symptoms to take to her appointment with her":
                    learningFirstOption.GetComponent<Toggle>().isOn = true;
                    capabilityFirstOption.GetComponent<Toggle>().isOn = true;                      
                    break;
                // 3-4
                 case "Mrs. Lee could ask someone to be on the phone with her during the appointment":
                    learningThirdOption.GetComponent<Toggle>().isOn = true;
                    capabilityFirstOption.GetComponent<Toggle>().isOn = true;            
                    break;

                // Quest 4
                // 4-1
                case "Mrs. Lee can work with Eddie to setup a system for sharing health information online":
                    learningFirstOption.GetComponent<Toggle>().isOn = true;
                    capabilityThirdOption.GetComponent<Toggle>().isOn = true;                    
                    break;
                // 4-2
                case "Mrs. Lee can keep a folder with all her health information":
                    learningThirdOption.GetComponent<Toggle>().isOn = true;
                    capabilityFirstOption.GetComponent<Toggle>().isOn = true;                      
                    break;
                // 4-3
                case "Mrs. Lee should talk to Eddie about family health history":
                    learningFirstOption.GetComponent<Toggle>().isOn = true;
                    capabilityFirstOption.GetComponent<Toggle>().isOn = true;                      
                    break;
                // 4-4
                 case "Mrs. Lee can develop the habit of scheduling the next checkup while she's in the office":
                    learningFirstOption.GetComponent<Toggle>().isOn = true;
                    capabilityThirdOption.GetComponent<Toggle>().isOn = true;
                    break;

            }
        }

        if (SceneManager.GetActiveScene().name == "Quest Turnin Testing") {
            if (GlobalGameInfo.researchVersion == 2 || GlobalGameInfo.researchVersion == 1 && GlobalGameInfo.allResearchQuestionsAnswered) {
                selectButton.SetActive(true);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Quest Turnin Testing" &&
            GlobalGameInfo.researchVersion == 1 &&
            GlobalGameInfo.allResearchQuestionsAnswered) {
            selectButton.SetActive(true);
        }
    }

    void onClickSelectButton() {
    }

}
