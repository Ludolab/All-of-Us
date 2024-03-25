using GameAware;
using Ink;
using InkFungus;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TurninTracker : MetaDataTrackable
{

    public Text PromptText;
    public Text CharacterName;

    public List<TextMeshProUGUI> options = new List<TextMeshProUGUI>();

    JArray currentChoices = new JArray();

    protected override void Start()
    {
        base.Start();
        screenRectStyle = ScreenSpaceReference.Custom;
        objectKey = "visualNovelText";
    }
    public override DepthRect ScreenRect()
    {
        return ScreenSpaceHelper.RectTransformToViewerScreenRect(PromptText.rectTransform);
    }

    private JArray GetChoices() {
        currentChoices.Clear();

        for (int i = 0; i < options.Count; i++) {
            RectTransform rect = options[i].rectTransform;
            DepthRect screenRect = ScreenSpaceHelper.RectTransformToViewerScreenRect(rect);
            JObject choice = new JObject();
            choice["text"] = options[i].text;
            choice["screenRect"] = screenRect.ToJObject();
            currentChoices.Add(choice);
        }
        return currentChoices;

    }

    public override JObject KeyFrameData() {
        JObject ret = base.KeyFrameData();
        //try {
            //splitDialog = narrativeDirector.story.currentText.Split(spaceDelim, 2);

            //rendered and full both ceom from prompt
            ret["dialogRendered"] = PromptText.text;
            ret["dialogFull"] = PromptText.text;
            //if (splitDialog.Length > 1 && splitDialog[0].ToLower().StartsWith(characterText.text.ToLower())) {
            //    ret["emotion"] = splitDialog.Length > 1 ? splitDialog[0].Split(questionDelim, 2)[1] : string.Empty;
            //}
            ////speaker shoiuld be pulled from prompt name tag
            ret["speaker"] = CharacterName.text;

            //options available right now
            ret["currentChoices"] = GetChoices();
            //current selected choice
            //ret["lastPlayerChoice"] = lastPlayerChoice;
        //}
        //catch (System.IndexOutOfRangeException e) {
        //    Debug.LogFormat("<color=red>Scene Transistion Bug</color> Current Text:{0}\nCurrent Tags:{1}", narrativeDirector.story.currentText, JsonConvert.SerializeObject(narrativeDirector.story.currentTags));
        //    throw e;
        //}
        return ret;
    }
}
