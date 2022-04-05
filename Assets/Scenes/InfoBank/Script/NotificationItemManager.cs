using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/* this can be attached to prefabs that you want
 * to have a "notification" on
 * it attaches itself to the notification event
 * that GlobalGameInfo controls
 * and then when the journal updates, this gets called
 * as a callback, and then it will update the text to
 * the number of notifications, and also turn the bubble on
 */
public class NotificationItemManager : MonoBehaviour
{
    public TextMeshProUGUI text;
    public TextMeshProUGUI updatedText;
    public GameObject updatedTextGameObject;
    public GameObject bubble;

    public GlobalGameInfo.NOTIFICATION notificationType;

    public static GlobalGameInfo.NOTIFICATION lastNotificationType;

    void Start(){

      

      GlobalGameInfo.setNotificationDelegate(setCounter);
      updateUIElements();
    }

    void OnDestroy(){
      GlobalGameInfo.clearNotificationDelegate();
      lastNotificationType = GlobalGameInfo.NOTIFICATION.NONE;
    }
    public void setCounter(GlobalGameInfo.NOTIFICATION n){
      
      lastNotificationType = n;
      updateUIElements();
    }

    public void updateUIElements(){
      if(notificationType == GlobalGameInfo.NOTIFICATION.PHONE){

        if (lastNotificationType == GlobalGameInfo.NOTIFICATION.NONE){
          updatedTextGameObject.SetActive(false);
        } else {
          updatedTextGameObject.SetActive(true);
        }

        if(lastNotificationType == GlobalGameInfo.NOTIFICATION.INFO){
          updatedText.text = GameStrings.getString("journal_updated");
        } else if (lastNotificationType == GlobalGameInfo.NOTIFICATION.TODO){
          updatedText.text = GameStrings.getString("todo_updated");
        }   
      }
      
      int untagged = GlobalGameInfo.getNotificationNumber(notificationType);
      
      if(untagged == 0){
        if(bubble != null){
          bubble.SetActive(false);
        }
      } else {
        if(bubble != null){
          bubble.SetActive(true);
        }
        // This for a change where the numbers aren't supposed to show.
        // To redisplay numbers, just set the text to the value of untagged and renable
        text.gameObject.SetActive(false);
      }
    }
}
