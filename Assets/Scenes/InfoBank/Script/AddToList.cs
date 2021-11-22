using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//fills the page with the list items from GlobalGameInfo
public class AddToList : MonoBehaviour
{

    public Transform todoPersonPrefab;
    public Transform listItemPrefab;
    public Transform infoListItemPrefab;
    public string whichList = "Dialog";

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

        // Added another element to test the todo list expanding feature. Only used for testing
        // list.Add(list[0]);

        // Destory placeholder saying no todo list
        Destroy(this.gameObject.transform.Find("Scroll View/Viewport/Content/No Info Yet").gameObject);
        Transform contentParent = this.gameObject.transform.Find("Scroll View/Viewport/Content");
        CharacterResources cr = new CharacterResources();

        for (int i = 0; i < list.Count; i++) {
            // Instantiate TodoPerson prefab
            Transform newTodoPerson = Instantiate(todoPersonPrefab, contentParent);

            // Update a person's header
            Transform header = newTodoPerson.Find("Header");
            header.gameObject.SetActive(true);
            Transform characterName = header.transform.Find("Character/CharacterName");
            Transform characterPic = header.transform.Find("Character/CharacterPic");
            Transform daysPassed = header.transform.Find("DaysPassed");
            characterPic.gameObject.GetComponent<Image>().sprite = cr.GetSmallIcon(list[i].character);
            characterName.gameObject.GetComponent<Text>().text = cr.GetName(list[i].character).ToUpper();

            // Create the todo item list;
            Transform newItemListParent = newTodoPerson.Find("TodoItemList");
            Transform newItem = Instantiate(listItemPrefab, newItemListParent);
            newItem.GetComponent<TodoManager>().setDetails(list[i]);

            // This was done for testing purposes. Remove in actual game
            /*
            Transform newItem2 = Instantiate(listItemPrefab, newItemListParent);
            newItem2.GetComponent<TodoManager>().setDetails(list[i]);
            */
            foreach (Transform child in daysPassed)
            {
                child.gameObject.GetComponent<Image>().color = cr.GetColor(list[i].character);
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
        
        if(list.Count == 0){
            return;
        }
        Destroy(this.gameObject.transform.Find("Scroll View/Viewport/Content/No Info Yet").gameObject);
        
        Transform content = this.gameObject.transform.Find("Scroll View/Viewport/Content");


        CharacterResources cr = new CharacterResources();

        // Assign the quest giver at the top (this should change depending on the week/quest?)
        // Im not actually sure if the top thing we want is the quest giver? i just put it as such for now
        Transform questIcon = this.gameObject.transform.Find("Scroll View/Viewport/Content/TopElements/WeekAndPersonHeader/PersonIcon");
        Transform questChar = this.gameObject.transform.Find("Scroll View/Viewport/Content/TopElements/WeekAndPersonHeader/PersonText");
        questIcon.gameObject.GetComponent<Image>().sprite = cr.GetSmallIcon(list[0].quest.questGiver);
        questChar.gameObject.GetComponent<Text>().text = cr.GetName(list[0].quest.questGiver).ToUpper();

        // Figure out which notes are associated with which days (we have headers based on days of the week)
        Dictionary<string, List<GlobalGameInfo.InfoItem>> dict = new Dictionary<string, List<GlobalGameInfo.InfoItem>>();
        for (int i = 0; i < list.Count; i++)
        {
            string day = getStringRep(list[i].day);
            if (!dict.ContainsKey(day))
            {
                dict.Add(day, new List<GlobalGameInfo.InfoItem>());
            }
            dict[day].Add(list[i]);
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
                Transform newItem = Instantiate(infoListItemPrefab, itemsList);
                newItem.GetComponent<InfoManager>().setDetails(character.Key, character.Value);
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
