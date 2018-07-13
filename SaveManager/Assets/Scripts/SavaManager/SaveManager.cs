using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance { get; private set; }
    private const string SAVE_FILE = "SaveGame.json";
    public GameData CurrentGameData { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

		CurrentGameData = new GameData();
    }

    public void Save()
    {
        string path = GetPath(SAVE_FILE);

		EventManager.Instance.DispatchEvent(EventID.SaveGame);

        // To write Data in file
        File.WriteAllText(path, JsonUtility.ToJson(CurrentGameData));        
    }

    public void Load()
    {
        string path = GetPath(SAVE_FILE);
        if (File.Exists(path))
        {
            string gameData = File.ReadAllText(path);

			// Ceci est pour lire le Json est le remettre en GameData
            CurrentGameData = JsonUtility.FromJson<GameData>(gameData);

            EventManager.Instance.DispatchEvent(EventID.LoadGame);
        }
    }

    private string GetPath(string aSaveFile)
    {
        // Ceci est le path pour aller chercher le json
        return Path.Combine(Application.persistentDataPath, aSaveFile);
    }
}
