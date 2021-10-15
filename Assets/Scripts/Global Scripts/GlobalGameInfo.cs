using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Stores static game info for the infobank
public class GlobalGameInfo
{
    // CURRENT DAY (0 to 4)
    // 0 is Monday and 4 is Friday - Block Party day
    private static int currentDay = 0;
    // CURRENT WEEK (0 to 4)
    private static int currentWeek = 0;
    // CURRENT NPC FOR THE WEEK (the name as string)
    private static string currentNPC = "Example NPC";

    // CURRENT TASK FOR THE DAY (as string)
    private static string currentTask = "Example current task";
    // player's name
    public static string name = "";
    // player's pronouns
    public static string pronouns;
    public static int pronounsInt = 0;
    // Game's language
    public static string language = "English";
    public static int languageInt = 0;

    // engagement level
    private static readonly int MAX_ENGAGEMENT = 20;
    private static int engagement = 0;

    //an enum for notifications
    public enum NOTIFICATION {
        INFO,
        TODO,
        PHONE,
        NONE
    };

    private static bool newDay = false;

    //callbacks for when info items and quests get added so the 
    //phone and app get red notification bubbles
    public delegate void UpdateNotifications(NOTIFICATION noficationType);
    public static UpdateNotifications updateNotifications;

    public static void toggleNewDay() {
        newDay = !newDay;
    }

    public static bool getNewDayVariable() {
        return newDay;
    }

    public static void setNotificationDelegate(UpdateNotifications n) {
        if (updateNotifications != null) {
            updateNotifications += n;
        } else {
            updateNotifications = n;
        }

    }

    public static void clearNotificationDelegate() {
        updateNotifications = null;
    }

    public static void decreaseUntaggedInfoObjects() {
        untaggedInfoObjects--;
        if (updateNotifications != null) {
            updateNotifications(NOTIFICATION.INFO);
        }
    }

    public static void decreaseUntaggedTodoObjects() {
        untaggedTodoObjects--;
        if (updateNotifications != null) {
            updateNotifications(NOTIFICATION.TODO);
        }
    }

    public static void notificationCallback(NOTIFICATION n) {
        if (updateNotifications != null) {
            updateNotifications(n);
        }
    }

    public static int getNotificationNumber(NOTIFICATION n) {
        switch (n) {
            case NOTIFICATION.INFO:
                return untaggedInfoObjects;
            case NOTIFICATION.TODO:
                return untaggedTodoObjects;
            default:
                return untaggedInfoObjects + untaggedTodoObjects;
        }
    }

    //CLASSES FOR PHONE ITEMS - TODOs, INFORMATION, CONTACTs
    public class TodoItem
    {
        public string title;
        public List<ChecklistItem> checklist;
        public CharacterResources.CHARACTERS character;

        public int completedItems;
        public bool showNotification;

        public bool complete;

        public TodoItem(string title) {
            this.title = title;
            this.checklist = new List<ChecklistItem>();
            this.completedItems = 0;
            this.showNotification = true;
            this.complete = false;
        }

        public TodoItem(string title, CharacterResources.CHARACTERS character) {
            this.title = title;
            this.checklist = new List<ChecklistItem>();
            this.character = character;
            this.completedItems = 0;
            this.showNotification = true;
        }

        public ChecklistItem AddToChecklist(string c) {
            ChecklistItem ci = new ChecklistItem(c, this);
            this.checklist.Add(ci);
            return ci;
        }

        public void CompleteTask(){
            this.complete = true;
        }
    }

    public static void FinishTask(string taskName){
        foreach(TodoItem task in todoList){
            if(task.title == taskName){
                task.CompleteTask();
                break;
            }
        }
    }

    public class ChecklistItem
    {
        public string title;
        public bool completed;
        public string id;

        public TodoItem parent;
        public ChecklistItem(string title, TodoItem parent) {
            this.title = title;
            this.id = title.GetHashCode().ToString();
            this.parent = parent;
        }

        public void CompleteTask() {
            this.completed = true;
            this.parent.completedItems++;
        }
    }

    public class InfoItem
    {
        public int day;
        public string description;
        public string character;
        public CharacterResources.CHARACTERS characterEnum;
        public string tagIdentifier;
        public bool showNotification;
        public readonly Quest quest;

        public InfoItem(string character, CharacterResources.CHARACTERS characterEnum, int day, string description) {
            this.character = character;
            this.characterEnum = characterEnum;
            this.day = day;
            this.description = description;
            string unhashedKey = character + day + description;
            this.tagIdentifier = unhashedKey.GetHashCode().ToString();
            this.showNotification = true;
        }

        public InfoItem(string character, CharacterResources.CHARACTERS characterEnum,
            int day, string description, Quest quest) {
            this.character = character;
            this.characterEnum = characterEnum;
            this.day = day;
            this.description = description;
            string unhashedKey = character + day + description;
            this.tagIdentifier = unhashedKey.GetHashCode().ToString();
            this.quest = quest;
        }
    }

    public class CharacterItem
    {
        public string title;
        public string shortname;
        public string description;
        public string job;
        public string location;
        public string pronouns;
        public int age;
        public float health;
        public float time;
        public float tech;
        public float resources;
        public CharacterResources.CHARACTERS identifier;

        public CharacterItem(
            string title,
            string shortname,
            string description,
            string job,
            string location,
            string pronouns,
            int age,
            float health,
            float time,
            float tech,
            float resources) {

            this.title = title;
            this.shortname = shortname;
            this.description = description;
            this.job = job;
            this.location = location;
            this.pronouns = pronouns;
            this.age = age;
            this.health = health;
            this.time = time;
            this.tech = tech;
            this.resources = resources;
        }

        public void SetCharacterEnum(CharacterResources.CHARACTERS c) {
            this.identifier = c;
        }

        public void UpdateStat(string target)
        {
            switch (target)
            {
                case "health":
                    health = GetNewValue(health);
                    break;
                case "time":
                    time = GetNewValue(time);
                    break;
                case "tech":
                    tech = GetNewValue(tech);
                    break;
                case "resources":
                    resources = GetNewValue(resources);
                    break;
                default:
                    throw new System.Exception("Wrong Argument");
            }
        }

        //needed to fix compile error
        public void UpdateStat(string target, int val)
        {
            switch (target)
            {
                case "health":
                    health = GetNewValue(health);
                    break;
                case "time":
                    time = GetNewValue(time);
                    break;
                case "tech":
                    tech = GetNewValue(tech);
                    break;
                case "resources":
                    resources = GetNewValue(resources);
                    break;
                default:
                    throw new System.Exception("Wrong Argument");
            }
        }

        private static float GetNewValue(float original)
        {
            // 5 levels total
            // Starts from 0 to 1. Increase by 0.2
            float num = 0.2f;

            float ans = original + num;
            if (ans > 1.0f)
            {
                ans = 1.0f;
            }
            if (ans < 0.0f)
            {
                ans = 0.0f;
            }
            return ans;
        }
    }

    public static List<TodoItem> todoList = new List<TodoItem>();
    public static List<InfoItem> infoList = new List<InfoItem>();
    public static Dictionary<CharacterResources.CHARACTERS, CharacterItem> contactsList = new Dictionary<CharacterResources.CHARACTERS, CharacterItem>();
    public static int untaggedTodoObjects = 0;
    public static int untaggedInfoObjects = 0;

    public static void addNewItemToTodoList(
        string title, CharacterResources.CHARACTERS c)
    {
        Debug.Log("the notifiation callback should have happend");
        GlobalGameInfo.todoList.Add(new TodoItem(title, c));
        untaggedTodoObjects++;
        notificationCallback(NOTIFICATION.TODO);

        // Data collection
        DataCollection.LogEvent("Quest added! Quest title: " + title + ", Character: " + c, "QUEST ADDED");
    }

    public static ChecklistItem addNewTodoToExistingList(string title, string checklistitem)
    {
        TodoItem t = GlobalGameInfo.todoList.Find(item => item.title == title);
        return t.AddToChecklist(checklistitem);
    }

    public static void addNewItemToInfoList(
        string character,
        CharacterResources.CHARACTERS characterEnum,
        int day,
        string description,
        Quest quest = null)
    {
        GlobalGameInfo.infoList.Add(new InfoItem(character, characterEnum, day, description, quest));
        untaggedInfoObjects++;
        notificationCallback(NOTIFICATION.INFO);

        // Data collection
        DataCollection.LogEvent("Journal info added! Info: " + description + ", Character: " + character, "JOURNAL INFO");
    }

    public static void addNewItemToContactsList(CharacterItem c) {
        GlobalGameInfo.contactsList.Add(c.identifier, c);
    }

    public static int GetCurrentDay()
    {
        return currentDay;
    }

    public static int GetCurrentWeek()
    {
        return currentWeek;
    }

    public static string GetCurrentNPC()
    {
        return currentNPC;
    }

    public static string GetCurrentTask()
    {
        return currentTask;
    }

    public static int GetRemainDays()
    {
        return 4 - currentDay;
    }

    public static void IncreaseDay()
    {
        currentDay++;
        if (currentDay > 4)
        {
            currentDay = 4;
        }
        Debug.Log("Current Day: " + currentDay);
    }

    // call this function using GlobalGameInfo.GetEngagement()
    public static int GetEngagement()
    {
        return engagement;
    }

    // call this function using GameManager.Instance.IncreaseEngagement()
    public static void IncreaseEngagement()
    {
        if (engagement < MAX_ENGAGEMENT)
        {
            engagement++;
        }
        Debug.Log("New Engagement = " + engagement);
    }

    public static void SeeAllTodoItems(){
        foreach(TodoItem item in todoList){
            if(item.showNotification){
                decreaseUntaggedTodoObjects();
            }
            item.showNotification = false;
        }
    }
}
