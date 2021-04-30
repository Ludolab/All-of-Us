﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScript : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake() {
        if (GlobalGameInfo.getNewDayVariable()) {
            HintBubbleManager.ActivateHintBubble("Good Morning!", "It's a new day in Bloomwood!");
            GlobalGameInfo.toggleNewDay();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}