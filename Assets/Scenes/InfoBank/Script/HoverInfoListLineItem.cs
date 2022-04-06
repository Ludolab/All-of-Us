using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;// Required when using Event data.
using UnityEngine.SceneManagement;

public class HoverInfoListLineItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler// required interface when using the OnPointerEnter method.
{
    public DetailPageManager dpm;
    //Do this when the cursor enters the rect area of this selectable UI object.
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (SceneManager.GetActiveScene().name == "Turnin")
        {
            MouseCursor.turnOnClickableObjectCursor(true);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (SceneManager.GetActiveScene().name == "Turnin")
        {
            MouseCursor.turnOnClickableObjectCursor(false);
            dpm.SelectItemForQuest();
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (SceneManager.GetActiveScene().name == "Turnin")
        {
            MouseCursor.turnOnClickableObjectCursor(false);
        }
    }
}
