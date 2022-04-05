using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour

{

    private int current_text_counter = 1;
    public TextMeshProUGUI NextText;
    public Text Textfield;
    public Text LastTextField;
    public GameObject nextButton;
    public Image mrcalindas;
    public Image mrslee;
    public Image elisa;
    public Image lila;
    public Image rashad;

    private void Start() {

        Textfield.text = GameStrings.getString("ending_1");
        NextText.text = GameStrings.getString("next");

        mrcalindas.enabled = false;
        mrslee.enabled = false;
        elisa.enabled = false;
        lila.enabled = false;
        rashad.enabled = false;

        LastTextField.enabled = false;
    }
    public void setNextText() {
        switch (current_text_counter) {
            case 1:
                Textfield.text = GameStrings.getString("ending_2");
                current_text_counter++;
                break;
            case 2:
                mrcalindas.enabled = true;
                StartCoroutine(FadeImage(mrcalindas, false));
                Textfield.text = GameStrings.getString("ending_3");
                current_text_counter++;
                break;
            case 3:
                StartCoroutine(FadeImage(mrcalindas, true));
                Textfield.text = GameStrings.getString("ending_4");
                current_text_counter++;
                lila.enabled = true;
                StartCoroutine(FadeImage(lila, false));
                break;
            case 4:
                StartCoroutine(FadeImage(lila, true));
                Textfield.text = GameStrings.getString("ending_5");
                current_text_counter++;
                rashad.enabled = true;
                StartCoroutine(FadeImage(rashad, false));
                break;
            case 5:
                StartCoroutine(FadeImage(rashad, true));
                Textfield.text = GameStrings.getString("ending_6");
                current_text_counter++;
                mrslee.enabled = true;
                StartCoroutine(FadeImage(mrslee, false));
                break;
            case 6:
                StartCoroutine(FadeImage(mrslee, true));
                Textfield.text = GameStrings.getString("ending_7");
                current_text_counter++;
                elisa.enabled = true;
                StartCoroutine(FadeImage(elisa, false));
                break;
            case 7:
                StartCoroutine(FadeImage(elisa, true));
                Textfield.text = GameStrings.getString("ending_8");
                current_text_counter++;
                break;
            case 8:
                Textfield.enabled = false;
                current_text_counter++;
                LastTextField.text = GameStrings.getString("ending_9");
                LastTextField.enabled = true;
                break;
            default:
                current_text_counter = 1;
                SceneManager.LoadScene("FinalScreen");
                break;
        }
    }

    IEnumerator FadeImage(Image img, bool fadeAway)
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                img.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
        // fade from transparent to opaque
        else
        {
            // loop over 1 second
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                img.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
    }
}
