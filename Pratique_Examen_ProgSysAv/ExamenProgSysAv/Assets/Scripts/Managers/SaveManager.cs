using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using System;

public class SaveManager : MonoBehaviour
{
    private string SAVE_FILE_PATH;

    private void Awake()
    {
        SAVE_FILE_PATH = Application.persistentDataPath + "/save.json";
        Debug.Log(SAVE_FILE_PATH);
    }

    public void SaveGame()
    {
        SaveData data = new SaveManager.SaveData
        {
            characterPositionX = Game.player.transform.position.x,
            characterPositionY = Game.player.transform.position.y,
            currentMap = Game.map.CurrentMap,
            skills = Game.player.skills
        };
        
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(SAVE_FILE_PATH, json);
    }

    public bool LoadGame()
    {
        if (!File.Exists(SAVE_FILE_PATH))
        {
            Debug.Log("The game was never saved");
            return false;
        }

        string json = File.ReadAllText(SAVE_FILE_PATH);
        SaveData data = JsonUtility.FromJson<SaveData>(json);

        Game.player.skills = data.skills;

        Game.map.LoadScene(data.currentMap, new Vector3(data.characterPositionX, data.characterPositionY));
        return true;
    }
    
    public class SaveData
    {
        public float characterPositionX;
        public float characterPositionY;
        public string currentMap;
        public List<FighterSkill> skills;
    }
}
