using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

//this script grabs the InfoItems from GlobalGameInfo
//and then instantiates the journal prefabs from them
//it replaces the information in the prefabs with the saved info
public class TodoManager : MonoBehaviour
{
    public Transform itemPrefab;
    public CharacterResources cr;

    public Image dropdownArrow;
    public GameObject checklistItems;
    public GameObject dropdownImage;

    public Image backgroundImage;
    public Image checklistArrowImage;
    public Image checklistDoneImage;

    public static int backgroundImageDefaultHeight = 100;

    private GameObject profileImage;

    private Sprite greyDropdown;
    private Sprite redDropdown;
    private Sprite greenDropdown;
    private Sprite greenBackground;

    private bool completed;
    private bool opened;

    private RectTransform titleRTransform;

    List<GlobalGameInfo.ChecklistItem> checklist;

    private Transform checklistTransform = null;
    private Transform dropdownTransformArrow = null;
    private Transform dropdownTransformDone = null;


    void Awake(){
      cr = new CharacterResources();
      redDropdown = Resources.Load<Sprite>("dropdown_closed_red");
      greyDropdown = Resources.Load<Sprite>("dropdown_open");
      greenDropdown = Resources.Load<Sprite>("dropdown_closed_green");
      greenBackground = Resources.Load<Sprite>("greenbg");
    }
    public void setDetails(GlobalGameInfo.TodoItem item){
        if(cr == null){
            cr = new CharacterResources();
        }

        // Update checklist title
        string title = item.title;
        Transform textChild = HelperFunctions.FindChildByRecursion(transform, "title");
        if(textChild == null) return;
        titleRTransform = textChild.gameObject.GetComponent<RectTransform>();
        textChild.gameObject.GetComponent<TextMeshProUGUI>().text = title;

        // Add checklist items to checklist object 
        Transform go = HelperFunctions.FindChildByRecursion(transform, "checklist");
        checklistItems = go.gameObject;
        GridLayoutGroup glg = go.GetComponent<GridLayoutGroup>();
        checklist = item.checklist;
        for (int i = 0; i < checklist.Count; i++){
            Transform newItem = Instantiate(itemPrefab, go);
            newItem.GetComponent<ChecklistManager>().setItem(checklist[i]);
        }
        
        // If they are all completed already, update the arrow sprite to be the green checkmark
        completed = item.complete;
        if(completed){
            backgroundImage.sprite = greenBackground;
            dropdownImage.gameObject.GetComponent<Image>().sprite = greenDropdown;
        }

        // Should not be open by default
        checklistItems.SetActive(false);

        // Used for toggleChecklist
        checklistTransform = this.transform.Find("checklist");
        dropdownTransformArrow = this.transform.Find("Header/dropdown/dropdownArrow");
        dropdownTransformDone = this.transform.Find("Header/dropdown/dropdownDone");
    }

    public void toggleChecklist(){
        if (opened)
        {
            opened = false;
            checklistItems.SetActive(false);
        } 
        else 
        {
            opened = true;
            checklistItems.SetActive(true);
        }
    }

    public void Update()
    {
        // If all the checklist elements are checked, then give a green checkmark instead of the arrow
        if (checklistTransform != null && dropdownTransformArrow != null && dropdownTransformDone != null)
        {
            bool allChecked = true;
            foreach (Transform child in checklistTransform)
            {
                allChecked = allChecked && child.gameObject.GetComponent<ChecklistManager>().isChecked();
            }
            if (allChecked)
            {
                dropdownTransformArrow.gameObject.SetActive(false);
                dropdownTransformDone.gameObject.SetActive(true);
            }
            else
            {
                dropdownTransformDone.gameObject.SetActive(false);
                dropdownTransformArrow.gameObject.SetActive(true);
            }
        } 
    }
}
