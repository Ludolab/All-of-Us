using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideNPCsIfDone : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if(InkFileManager.CanAdvanceDay()){
            gameObject.GetComponent<HighlightClickableBuildlings2DMap>().isViewable = false;
        } else {
            gameObject.GetComponent<HighlightClickableBuildlings2DMap>().isViewable = true;
        }
    }
}
