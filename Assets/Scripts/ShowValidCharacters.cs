using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class ShowValidCharacters : MonoBehaviour
{
    public List<GameObject> characters;
    public GameObject imageObject;
    public Sprite singleBubble;
    public int singleNPCXposition;

    private void Start()
    {
        Image imageComponent = imageObject.GetComponent<Image>();
        imageComponent.SetNativeSize();
    }

    private void OnEnable()
    {
        int clickableCharacters = 0;
        GameObject clickableCharacter = null;
        // Check how many characters are clickable
        for (int i = 0; i < characters.Count; i++)
        {
            GameObject character = characters[i];
            CharacterResources.CHARACTERS characterID = HelperFunctions.CharacterFromString(character.name);
            if (InkFileManager.CanSpeakToForCurrentQuestOrNewQuest(characterID))
            {
                character.SetActive(true);
                clickableCharacters++;
                clickableCharacter = character;
            }
            else
            {
                character.SetActive(false);
            }
        }
        // Adjust sole bubble to be in the middle
        
        // POSSIBLE ERROR: Not sure about this, but if we leave this scene and then come back, will this x position still be adjusted?
        // or when the scene is opened again, all the positions are updated to be the default? If its updated to be the default, this is okay, but
        // otherwise this could be a bug where the second day you click the buildling, one of the icons of the people is in the wrong place.
        if (clickableCharacters == 1)
        {
            Vector3 oldPosition = clickableCharacter.transform.localPosition;
            Vector3 newPosition = new Vector3(singleNPCXposition, oldPosition.y, oldPosition.z);
            clickableCharacter.transform.localPosition = newPosition;
            // If the buildling had two people, now use the single bubble
            Image imageComponent = imageObject.GetComponent<Image>();
            if (imageComponent != null)
            {
                imageComponent.sprite = singleBubble;
                imageComponent.SetNativeSize();
            }
        }
    }
}
