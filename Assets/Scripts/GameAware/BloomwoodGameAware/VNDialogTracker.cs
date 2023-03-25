using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAware;
using UnityEngine.UI;
using Newtonsoft.Json.Linq;

public class VNDialogTracker : MetaDataTrackable
{


    private Text characterText;
    private Text storyText;
    private RectTransform rectTransform;


    // Start is called before the first frame update
    override protected void Start() {
        /*
         * This class should be placed on the VN SayDialog object in a visual novel scene so that the expected Transform structure exists underneath it.
         */ 
        storyText = transform.Find("Panel/StoryText").GetComponent<Text>();
        characterText = transform.Find("Panel/NameBackground/NameText").GetComponent<Text>();
        rectTransform = transform.Find("Panel").GetComponent<RectTransform>();
        objectKey = "visualNovelText";
        frameType = MetaDataFrameType.KeyFrame;
        base.Start();

    }

    public override JObject KeyFrameData() {
        JObject ret = new JObject();
        ret[Constants.SCREEN_RECT_KEY] = ScreenSpaceHelper.RectTransformToViewerScreenRect(rectTransform).ToJObject();
        ret["dialog"] = storyText.text;
        ret["speaker"] = characterText.text;
        return ret;
    }

}
