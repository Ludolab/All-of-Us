using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomTurninOption : MonoBehaviour
{
    public GameObject optionContainer;
    public Text optionContainerText;
    public Sprite lightGreenButton;
    public Sprite lightBlueButton;
    public Sprite lightGreenHighlightButton;
    public Sprite lightBlueHighlightButton;
    public GameObject journalIcon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool on;
        if (optionContainerText.text == "Here’s what I have…") {
            toggleCustomDesign(on = true);
        } else {
            if (journalIcon.active) {
                toggleCustomDesign(on = false);
            }
        }
    }

    void toggleCustomDesign(bool on) {
        // Regular button
        optionContainer.GetComponent<Image>().sprite = on ? lightBlueButton : lightGreenButton; ;
        // Highlighted Button (onMouseOver)
        SpriteState spriteState = new SpriteState();
        spriteState.highlightedSprite = on ? lightBlueHighlightButton : lightGreenHighlightButton;
        optionContainer.GetComponent<Button>().spriteState = spriteState;
        // Journal icon
        journalIcon.SetActive(on);
    }
}
