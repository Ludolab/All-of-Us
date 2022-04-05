using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;


public class PCSetUpDropdowns : MonoBehaviour
{
    public Dropdown pronounsDropDown;
    public Dropdown languageDropDown;
    
    // Start is called before the first frame update
    void Start()
    {
        
        // Setting dropdown lists
        List<string> pronounsDropDownOptions = new List<string> { "", GameStrings.getString("she_her"), GameStrings.getString("he_his"), GameStrings.getString("they_them"), GameStrings.getString("other")};
        List<string> languageDropDownOptions = new List<string> { "", GameStrings.getString("english"), GameStrings.getString("spanish")};

        pronounsDropDown.AddOptions(pronounsDropDownOptions);
        languageDropDown.AddOptions(languageDropDownOptions);
    }
}
