// using System.Collections;
// using System;
// using System.Collections.Generic;
// using UnityEngine;
// using Firebase;
// using Firebase.Database;
// using Firebase.Extensions;

// public class CloudHandler
// {

//     protected static bool isFirebaseInitialized = false;
//     protected static bool initializationStarted = false;
//     protected static DatabaseReference reference;
//     protected static DependencyStatus dependencyStatus = DependencyStatus.UnavailableOther;
//     protected static ArrayList eventsToWrite;
    
//     // Initialize the Firebase database
//     protected static void Init() {

//       Debug.Log("Initializing Firebase");

//       if(initializationStarted) return;
      
//       initializationStarted = true;

//       // When the app starts, check to make sure that we have
//       // the required dependencies to use Firebase, and if not,
//       // add them if possible.
//       FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task => {
//         dependencyStatus = task.Result;

//         if (dependencyStatus == DependencyStatus.Available) {
//           FirebaseApp app = FirebaseApp.DefaultInstance;
//           isFirebaseInitialized = true;
//           reference = FirebaseDatabase.DefaultInstance.GetReference("Data");

//           while(eventsToWrite.Count > 0){
//             LoggingEvent e = (LoggingEvent)eventsToWrite[0];
//             eventsToWrite.Remove(e);
//             WriteNewEvent(e);
//           }

//         } else {
//           Debug.LogError(
//             "Could not resolve all Firebase dependencies: " + dependencyStatus);
//         }
//       });
//     }

//     //a function to write a new event to the database
//     public static void WriteNewEvent(string type, string initiator, DateTime timestamp) {      
//       LoggingEvent entry = new LoggingEvent(type, initiator, timestamp);
//       WriteNewEvent(entry);
//     }


//     public static void WriteNewEvent(LoggingEvent evt) {

//       //if the firebase app isn't initialized and we haven't started initializing it
//       if(!initializationStarted || !isFirebaseInitialized){
//         Debug.Log("Database not initialized yet. We will store this event and start setting up the firebase app asyncronously. The event will be added once the app is read.");
//         if(eventsToWrite == null){
//           eventsToWrite = new ArrayList();
//         }
//         eventsToWrite.Add(evt);
//         Init();
//         return;
//       } 
//       //if firebase is async setting up but not done, we might need to log another
//       //event so we just add that to the list of things to write afterwards
//       else if(initializationStarted && !isFirebaseInitialized){
//         if(eventsToWrite == null){
//           eventsToWrite = new ArrayList();
//         }
//         eventsToWrite.Add(evt);
//       }

//       Debug.Log("Writing to database: TYPE " + evt.getType() + ", INITATOR: " + evt.getInitiator() + ", TIME: " + evt.getTimestamp());

//       string key = reference.Push().Key;

//       Dictionary<string, System.Object> entryValues = evt.ToDictionary();
//       Dictionary<string, System.Object> childUpdates = new Dictionary<string, System.Object>();
//       childUpdates["/" + key] = entryValues;

//       reference.UpdateChildrenAsync(childUpdates);
//     }
// }