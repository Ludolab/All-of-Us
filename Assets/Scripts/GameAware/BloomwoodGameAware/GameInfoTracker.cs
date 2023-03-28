using GameAware;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInfoTracker : MetaDataTrackable {

    private long sceneStartKey = -1;
    private string currentScene = string.Empty;

    // Start is called before the first frame update
    override protected void Start() {
        objectKey = "gameInfo";
        screenRectStyle = ScreenSpaceReference.None;
        frameType = MetaDataFrameType.KeyFrame;
        persistAcrossScenes = true;
        SceneManager.activeSceneChanged += OnSceneChange;

        base.Start();

    }

    private void OnSceneChange(Scene current, Scene next) {
        sceneStartKey = MetaDataTracker.Instance.CurrentKeyFrameNum;
        currentScene = next.name;
    }

    public override JObject KeyFrameData() {
        JObject ret = new JObject {
            {"currentScene", currentScene },
            {"sceneStartFrame", sceneStartKey },
            {"playerName", GlobalGameInfo.GetPlayerName()},
            {"pronouns",GlobalGameInfo.pronouns },
            {"language", GlobalGameInfo.language },
            {"currentTask", GlobalGameInfo.GetCurrentTask() },
            {"currentDay", GlobalGameInfo.GetCurrentDayString() },
            {"currentWeek", GlobalGameInfo.GetCurrentWeek() },
        };

        JArray todos = new JArray();
        foreach(GlobalGameInfo.TodoItem todo in GlobalGameInfo.todoList) {
            todos.Add(new JObject {
                {"title", todo.title},
                {"character", todo.character.ToString() },
                {"complete", todo.complete }
             });
        }
        ret["todos"] = todos;

        JArray cast = new JArray();
        foreach(GlobalGameInfo.CharacterItem character in GlobalGameInfo.contactsList.Values) {
            cast.Add(new JObject {
                {"title", character.title},
                {"shortname", character.shortname },
                {"description", character.description },
                {"job", character.job },
                {"location", character.location},
                {"pronouns", character.pronouns },
                {"age", character.age },
                {"health", character.health },
                {"time", character.time },
                {"tech", character.tech },
                {"resources", character.resources },
             });
        }
        ret["cast"] = cast;

        return ret;
    }



}
