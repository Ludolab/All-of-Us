using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public static class DataCollection : object {

    // Function to Log event type, event initiator and timestamp
    // into both Firebase cloud and local machine

    public static void LogEvent(string type, string initiator) {

        // // Creating the event to log
        // // LoggingEvent event = new LoggingEvent(type, initiator, DateTime.Now);
        // LoggingEvent evt = new LoggingEvent(type, initiator, DateTime.Now);

        // // Logging the event in the cloud
        // CloudHandler.WriteNewEvent(evt);

        // // Logging the event locally
        // LocalJsonDataController.WriteNewEvent(evt);
    }

}