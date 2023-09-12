using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAware;
using UnityEngine.UI;
using Newtonsoft.Json.Linq;
using InkFungus;
using Ink.Runtime;
using Newtonsoft.Json;
using System.Linq.Expressions;

public class VNDialogTracker : MetaDataTrackable
{

    private string lastPlayerChoice = string.Empty;
    private Text characterText;
    private Text storyText;
    private RectTransform rectTransform;
    private NarrativeDirector narrativeDirector;
    private JArray currentChoices = new JArray();
    private List<RectTransform> optionRects = new List<RectTransform>();

    // Start is called before the first frame update
    override protected void Start() {
        /*
         * This class should be placed on the VN SayDialog object in a visual novel scene so that the expected Transform structure exists underneath it.
         */
        storyText = transform.Find("Panel/StoryText").GetComponent<Text>();
        characterText = transform.Find("Panel/NameBackground/NameText").GetComponent<Text>();
        rectTransform = transform.Find("Panel/StoryText").GetComponent<RectTransform>();
        narrativeDirector = FindObjectOfType<NarrativeDirector>();
        narrativeDirector.story.onMakeChoice += Story_onMakeChoice;
        objectKey = "visualNovelText";
        frameType = MetaDataFrameType.Inbetween;
        screenRectStyle = ScreenSpaceReference.Custom;





        base.Start();


        /* Dialog options exist at:
         * Menu Dialogs/VN MenuDialog/ButtonGoup
         *  OptionButton0
         *  OptionButton0 (1)
         *  OptionButton0 (2) 
         */

    }

    private List<RectTransform> GetOptionRects() {
        GameObject dialogOptionsPanel = GameObject.Find("Menu Dialogs/VN MenuDialog/ButtonGroup");
        List<RectTransform> ret = new List<RectTransform>();
        foreach(Transform t in dialogOptionsPanel.transform) {
            if (t.name.StartsWith("Option")) {
                ret.Add(t.GetComponent<RectTransform>());
            }
        }
        return ret;
    }


    private void Story_onMakeChoice(Choice choice) {
        //Debug.Log(choice);
        //Debug.LogFormat("Choice Text:{0}", choice.text);
        lastPlayerChoice = choice.text;
    }

    public override DepthRect ScreenRect() {
        return ScreenSpaceHelper.RectTransformToViewerScreenRect(rectTransform);
    }

    private JArray GetChoices() {
        currentChoices.Clear();
        if(optionRects.Count == 0) {
            optionRects = GetOptionRects();
        }
        if(optionRects.Count == 0) {
            Debug.LogWarning("No Option Rects found.");
        }

        for(int i = 0; i < narrativeDirector.story.currentChoices.Count; i++) {
            Choice ch = narrativeDirector.story.currentChoices[i];
            RectTransform rect = optionRects[i];
            DepthRect screenRect = ScreenSpaceHelper.RectTransformToViewerScreenRect(rect);
            JObject choice = new JObject();
            choice["text"] = ch.text;
            choice["screenRect"] = screenRect.ToJObject();
            currentChoices.Add(choice);
        }
        return currentChoices;
        
    }

    private char[] spaceDelim = new char[] { ' ' };
    private char[] questionDelim = new char[] { '?' };
    private char[] trimChars = new char[] { '\n', '\"', '\\' };
    private string[] splitDialog;

    public override JObject InbetweenData() {
        JObject ret = base.InbetweenData();
        ret["dialogRendered"] = storyText.text;
        return ret;
    }

    public override JObject KeyFrameData() {
        JObject ret = base.KeyFrameData();
        try {
            splitDialog = narrativeDirector.story.currentText.Split(spaceDelim, 2);
            ret["dialogRendered"] = storyText.text;
            ret["dialogFull"] = splitDialog.Length > 1 ? splitDialog[1].Trim(trimChars) : string.Empty;
            if(splitDialog.Length > 1 && splitDialog[0].ToLower().StartsWith(characterText.text.ToLower())){
                ret["emotion"] = splitDialog.Length > 1 ? splitDialog[0].Split(questionDelim, 2)[1] : string.Empty;
            }
            ret["speaker"] = characterText.text;
            ret["currentChoices"] = GetChoices();
            ret["lastPlayerChoice"] = lastPlayerChoice;
        }
        catch (System.IndexOutOfRangeException e) {
            Debug.LogFormat("<color=red>Scene Transistion Bug</color> Current Text:{0}\nCurrent Tags:{1}", narrativeDirector.story.currentText, JsonConvert.SerializeObject(narrativeDirector.story.currentTags));
            throw e;
        }
        return ret;
    }

}
