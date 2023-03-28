using GameAware;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DictionaryEntryTracker : MetaDataTrackable
{

    private Text wordText;
    private Text defintionText;
    private RectTransform rectTransform;

    // Start is called before the first frame update
    override protected void Start() {
        wordText = transform.Find("WordHeader").GetComponent<Text>();
        defintionText = transform.Find("DefinitionText").GetComponent<Text>();
        rectTransform = GetComponent<RectTransform>();
        screenRectStyle = ScreenSpaceReference.Custom;
        objectKey = "dictionaryEntry";
        frameType = MetaDataFrameType.KeyFrame;
        base.Start();
    }

    public override DepthRect ScreenRect() {
        return GameAware.ScreenSpaceHelper.RectTransformToViewerScreenRect(rectTransform);
    }

    public override JObject KeyFrameData() {
        if (!gameObject.activeSelf) {
            return new JObject();
        }
        else {
            JObject ret = base.KeyFrameData();
            ret["word"] = wordText.text;
            ret["definition"] = defintionText.text;
            return ret;
        }
    }
}
