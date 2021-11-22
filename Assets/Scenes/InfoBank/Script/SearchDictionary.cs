using System.Collections;
using System.Globalization;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif
using TMPro;

public class SearchDictionary : MonoBehaviour
{
    // True if this is for a visual novel dictionary, false if for the info bank dictionary
    public bool visualNovelDictionary;
    public DisplayDictionaryDefinition definitionsManager;
    public GameObject dictionaryTermPrefab;
    public Scrollbar verticalScrollbar;
    public GameObject dictionaryTermsObject;
    public GameObject contentObject;


    private List<GameObject> allTerms;
    private List<GameObject> displayedTerms;
    private int cellHeight;
    private int cellHeightSpacing;
    private int topPadding;
    private int bottomPadding;
    // Start is called before the first frame update
    void Start()
    {
        allTerms = new List<GameObject>();
        displayedTerms = new List<GameObject>();
        populateTerms();
    }

    private void populateTerms()
    {
        
        int numWords = definitionsManager.GetNumWords();
        List<string> words = definitionsManager.GetWords();
        GridLayoutGroup glg = contentObject.GetComponent<GridLayoutGroup>();
        topPadding = glg.padding.top;
        bottomPadding = glg.padding.bottom;
        cellHeight = (int)glg.cellSize.y;
        cellHeightSpacing = (int)glg.spacing.y;
        RectTransform rt = contentObject.GetComponent<RectTransform>();
        float contentWindowHeight = (float)(numWords * (cellHeight + cellHeightSpacing) + topPadding + bottomPadding);
        rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, contentWindowHeight);
        for (int i = 0; i < numWords; i++)
        {
            GameObject newObject = Instantiate(dictionaryTermPrefab, contentObject.transform);
            TextMeshProUGUI newText = newObject.GetComponentInChildren<TextMeshProUGUI>();
            newText.text = words[i];
            allTerms.Add(newObject);
            displayedTerms.Add(newObject);
            // newText.font = (Font)AssetDatabase.LoadAssetAtPath("Assets/Fonts/Lato-Regular.ttf", typeof(Font));
        }
        // This is to fix a bug where it believed the content object was not turned on
        contentObject.SetActive(true);
        Debug.Log(numWords);
    }

    private GameObject getHighlightImageObject(GameObject go)
    {
        Image[] imageObjs = go.GetComponentsInChildren<Image>(true);
        foreach (Image img in imageObjs)
        {
            if (img.gameObject.name == "HighlightImage")
            {
                return img.gameObject;
            }
        }
        return null;
    }

    private GameObject getSelectedImageObject(GameObject go)
    {
        Image[] imageObjs = go.GetComponentsInChildren<Image>(true);
        foreach (Image img in imageObjs)
        {
            if (img.gameObject.name == "SelectedImage")
            {
                return img.gameObject;
            }
        }
        return null;
    }

    private void clearAllHighlights()
    {
        foreach(GameObject go in allTerms)
        {
            getHighlightImageObject(go).SetActive(false);
        }
    }

    private void clearSelected()
    {
        foreach (GameObject go in allTerms)
        {
            getSelectedImageObject(go).SetActive(false);
        }
    }
    public void searchForTerms(string searchWord)
    {
        dictionaryTermsObject.SetActive(true);
        List<GameObject> newDisplayedTerms = new List<GameObject>(); 
        foreach (GameObject go in allTerms) 
        {
            // If the search word is clear, just add every word
            if (searchWord == "")
            {
                newDisplayedTerms.Add(go);
                go.SetActive(true);
            }
            // Otherwise, we have to see if part of the word matches the search word
            else
            {
                TextMeshProUGUI textComponent = go.GetComponentInChildren<TextMeshProUGUI>();
                string word = textComponent.text;
                int wordInd = 0;
                int searchInd = 0;
                while (wordInd < word.Length)
                {
                    if (Char.ToLower(word[wordInd]) == Char.ToLower(searchWord[searchInd]))
                    {
                        searchInd++;
                        if (searchInd == searchWord.Length)
                        {
                            newDisplayedTerms.Add(go);
                            go.SetActive(true);
                           

                            GameObject img = getHighlightImageObject(go);
                            if (img != null)
                            {
                                int startInd = wordInd - searchWord.Length + 1;
                                float startX = textComponent.textInfo.characterInfo[startInd].bottomLeft.x;
                                float endX = textComponent.textInfo.characterInfo[wordInd].bottomRight.x;
                                float highlightImageWidth = endX - startX;
                                // Offset is because text object is sligtly shifted in parent
                                float newStartX = startX + textComponent.transform.localPosition.x;
                                img.transform.localPosition = new Vector3(newStartX, img.transform.localPosition.y, img.transform.localPosition.z);
                                RectTransform imgrt = img.GetComponentInChildren<RectTransform>();
                                imgrt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, highlightImageWidth);
                                img.SetActive(true);
                            }
                            // Highlight part of word
                            break;
                        }
                    }
                    else
                    {
                        searchInd = 0;
                    }
                    wordInd++;
                }
                if (wordInd == word.Length)
                {
                    go.SetActive(false);
                }
            }
        }
        displayedTerms = newDisplayedTerms;
        // Search bar is clear
        if (searchWord == "")
        {
            // Remove all yellow highlights from word and scroll up to top of scroll window
            clearAllHighlights();
            verticalScrollbar.value = 1;
            if (definitionsManager.GetDisplayStatus() != DisplayDictionaryDefinition.DisplayStatus.DEFINITION)
            {
                definitionsManager.ClearDescription();
            }
            if (SelectDictionaryTerm.GetSelectedTerm() == null)
            {
                clearSelected();
            }
            if (visualNovelDictionary)
            {
                dictionaryTermsObject.SetActive(false);
                DisplayDictionaryDefinition.UpdateDefinition("");
            }
        }
        // Search bar is not clear and no results for search
        else if (displayedTerms.Count == 0)
        {
            // Reset it to the top of the window
            clearAllHighlights();
            verticalScrollbar.value = 1;
            definitionsManager.WordNotFound(searchWord);
            // For visual novel, if there are no results, turn off the search dictionary terms field
            if (visualNovelDictionary)
            {
                dictionaryTermsObject.SetActive(false);
                // String is just a placeholder
                DisplayDictionaryDefinition.UpdateDefinition(searchWord);
            }
        }
        // Neither of two cases above, and is visual novel dictionary, then we want to just show the search terms, and disable
        // the definitions page
        else if (visualNovelDictionary)
        {
            DisplayDictionaryDefinition.UpdateDefinition("");
        }
        // Update content window height, so scrollbar will disappear if not enough elements
        RectTransform rt = contentObject.GetComponent<RectTransform>();
        float contentWindowHeight = (float)(displayedTerms.Count * (cellHeight + cellHeightSpacing) + topPadding + bottomPadding);
        rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, contentWindowHeight);
    }

}
