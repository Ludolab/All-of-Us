using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideHomeUntilReady : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        if(InkFileManager.DailyQuestsCompleted < 3){
            gameObject.GetComponent<HighlightClickableBuildlings2DMap>().isViewable = false;
        } else {
            gameObject.GetComponent<HighlightClickableBuildlings2DMap>().isViewable = true;
        }
    }
}
