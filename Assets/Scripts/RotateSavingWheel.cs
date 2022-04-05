using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class RotateSavingWheel : MonoBehaviour
{
    private float secondsPassed;
    // Start is called before the first frame update

    public TextMeshProUGUI SavingText;
    public GameObject blackOutSquare;
    private float fadeSpeed = 75.0f;
    
    void Start()
    {
        
        SavingText.text = GameStrings.getString("saving_progress");

        secondsPassed = 0.0f;

        StartCoroutine(RotateWheel());

    }

    IEnumerator RotateWheel()
    {

        while (true)
        {
            this.transform.Rotate(0.0f, 0.0f, -5f, Space.Self);
            yield return new WaitForSeconds(0.1f);
            if (secondsPassed > 3.0f)
            {
                break;
            }
            else
            {
                secondsPassed += 0.1f;
            }
        }

        StartCoroutine(FadeBlackOutSquare());

        Destroy (GameObject.FindGameObjectWithTag("Music"));
        // Navigate to the next scene
        if (GlobalGameInfo.gameEndedFlag == true) {
            GlobalGameInfo.gameEndedFlag = false;
            SceneManager.LoadScene("FinalScreen");
        } else {
            SceneManager.LoadScene("Map");
        }
    }

    public IEnumerator FadeBlackOutSquare() {
        Color objectColor = blackOutSquare.GetComponent<Image>().color;
        float fadeAmount;

        while (blackOutSquare.GetComponent<Image>().color.a < 1) {
            fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            blackOutSquare.GetComponent<Image>().color = objectColor;
            yield return null;
        }
    }
}
