// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class CloudCaller : MonoBehaviour
// {

//     public CloudHandler cloudHandler;

//     void Start() {

//       Debug.Log("starting cloud handler");
//       cloudHandler = new CloudHandler();
//     }

//     //a test function to write something to the database
//     public void WriteTest(){
//       CloudHandler.WriteNewEvent("test type", "test initiator", DateTime.Now);
//     }

//     public void WriteTest2(){
      
//       LoggingEvent evt = new LoggingEvent("test type 2", "test intiator 2", DateTime.Now);
//       CloudHandler.WriteNewEvent(evt);
//     }
// }