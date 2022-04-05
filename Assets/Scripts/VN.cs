using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System.IO;
using System.Collections.Generic;

public class VN : MonoBehaviour
{
    public TextMeshProUGUI buildingName;

    // Tutorial components
    public GameObject TutorialContainerDictionary;
    public GameObject TutorialArrowDictionary;
    public Button TutorialButtonDictionary;
    public TextMeshProUGUI YellowTitleDictionary;
    public TextMeshProUGUI WhiteTitleDictionary;
    public TextMeshProUGUI WhiteTextDictionary;
    public TextMeshProUGUI ButtonTextDictionary;
    public GameObject DictionaryGlow;
    public GameObject TutorialContainerSpeed;
    public Button TutorialButtonSpeed;
    public TextMeshProUGUI YellowTitleSpeed;
    public TextMeshProUGUI WhiteTitleSpeed;
    public TextMeshProUGUI WhiteTextSpeed;
    public TextMeshProUGUI ButtonTextSpeed;
    public GameObject SpeedImage;
    public GameObject SpeedGlow;
    
    // Show Dialog only when tooltip complete
    public List<GameObject> toggleComponents;

    // Start is called before the first frame update
    void Start()
    {
        Destroy (GameObject.FindGameObjectWithTag("Music"));
        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicClass>().PlayMusic();

        switch (SceneManager.GetActiveScene().name) {
            case ("CommunityVN"):
                buildingName.text = GameStrings.getString("community_center");
                break;
            case ("HealthVN"):
                buildingName.text = GameStrings.getString("health_clinic");
                break;
            case ("LibraryVN"):
                buildingName.text = GameStrings.getString("library");                   
                break;
        }

        // Tutorial
        if (!GlobalGameInfo.dictionaryFlag) {
            TutorialContainerDictionary.SetActive(true);
            TutorialArrowDictionary.SetActive(true);
            TutorialButtonDictionary.enabled = true;
            DictionaryGlow.SetActive(true);

            YellowTitleDictionary.text = GameStrings.getString("dictionary_vn_yellowtitle");
            WhiteTitleDictionary.text = GameStrings.getString("dictionary_vn_whitetitle");
            WhiteTextDictionary.text = GameStrings.getString("dictionary_vn_whitetext_1") + CharacterResources.GetName(GlobalGameInfo.GetCurrentNPC()) + GameStrings.getString("dictionary_vn_whitetext_2");
            ButtonTextDictionary.text = GameStrings.getString("dictionary_vn_buttontext");

            YellowTitleSpeed.text = GameStrings.getString("speed_vn_yellowtitle");
            WhiteTitleSpeed.text = GameStrings.getString("speed_vn_whitetitle");
            WhiteTextSpeed.text = GameStrings.getString("speed_vn_whitetext");
            ButtonTextSpeed.text = GameStrings.getString("speed_vn_buttontext");
        }
    }

    public void tutorialDictionaryClick() {

        TutorialContainerDictionary.SetActive(false);
        TutorialArrowDictionary.SetActive(false);
        TutorialButtonDictionary.enabled = false;
        DictionaryGlow.SetActive(false);
        GlobalGameInfo.dictionaryFlag = true;

        TutorialContainerSpeed.SetActive(true);
        TutorialButtonSpeed.enabled = true;
        SpeedImage.SetActive(true);
        SpeedGlow.SetActive(true);
    }
    public void tutorialSpeedClick() {
        TutorialContainerSpeed.SetActive(false);
        TutorialButtonSpeed.enabled = false;
        SpeedImage.SetActive(false);
        SpeedGlow.SetActive(false);
        GlobalGameInfo.speedFlag = true;
    }
    
    // I tried to do it a different way so it isn't using update as this is wasteful, but issues kept popping up, like disappearing
    // objects and objects not behaving as expected, so I am keeping it like this for the time being.
    private void Update()
    {
        if (!GlobalGameInfo.speedFlag)
        {
            foreach (GameObject go in toggleComponents)
            {
                go.SetActive(false);
            }
        }
        else
        {
            foreach (GameObject go in toggleComponents)
            {
                go.SetActive(true);
            }
        }
    }
}
