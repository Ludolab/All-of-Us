using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseCantTalkPopup : MonoBehaviour
{
    public GameObject cantTalkDialog;
    // Start is called before the first frame update
    void Start()
    {
        cantTalkDialog.SetActive(false);
    }

}