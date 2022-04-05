using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LockAspectRatio : MonoBehaviour
{

    private int lastWidth = 0;
    private int lastHeight = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var width = Screen.width;
        var height = Screen.height;

        if(lastWidth != width) // if the user is changing the width
        {
            // update the height
            var heightAccordingToWidth = width / 2048.0 * 1536.0;
            Screen.SetResolution(width, (int)((float)heightAccordingToWidth), false, 0);
        }
        else if(lastHeight != height) // if the user is changing the height
        {
            // update the width
            var widthAccordingToHeight = height / 1536.0 * 2048.0;
            Screen.SetResolution((int)((float)widthAccordingToHeight), height, false, 0);
        }

        lastWidth = width;
        lastHeight = height;
    }
}