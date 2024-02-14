using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using System.Collections.Generic;

public static class SaveSerial : object {

#if UNITY_EDITOR
    public static bool IgnoreSaveData = true;
#endif

    public static void SaveGame(Dictionary<string, SavedGame> dataToSave)
    {
#if UNITY_EDITOR
        if (IgnoreSaveData) {
            Debug.Log("Game data not saved, saving is disabled.");
            return;
        }
#endif

        BinaryFormatter bf = new BinaryFormatter(); 
        // FileStream file = LoadGameFile();
        FileStream file = null;
        if (File.Exists(Application.persistentDataPath 
                    + "/SavedData.dat"))
        {
            using (file = File.Open(Application.persistentDataPath
                    + "/SavedData.dat", FileMode.Open)) {
                        bf.Serialize(file, dataToSave);
                    }
        } else {
            using (file = File.Create(Application.persistentDataPath 
                + "/SavedData.dat", 1)) {
                    bf.Serialize(file, dataToSave);
                }
        }
        GlobalGameInfo.gameData = dataToSave;
        Debug.Log("Game data saved!");
    }

    public static Dictionary<string, SavedGame> LoadGame()
    {
#if UNITY_EDITOR
        if (IgnoreSaveData) {
            Debug.Log("Ignoring save data");
            return null;
        }
#endif
        if (File.Exists(Application.persistentDataPath 
                    + "/SavedData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream file = 
                    File.Open(Application.persistentDataPath
                    + "/SavedData.dat", FileMode.Open)) {
                        Dictionary<string, SavedGame> data = (Dictionary<string, SavedGame>)bf.Deserialize(file);
                        return data;
                    }
            Debug.Log("Game data loaded!");
        } else {
            Debug.Log("There is no save data!");
            return null;
        }
    }

}