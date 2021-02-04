using System;
using System.Collections.Generic;

public class LoggingEvent {
  private string type;
  private string initiator;
  private string timestamp;

  public LoggingEvent() {
  }

  public LoggingEvent(string type, string initiator, DateTime timestamp) {
      this.type = type;
      this.initiator = initiator;
      this.timestamp = timestamp.ToString("F");
  }

  public Dictionary<string, System.Object> ToDictionary() {
    Dictionary<string, System.Object> result = new Dictionary<string, System.Object>();
    result["type"] = type;
    result["initator"] = initiator;
    result["timestamp"] = timestamp;

    return result;
  }

  public string getTimestamp(){
    return timestamp;
  }

  public string getType(){
    return type;
  }

  public string getInitiator(){
    return initiator;
  }

  public void setTimestamp(string t){
    this.timestamp = t;
  }

  public void setTimestamp(DateTime dt){
    this.timestamp = dt.ToString("F");
  }

  public void setType(string t ){
    this.type = t;
  }

  public void setInitiator(string i){
    this.initiator = i;
  }
}