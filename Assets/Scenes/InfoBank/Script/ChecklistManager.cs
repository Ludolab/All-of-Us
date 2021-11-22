using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//this is attached to instantiated prefabs and
//will automatically update the UI components in the prefab
//if another script calls setText/setItem/setCheckmark, it will 
//modify the item accordingly
public class ChecklistManager : MonoBehaviour
{
    public Sprite checkedSprite;
    public Sprite uncheckedSprite;
    private bool checkmarked = false;
    public Image checkmark;

    GlobalGameInfo.ChecklistItem item;

    public void setItem(GlobalGameInfo.ChecklistItem ci){
        item = ci;
        setText(item.title);
        checkmarked = ci.completed;
    }

    public void setText(string text){
      Transform textChild = HelperFunctions.FindChildByRecursion(transform, "text");
      if(textChild == null) return;
      textChild.gameObject.GetComponent<TextMeshProUGUI>().text = text;
    }

    public bool isChecked()
    {
        return checkmarked;
    }

    public void toggleChecked()
    {
        Image imageObject = this.transform.GetComponentInChildren<Image>();
        if (checkmarked)
        {
            imageObject.sprite = uncheckedSprite;
        }
        else
        {
            imageObject.sprite = checkedSprite;
        }
        checkmarked = !checkmarked;
    }
}
