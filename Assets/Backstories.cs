using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Backstories : MonoBehaviour

{
    private int current_text_counter = 1;
    public Text Textfield;
    public TextMeshProUGUI NextText;

    void Start()
    {
        Textfield.text = GameStrings.getString("backstories_1");
        NextText.text = GameStrings.getString("next");
    }


    public void setNextText() {
        switch (current_text_counter) {
            case 1:
                Textfield.text = GameStrings.getString("backstories_2");
                current_text_counter++;
                break;
            // case 2:
            // Textfield.text = GameStrings.getString("backstories_3");
            //     current_text_counter++;
            //     break;
            default:
                SceneManager.LoadScene("PCSetup");
                current_text_counter = 1;
                break;
        }
            
    }
    
}