using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

//this is attached to instantiated prefabs and
//will automatically update the "text" and "description" fields
//if another script calls setText or setDescription
//used for smaller prefabs where i need to replace the text
//is only used for the journal
public class DetailPageManager : MonoBehaviour
{
    public static List<string> changedTags = null;
    public Transform detailPagePrefab;
    public Transform tagItemPrefab;
    private string text = "Failed to load";
    private string description = "Failed to load";
    private static Transform lastItem = null;
    private static GlobalGameInfo.InfoItem openedInfoItem;

    private Color defaultColor = new Color(0.1960f, 0.1960f, 0.196f);
    private Color selectedColor = Color.blue;
    private static DetailPageManager selectedItem = null;
    private Transform overlayItem = null;

    private GlobalGameInfo.InfoItem infoItem;
    private string turninSceneName = "Quest Turnin Testing";
    public int optionNumber = 0;
    [HideInInspector]
    public string questId = "";
    [HideInInspector]
    public CharacterResources.CHARACTERS character;

    void Start(){
      TagManager.setCustomDelegate(updateDetailPage);
      TagManager.setDelegate(updateBubble);
      DeselectItemInUI();
    }

    private void OnDestroy() {
      TagManager.removeCustomDelegate(updateDetailPage);
      TagManager.removeDelegate(updateBubble);
    }

    public static void addToChangedTagsList(string s){
      if(changedTags == null){
        changedTags = new List<string>();
      }
      changedTags.Add(s);
    }

    public static void removeFromChangedTagsList(string s){
      if(changedTags == null){
        return;
      }
      changedTags.Remove(s);
    }

    //if they click outside of the overlay without saving
    public static void clearChangedTagsList(){
      changedTags = null;
    }

    //if they save
    public static void updateLastOverlayItemWithTagsList(){
      Debug.Log("update changed tags list");
      if(changedTags == null) return;
      List<string> tags = TagManager.GetTags(openedInfoItem.tagIdentifier);

      foreach(string s in changedTags){
        if(tags.Contains(s)){
          TagManager.RemoveTagAndInfo(s, openedInfoItem.tagIdentifier);
        } else {
          TagManager.AddTagAndInfo(s, openedInfoItem.tagIdentifier);
        }
        
      }
      changedTags = null;
    }

    public void openDetailPage(){
      if(detailPagePrefab != null){
        openedInfoItem = infoItem;
        GameObject phone = GameObject.Find("Canvas");
        Transform newItem = Instantiate(detailPagePrefab, phone.transform);
        if(lastItem != null){
          Destroy(lastItem.gameObject);
        }
        lastItem = newItem;
        overlayItem = newItem;
        Transform txt = HelperFunctions.FindChildByRecursion(newItem, "text");
        Transform des = HelperFunctions.FindChildByRecursion(newItem, "description");

        if(txt != null){
          txt.gameObject.GetComponent<TextMeshProUGUI>().text = infoItem.character + " | Day " + infoItem.day;
        }
        if(des != null){
          des.gameObject.GetComponent<TextMeshProUGUI>().text = description;
        }
        UpdateTagsList(newItem);
      }
    }

    public void UpdateTagsList(Transform item){
      Debug.Log("updating the overlay's tag list");
      
      Transform go = HelperFunctions.FindChildByRecursion(item, "Content");
      foreach (Transform child in go) {
        GameObject.Destroy(child.gameObject);
      }
      List<string> allTags = TagManager.defaultTags;
      foreach(string tag in allTags){
        GameObject newTagListItem = Instantiate(tagItemPrefab, go).gameObject;
        newTagListItem.GetComponent<TagItem>().setText(tag, infoItem.tagIdentifier);
      }

      List<string> cTags = TagManager.customTags;
      foreach(string tag in cTags){
        GameObject newTagListItem = Instantiate(tagItemPrefab, go).gameObject;
        newTagListItem.GetComponent<TagItem>().setText(tag, infoItem.tagIdentifier);
      }
    }

    public void updateDetailPage(){
      if(overlayItem == null || tagItemPrefab == null){
        return;
      } 
      UpdateTagsList(overlayItem.transform);
    }

    public void updateBubble(){
      Debug.Log(text);
      Debug.Log(infoItem);

      if(infoItem == null){
        return;
      }
    }

    public void setInfo(GlobalGameInfo.InfoItem item){
      infoItem = item;
      text = "Day " + item.day;
      description = item.description;
      
      // It seems like that for wrong answers, quest will be null. For correct quest answers, quest will be nonnull.
      // Thus, only update the questId if item.quest is nonnull, as then it will be a correct answer
      if (item.quest != null)
      {
            questId = item.quest.questId;
            optionNumber = item.quest.optionNumber;
      }
      
    }

    public void setText(string txt){
      Transform textChild = HelperFunctions.FindChildByRecursion(transform, "text");
      if(textChild == null) return;
      textChild.gameObject.GetComponent<TextMeshProUGUI>().text = txt;
    }

    public void SelectItemForQuest() {
        if (SceneManager.GetActiveScene().name == turninSceneName) {
            FindObjectOfType<PhoneScreenManager>().SelectQuestAnswer(questId,
              HelperFunctions.StringFromCharacter(infoItem.characterEnum), description, optionNumber);

            // Set the text to be red
            if (selectedItem != null)
            {
                selectedItem.transform.Find("Content/Text").GetComponent<Text>().color = defaultColor;
            }
            selectedItem = this;
            this.transform.Find("Content/Text").GetComponent<Text>().color = selectedColor;
        }    
    }

    
    private void DeselectItemInUI() {
        if (selectedItem == null)
            return;
        selectedItem.GetComponent<Image>().color = new Color(1, 1, 1, 1f / 255f);
        selectedItem = null;
    }
}
