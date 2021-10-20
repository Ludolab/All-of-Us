using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//fills the page with the list items from GlobalGameInfo
public class AddToList : MonoBehaviour
{

    public Transform listItemPrefab;
    public string whichList = "Dialog";

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
            default:
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
        
        Destroy(this.gameObject.transform.Find("Scroll View/Viewport/Content/No Info Yet").gameObject);
        
        Transform go = this.gameObject.transform.Find("Scroll View/Viewport/Content");
        
        for(int i = 0; i < list.Count; i++){
            Transform newItem = Instantiate(listItemPrefab, go);
            newItem.GetComponent<TodoManager>().setDetails(list[i]);
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

        Dictionary<string, List<GlobalGameInfo.InfoItem>> dict = new Dictionary<string, List<GlobalGameInfo.InfoItem>>();
        
        for(int i = 0; i < list.Count; i++){
            string character = list[i].character;
            if(!dict.ContainsKey(character)){
                dict.Add(character, new List<GlobalGameInfo.InfoItem>());
            }
            List<GlobalGameInfo.InfoItem> l = dict[character];
            l.Add(list[i]);
        }

        Transform go = this.gameObject.transform.Find("Scroll View/Viewport/Content");
        foreach( KeyValuePair<string, List<GlobalGameInfo.InfoItem>> elem in dict )
        {
            Transform newItem = Instantiate(listItemPrefab, go);
            newItem.GetComponent<InfoManager>().setDetails(elem.Key, elem.Value);
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
