// using System;
// using System.Collections;
// using System.Collections.Generic;
// using System.Threading.Tasks;
// using NUnit.Framework;
// using UnityEngine;
// using UnityEngine.TestTools;
// using Firebase;
// using Firebase.Database;
// using System.Linq;

// namespace Tests
// {
//     public class CloudTests
//     {
        
//         // A Test behaves as an ordinary method
//         [Test]
//         public void CloudTestsSimplePasses()
//         {
//             // Use the Assert class to test conditions
//         }

//         // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
//         // `yield return null;` to skip a frame.
//         [UnityTest]
//         public IEnumerator CloudTestsWithEnumeratorPasses()
//         {
//             // Use the Assert class to test conditions.
//             // Use yield to skip a frame.
//             yield return null;
//         }

//         [UnityTest]
//         public IEnumerator AsyncTestWriteNewEvent()
//         {
//             bool didFail = false;
//             bool isAccessing = true;
//             string errorMsg = "";
//             DataSnapshot newChild = null;

//             // Write to cloud
//             CloudHandler.WriteNewEvent("test type", "test initiator", DateTime.Now);

//             // Read from cloud to check if data was written
//             FirebaseDatabase.DefaultInstance.GetReference("Data")
//                 .GetValueAsync().ContinueWith(task => {
//                     if (task.IsFaulted) {
//                         // upload failed
//                         // Assert.Fail("Unable to read from firebase.\n Check and delete any new dummy events.");
//                         didFail = true;
//                         errorMsg = "Unable to read from firebase.\n Check and delete any new dummy events.";
//                     } else if (task.IsCompleted) {
//                         // upload succeeded, double check to make sure that the
//                         // newest element in Data is the one we just made 
//                         // (e.g. has a timestamp that was made in the last
//                         // two minutes. O(n) b/c idk how to index into enumerables
//                         DataSnapshot snapshot = task.Result;
//                         DataSnapshot[] children = snapshot.Children.ToArray();
//                         newChild = children[children.Length - 1];

//                         Dictionary<string, object> childData = (Dictionary<string, object>)newChild.Value;
//                         DateTime timestamp = DateTime.Parse(childData["timestamp"].ToString());

//                         TimeSpan deltaTime = DateTime.Now.Subtract(timestamp);
//                         TimeSpan compareTime = new TimeSpan(0, 2, 0);

//                         if (deltaTime > compareTime) {
//                             didFail = true;
//                             errorMsg = "Most recent element too old. Probably means couldn't write new event.";
//                             // Assert.Fail(); asserts have weird behavior in these async statements idk
//                         }
//                     }
//                     isAccessing = false;
//                 });
//             // need to wait because Asserts are dumb so we need to wait for didFail
//             while (isAccessing)
//                 yield return null;

//             Assert.IsFalse(didFail, errorMsg);
//             // Clean up by deleting last entry
//             FirebaseDatabase.DefaultInstance.GetReference("Data")
//                 .Child(newChild.Key).RemoveValueAsync();

//             yield return null;
//         }
//     }
// }
