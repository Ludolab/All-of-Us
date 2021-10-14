using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.

public class HighlightClickableBuildlings2DMap : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler// required interface when using the OnPointerEnter method.
{
    public List<GameObject> characters;
    public GameObject hoverItem;
    public GameObject clickItem;
    public GameObject imageItem;
    public GameObject blackOverlay;
 
    private Sprite oldSprite;
    private int imageItemOldSiblingIndex;

    //other scrips can change this
    public bool isViewable = true;
    private bool hovering = false;
    private Vector3 oldScale;


    private void AnimateScale(Vector3 endScale)
    {
        imageItem.transform.localScale = endScale;
    }

    private bool canTalkToAtLeastOneCharacter()
    {
        // Check how many characters are clickable
        for (int i = 0; i < characters.Count; i++)
        {
            GameObject character = characters[i];
            CharacterResources.CHARACTERS characterID = HelperFunctions.CharacterFromString(character.name);
            if (InkFileManager.CanSpeakToForCurrentQuestOrNewQuest(characterID))
            {
                return true;
            }
        }
        return false;
    }

    //Do this when the cursor enters the rect area of this selectable UI object and the building has characters you can talk to
    public void OnPointerEnter(PointerEventData eventData)
    {
        if(hoverItem != null && isViewable && canTalkToAtLeastOneCharacter() && !hovering){
            MouseCursor.turnOnClickableObjectCursor(true);
            hoverItem.SetActive(true);
            hovering = true;
            oldScale = imageItem.transform.localScale;
            float newX = oldScale.x * 1.1f;
            float newY = oldScale.y * 1.1f;
            Vector3 endScale = new Vector3(newX, newY, oldScale.z);
            AnimateScale(endScale);

            imageItemOldSiblingIndex = imageItem.transform.GetSiblingIndex();
            imageItem.transform.SetAsLastSibling();
            if (blackOverlay != null)
            {
                blackOverlay.SetActive(true);
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(hoverItem != null && canTalkToAtLeastOneCharacter())
        {
            hoverItem.SetActive(false);
        }
        if(clickItem != null && isViewable && canTalkToAtLeastOneCharacter())
        {
            clickItem.SetActive(true);
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if(hoverItem != null && hovering){
            MouseCursor.turnOnClickableObjectCursor(false);
            AnimateScale(oldScale);
            hovering = false;
            hoverItem.SetActive(false);
            imageItem.transform.SetSiblingIndex(imageItemOldSiblingIndex);
            if (blackOverlay != null)
            {
                blackOverlay.SetActive(false);
            }
            if (clickItem != null)
            {
                clickItem.SetActive(false);
            }
        }
        
    }
}