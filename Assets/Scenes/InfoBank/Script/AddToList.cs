using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//fills the page with the list items from GlobalGameInfo
public class AddToList : MonoBehaviour
{
    private int numWeeksInJournal = 1;
    private int currentDisplayWeek = 0;
    public Transform todoPersonPrefab;
    public Transform listItemPrefab;
    public Transform infoListItemPrefab;
    public Transform infoListItemResearchPrefab;
    public string whichList = "Dialog";

    public void decrementCurrentDisplayWeek()
    {
        if (currentDisplayWeek == 0)
        {
            currentDisplayWeek = numWeeksInJournal - 1;
        }
        else
        {
            currentDisplayWeek = currentDisplayWeek - 1;
        }
        List<GlobalGameInfo.InfoItem> list = new List<GlobalGameInfo.InfoItem>(GlobalGameInfo.infoList);
        list.Reverse();
        fillInfoList(list);
        Debug.Log("AFTER CHANGE DISPLAY: " + currentDisplayWeek);
        Debug.Log("AFTER CHANGE WEEKS: " + numWeeksInJournal);
    }

    public void incrementCurrentDisplayWeek()
    {
        currentDisplayWeek = (currentDisplayWeek + 1) % (numWeeksInJournal);
        List<GlobalGameInfo.InfoItem> list = new List<GlobalGameInfo.InfoItem>(GlobalGameInfo.infoList);
        list.Reverse();
        fillInfoList(list);
        Debug.Log("AFTER CHANGE DISPLAY: " + currentDisplayWeek);
        Debug.Log("AFTER CHANGE WEEKS: " + numWeeksInJournal);
    }
    private string getStringRep(int i)
    {
        switch(i)
        {
            case 0:
                return "Monday";
            case 1:
                return "Tuesday";
            case 2:
                return "Wednesday";
            case 3:
                return "Thursday";
            case 4:
                return "Friday";
            case 5:
                return "Saturday";
            default:
                return "Sunday";
        }
    }
    void Start()
    {
        switch(whichList){
            case "Dialog":
                fillTodoList(GlobalGameInfo.todoList);
                break;
            case "Contacts":
                fillContactList(GlobalGameInfo.contactsList);
                break;
            case "Settings":
                fillSettingsList();
                break;
            case "Dictionary":
                fillDictionaryList();
                break;
            case "Info":
                // This makes it newest goes up top
                List<GlobalGameInfo.InfoItem> list = new List<GlobalGameInfo.InfoItem>(GlobalGameInfo.infoList);
                list.Reverse();
                fillInfoList(list);
                break;
        }
    }

    private void fillTodoList(List<GlobalGameInfo.TodoItem> list){
        if(list.Count == 0){
            return;
        }

        Transform contentParent = this.gameObject.transform.Find("Scroll View/Viewport/Content");

        // Code from here: https://forum.unity.com/threads/deleting-all-chidlren-of-an-object.92827/ 
        // Deletes all children of the content object.
        List<GameObject> children = new List<GameObject>();
        foreach (Transform child in contentParent) children.Add(child.gameObject);
        children.ForEach(child => Destroy(child));

        // Destory placeholder saying no todo list
        // Destroy(this.gameObject.transform.Find("Scroll View/Viewport/Content/No Info Yet").gameObject);
        CharacterResources cr = new CharacterResources();

        // Create the list of lists. Each index represents the todo lists for a week
        Dictionary<int, CharacterResources.CHARACTERS> weekDict = new Dictionary<int, CharacterResources.CHARACTERS>();
        List<List<GlobalGameInfo.TodoItem>> byWeek = new List<List<GlobalGameInfo.TodoItem>>();
        for (int i = 0; i < GlobalGameInfo.numWeeks; i++)
        {
            byWeek.Add(new List<GlobalGameInfo.TodoItem>());
        }
        // Sort the input list by the week they were assigned
        for (int i = 0; i < list.Count; i++)
        {
            byWeek[list[i].weekAssigned].Add(list[i]);
            if (!weekDict.ContainsKey(list[i].weekAssigned)) {
                weekDict.Add(list[i].weekAssigned, list[i].character);
            }
        }

        /// This makes it so newest goes up top, oldest is down below
        for (int i = GlobalGameInfo.numWeeks - 1; i >= 0; i--) {
            List<GlobalGameInfo.TodoItem> weekList = byWeek[i];
            // Again, the latest items are at the end of the list, so we go backwards to create them first
            if (weekList.Count > 0)
            {
                
                // Instantiate TodoPerson prefab
                Transform newTodoPerson = Instantiate(todoPersonPrefab, contentParent);

                // Update a person's header
                Transform header = newTodoPerson.Find("Header");
                header.gameObject.SetActive(true);
                Transform characterName = header.transform.Find("Character/CharacterName");
                Transform characterPic = header.transform.Find("Character/CharacterPic");
                Transform daysPassed = header.transform.Find("DaysPassed");
                characterPic.gameObject.GetComponent<Image>().sprite = cr.GetSmallIcon(weekDict[i]);
                characterName.gameObject.GetComponent<Text>().text = CharacterResources.GetName(weekDict[i]).ToUpper();

                Transform weekText = header.transform.Find("WeekAndDay/WeekText");
                // Transform dayText = header.transform.Find("WeekAndDay/DayText");
                // So that week 0 shows up as week 1 in the UI
                weekText.gameObject.GetComponent<Text>().text = "Week " + (i + 1).ToString();
                // dayText.gameObject.GetComponent<Text>().text = list[i].GetDayAssignedAsString();

                for (int j = 0; j < 5; j++)
                {
                    Transform filled = header.transform.Find("DaysPassed/Filled" + j.ToString());
                    Transform unfilled = header.transform.Find("DaysPassed/Unfilled" + j.ToString());
                    if (j <= i)
                    {
                        filled.gameObject.GetComponent<Image>().color = cr.GetColor(weekDict[i]);
                        filled.gameObject.SetActive(true);
                        unfilled.gameObject.SetActive(false);
                    }
                    else
                    {
                        unfilled.gameObject.GetComponent<Image>().color = cr.GetColor(weekDict[i]);
                        filled.gameObject.SetActive(false);
                        unfilled.gameObject.SetActive(true);
                    }
                }
                

                for (int j = weekList.Count - 1; j >= 0; j--)
                {
                    // Create the todo item list;
                    Transform newItemListParent = newTodoPerson.Find("TodoItemList");
                    Transform newItem = Instantiate(listItemPrefab, newItemListParent);
                    newItem.GetComponent<TodoManager>().setDetails(weekList[j]);
                }
            }
        }
    }


    private void fillSettingsList()
    {
        // Fill in with settings list
    }

    private void fillDictionaryList()
    {
        // Fill in with Dictionary list
    }

    private void fillInfoList(List<GlobalGameInfo.InfoItem> list){
        Transform topElementsTransform = this.gameObject.transform.Find("Info List Top Elements");
        if(list.Count == 0){
            topElementsTransform.gameObject.SetActive(false);
            return;
        }

        Transform content = this.gameObject.transform.Find("Scroll View/Viewport/Content");

        // Code from here: https://forum.unity.com/threads/deleting-all-chidlren-of-an-object.92827/ 
        // Deletes all children of the content object.
        List<GameObject> children = new List<GameObject>();
        foreach (Transform child in content) children.Add(child.gameObject);
        children.ForEach(child => Destroy(child));


        CharacterResources cr = new CharacterResources();
        
        // Assign the quest giver at the top (this should change depending on the week/quest?)
        // Im not actually sure if the top thing we want is the quest giver? i just put it as such for now
        Transform questIcon = topElementsTransform.Find("WeekAndPersonHeader/WeekAndPersonBackground/PersonIcon");
        Transform questChar = topElementsTransform.Find("WeekAndPersonHeader/WeekAndPersonBackground/PersonText");
        

        // Only valid choices to be clicked have the quest attribute nonnull. This might not be the first list item so we go through
        // the list items until we find one where the quest attribute is nonnull to extract the information about who gave the
        // quest. At least one item will be like this (we need to have at least one correct answer)
        // Added this condition because otherwise for some items that have quest==null it won't show anything in the journal app
        Dictionary<int, CharacterResources.CHARACTERS> iconsWeekDict = new Dictionary<int, CharacterResources.CHARACTERS>();
        int numWeeksSeen = 0;
        foreach (GlobalGameInfo.InfoItem i in list)
        {
            if (i.quest != null && !iconsWeekDict.ContainsKey(i.week))
            {
                iconsWeekDict.Add(i.week, i.quest.questGiver);
                numWeeksSeen++;
            }
        }

        numWeeksInJournal = numWeeksSeen;

        if (numWeeksInJournal == 1)
        {
            topElementsTransform.Find("LeftArrow").gameObject.SetActive(false);
            topElementsTransform.Find("RightArrow").gameObject.SetActive(false);
            topElementsTransform.Find("LeftArrowEmpty").gameObject.SetActive(true);
            topElementsTransform.Find("RightArrowEmpty").gameObject.SetActive(true);
        }
        else
        {
            topElementsTransform.Find("LeftArrow").gameObject.SetActive(true);
            topElementsTransform.Find("RightArrow").gameObject.SetActive(true);
            topElementsTransform.Find("LeftArrowEmpty").gameObject.SetActive(false);
            topElementsTransform.Find("RightArrowEmpty").gameObject.SetActive(false);
        }

        questIcon.gameObject.GetComponent<Image>().sprite = cr.GetSmallIcon(iconsWeekDict[currentDisplayWeek]);
        questChar.gameObject.GetComponent<Text>().text = CharacterResources.GetName(iconsWeekDict[currentDisplayWeek]).ToUpper();


        Transform questWeek = topElementsTransform.Find("WeekAndPersonHeader/WeekAndPersonBackground/WeekText");
        // So week 0 becomes week 1 in the UI
        questWeek.gameObject.GetComponent<Text>().text = "WEEK " + (currentDisplayWeek + 1).ToString();

        // Figure out which notes are associated with which days (we have headers based on days of the week)
        Dictionary<string, List<GlobalGameInfo.InfoItem>> dict = new Dictionary<string, List<GlobalGameInfo.InfoItem>>();
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].week == currentDisplayWeek)
            {
                string day = getStringRep(list[i].day);
                if (!dict.ContainsKey(day))
                {
                    dict.Add(day, new List<GlobalGameInfo.InfoItem>());
                }
                dict[day].Add(list[i]);
            }
        }

        // loop over each day
        foreach (KeyValuePair<string, List<GlobalGameInfo.InfoItem>> elem in dict)
        {
            // Update day
            Transform newContainer = Instantiate(listItemPrefab, content);
            newContainer.Find("Day/DayText").GetComponent<Text>().text = elem.Key.ToUpper();

            // Dictionary for this day, of characters
            // Find which notes belong to which characters
            Dictionary<string, List<GlobalGameInfo.InfoItem>> chars = new Dictionary<string, List<GlobalGameInfo.InfoItem>>();
            Transform itemsList = newContainer.Find("InfoItemsList");
            for (int i = 0; i < elem.Value.Count; i++)
            {
                GlobalGameInfo.InfoItem item = elem.Value[i];
                string character = item.character;
                if (!chars.ContainsKey(character))
                {
                    chars.Add(character, new List<GlobalGameInfo.InfoItem>());
                }
                chars[character].Add(item);
            }
           
            // For each character, create their section of notes
            foreach (KeyValuePair<string, List<GlobalGameInfo.InfoItem>> character in chars)
            {
                // Add all notes of people
                if (GlobalGameInfo.researchVersion <= 0) {
                    Transform newItem = Instantiate(infoListItemPrefab, itemsList);
                    newItem.GetComponent<InfoManager>().setDetails(character.Key, character.Value);
                } else {
                    Transform newItem = Instantiate(infoListItemResearchPrefab, itemsList);
                    newItem.GetComponent<InfoManager>().setDetails(character.Key, character.Value);
                }
            }
            
        }
        
    }

    private void fillContactList(Dictionary<CharacterResources.CHARACTERS, GlobalGameInfo.CharacterItem> list){
        if(list.Count == 0){return;}
        
        Destroy(this.gameObject.transform.Find("Scroll View/Viewport/Content/No Info Yet").gameObject);
        Transform go = this.gameObject.transform.Find("Scroll View/Viewport/Content");
        bool firstitem = true;
        
        foreach(KeyValuePair<CharacterResources.CHARACTERS, GlobalGameInfo.CharacterItem> entry in list)
        {
            Transform newItem = Instantiate(listItemPrefab, go);
            newItem.GetComponent<CharacterSheetManager>().setDetails(entry.Value);
            if(firstitem){
                newItem.GetComponent<CharacterSheetManager>().openDetailPage();
                firstitem = false;
            }
        }
    }
}
