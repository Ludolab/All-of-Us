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

    private Transform overlayItem = null;

    private GlobalGameInfo.InfoItem infoItem;

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
      //Debug.Log(TagManager.GetTags(infoItem.tagIdentifier));

      if(infoItem == null){
        return;
      }
      /*
      if(TagManager.GetTags(infoItem.tagIdentifier).Count > 0){
        Transform redbubble = HelperFunctions.FindChildByRecursion(transform, "redbubble");
        if(redbubble != null){
          redbubble.gameObject.SetActive(false);
        }
      }
      */
    }

    public void setInfo(GlobalGameInfo.InfoItem item){
      infoItem = item;
      text = "Day " + item.day;
      Transform textChild = HelperFunctions.FindChildByRecursion(transform, "text");
      if(textChild == null) return;
      textChild.gameObject.GetComponent<TextMeshProUGUI>().text = text;

      description = item.description;
      Transform descriptionChild = HelperFunctions.FindChildByRecursion(transform, "description");
      if(descriptionChild == null) return;
      descriptionChild.gameObject.GetComponent<TextMeshProUGUI>().text = description;
      
        /*
      if(TagManager.GetTags(item.tagIdentifier).Count > 0){
        Transform redbubble = HelperFunctions.FindChildByRecursion(transform, "redbubble");
        redbubble.gameObject.SetActive(false);
      }
        */
    }

    public void setText(string txt){
      Transform textChild = HelperFunctions.FindChildByRecursion(transform, "text");
      if(textChild == null) return;
      textChild.gameObject.GetComponent<TextMeshProUGUI>().text = txt;
    }

    public void SelectItemForQuest() {
        if (SceneManager.GetActiveScene().name == "Quest Turnin Testing") {
          // highlight the item in the UI
          DeselectItemInUI();
          FindObjectOfType<PhoneScreenManager>().SelectQuestAnswer(questId,
              HelperFunctions.StringFromCharacter(character), description);
          GetComponent<Image>().color = new Color(246f / 255f, 224f / 255f, 148f / 255f, 1f);
          selectedItem = this;
          Debug.Log(GetComponent<Image>().color);
        }    
    }

    private static DetailPageManager selectedItem;
    private void DeselectItemInUI() {
        if (selectedItem == null)
            return;
        selectedItem.GetComponent<Image>().color = new Color(1, 1, 1, 1f / 255f);
        selectedItem = null;
    }
}
