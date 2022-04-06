using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ResearchVersionTurnin : MonoBehaviour
{

    public GameObject MrsLeeProfile;
    public GameObject MrsLeeImage;
    public GameObject MrsLeeQuestion;
    public GameObject MrsLeeInstructions;
    public GameObject UIContainer;
    public Button viewProfileButton;
    public Button continueButton;
    public TextMeshProUGUI ButtonText;
    public bool showingProfile;

    // Start is called before the first frame update
    void Start()
    {
        continueButton.gameObject.SetActive(false);
        if (GlobalGameInfo.researchVersion == 1) {
            MrsLeeInstructions.SetActive(true);
            MrsLeeImage.SetActive(true);
            viewProfileButton.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalGameInfo.allResearchQuestionsAnswered) {
            continueButton.gameObject.SetActive(true);
        }
    }

    public void onViewProfileButtonClick() {
        if (!showingProfile) {
            MrsLeeImage.SetActive(false);
            MrsLeeQuestion.SetActive(false);
            MrsLeeProfile.SetActive(true);
            ButtonText.text = "Back To Solving";
            showingProfile = !showingProfile;

            UIContainer.SetActive(false);
            continueButton.gameObject.SetActive(false);

            // Data Collection - Recording that the player has clicked on the profile button - to the cloud
            DataCollection.LogEvent("RECORDING RESEARCH DATA. User code: " + GlobalGameInfo.playerCode + ", Quest Number: " + GlobalGameInfo.GetCurrentDay(), "Clicked On Mrs. Lee's Profile Button.");

        } else {
            MrsLeeImage.SetActive(true);
            MrsLeeQuestion.SetActive(true);
            MrsLeeProfile.SetActive(false);
            ButtonText.text = "View Mrs. Lee's Profile";
            showingProfile = !showingProfile;
            
            UIContainer.SetActive(true);
            continueButton.gameObject.SetActive(true);
        }
    }
}
