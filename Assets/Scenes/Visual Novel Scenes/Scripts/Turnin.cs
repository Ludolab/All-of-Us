using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Reflection;
using System.Threading;
using TMPro;

public class Turnin : MonoBehaviour
{

    public Image continueButton;
    public Image continueArrow;

    public Sprite continueClickable;
    public Sprite continueUnclickable;

    public Sprite libraryBackground;
    public Sprite communityCenterBackground;
    public Sprite healthCenterBackground;

    public Sprite rashadGiver;
    public Sprite rashadAnswer;

    public Sprite elisaGiver;
    public Sprite elisaAnswer;

    public Sprite msleeGiver;
    public Sprite msleeAnswer;

    public Sprite calindasGiver;
    public Sprite calindasAnswer;

    public Sprite lilaGiver;
    public Sprite lilaAnswer;

    public Image giverPerson;
    public Text giverName;
    public Text submitOptionText;

    public TextMeshProUGUI option1;
    public TextMeshProUGUI option2;
    public TextMeshProUGUI option3;
    public TextMeshProUGUI option4;
    private TextMeshProUGUI[] options;

    public Image option1Character;
    public Image option2Character;
    public Image option3Character;
    public Image option4Character;
    private Image[] optionCharacters;

    private Quest[] optionQuests;

    private TurninSelectOption selectedOption = null;
    private Quest selectedQuest = null; 

    private Color arrowUnclickable = new Color(200.0f / 255.0f, 200.0f / 255.0f, 200.0f / 255.0f, 1.0f); // E2FFDD 
    private Color arrowClickable = new Color(140.0f / 255.0f, 21.0f / 255.0f, 59.0f / 255.0f, 1.0f); // E2FFDD
 

    // Start is called before the first frame update
    void Start()
    {
        options = new TextMeshProUGUI[4] { option1, option2, option3, option4 };
        optionCharacters = new Image[4] { option1Character, option2Character, option3Character, option4Character };
        optionQuests = new Quest[4]; 
        fillOptionDetails();
        fillGiverDetails();
    }

    // Configures who shows up for the block party screen
    public void fillGiverDetails()
    {
        CharacterResources.CHARACTERS c = QuestManager.questGiver;
        switch (c)
        {   
            case CharacterResources.CHARACTERS.CALINDAS:
                giverPerson.sprite = calindasGiver;
                break;
            case CharacterResources.CHARACTERS.RASHAD:
                giverPerson.sprite = rashadGiver;
                break;
            case CharacterResources.CHARACTERS.LEE:
                giverPerson.sprite = msleeGiver;
                break;
            case CharacterResources.CHARACTERS.LILA:
                giverPerson.sprite = lilaGiver;
                break;
            case CharacterResources.CHARACTERS.ELISA:
                giverPerson.sprite = elisaGiver;
                break;
        }
        giverName.text = CharacterResources.GetName(c);
    }

    // Configures who shows up for the block party screen
    public void fillOptionDetails()
    {
        
        List<GlobalGameInfo.InfoItem> allOptions = new List<GlobalGameInfo.InfoItem>(GlobalGameInfo.infoList);
        GlobalGameInfo.InfoItem[] validOptions = new GlobalGameInfo.InfoItem[4];
        Debug.Log("GlobalGameInfo info list length" + allOptions.Count);
        if (allOptions.Count < 4)
        {
            Debug.Log("Not enough options");
            return;
        }
        foreach (GlobalGameInfo.InfoItem item in allOptions)
        {
            if (item.day == GlobalGameInfo.GetCurrentDay() && item.week == GlobalGameInfo.GetCurrentWeek() && item.quest != null && item.quest.questGiver == GlobalGameInfo.GetCurrentNPC()
                    && item.quest.optionNumber > 0)
            {
                validOptions[item.quest.optionNumber - 1] = item;
                optionQuests[item.quest.optionNumber - 1] = item.quest;
            }
        }

        for (int i = 0; i < 4; i++)
        {
            GlobalGameInfo.InfoItem info = validOptions[i];
            TextMeshProUGUI optionText = options[i];
            Image optionCharacter = optionCharacters[i];
            switch (info.characterEnum)
            {
                case CharacterResources.CHARACTERS.CALINDAS:
                    optionCharacter.sprite = calindasGiver;
                    break;
                case CharacterResources.CHARACTERS.RASHAD:
                    optionCharacter.sprite = rashadGiver;
                    break;
                case CharacterResources.CHARACTERS.LEE:
                    optionCharacter.sprite = msleeGiver;
                    break;
                case CharacterResources.CHARACTERS.LILA:
                    optionCharacter.sprite = lilaGiver;
                    break;
                case CharacterResources.CHARACTERS.ELISA:
                    optionCharacter.sprite = elisaGiver;
                    break;
            }
            optionText.text = info.description;
        }
    }

    public void selectQuest (TurninSelectOption option)
    {
        selectedQuest = optionQuests[option.optionNum];
        if (selectedOption != null)
        {
            selectedOption.unselect();
        }
        else
        {
            continueButton.sprite = continueClickable;
            continueArrow.color = arrowClickable;
        }
        selectedOption = option;
        
        submitOptionText.text = selectedQuest.description;
    }

    public void onClickContinueButton()
    {
        if (selectedQuest != null)
        {
            QuestManager.submittedQuest = QuestManager.FindQuestById(selectedQuest.questId);
            // This is such a hacky way to do it but i'm just writing it so that it works with 
            // the current set up of how quest submission is done. There are definitely better ways
            // of doing this but I don't want to break anything with this task yet.

            if (QuestManager.submittedQuest != null)
            {
                Debug.Log("Found the quest!");
                QuestManager.submittedQuest.optionNumber = selectedQuest.optionNumber;
            }
            else
            {
                Debug.Log("DID NOT FIND THE QUEST!");
            }
            // Making sure to go directly to "Select profile" view without having to click on the saved game again
            QuestManager.SubmitQuest(QuestManager.submittedQuest);
        }
    }
}
