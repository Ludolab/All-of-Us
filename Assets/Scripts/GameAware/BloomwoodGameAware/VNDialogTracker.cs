using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAware;
using UnityEngine.UI;
using Newtonsoft.Json.Linq;
using InkFungus;
using Ink.Runtime;

public class VNDialogTracker : MetaDataTrackable
{

    private string lastPlayerChoice = string.Empty;
    private Text characterText;
    private Text storyText;
    private RectTransform rectTransform;
    private NarrativeDirector narrativeDirector;
    private JArray currentChoices = new JArray();

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
        foreach(Choice ch in narrativeDirector.story.currentChoices) {
            currentChoices.Add(ch.text);
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
        splitDialog = narrativeDirector.story.currentText.Split(spaceDelim, 2);
        ret["dialogRendered"] = storyText.text;
        ret["dialogFull"] = splitDialog.Length > 1 ? splitDialog[1].Trim(trimChars) : string.Empty;
        ret["emotion"] = splitDialog.Length > 1 ? splitDialog[0].Split(questionDelim, 2)[1] : string.Empty;
        ret["speaker"] = characterText.text;
        ret["currentChoices"] = GetChoices();
        ret["lastPlayerChoice"] = lastPlayerChoice;
        return ret;
    }

}
