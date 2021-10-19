using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;// Required when using Event data.

public class HoverClickableObjects : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler// required interface when using the OnPointerEnter method.
{
    //Do this when the cursor enters the rect area of this selectable UI object.
    public void OnPointerEnter(PointerEventData eventData)
    {
        MouseCursor.turnOnClickableObjectCursor(true);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        MouseCursor.turnOnClickableObjectCursor(false);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        MouseCursor.turnOnClickableObjectCursor(false);
    }
}
