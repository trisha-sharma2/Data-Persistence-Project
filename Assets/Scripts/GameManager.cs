using System;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public string playerName;
    public int bestScore;
    public string bestName;

    [System.Serializable]
    class SaveData
    {
        public int bestScore;
        public string bestName;
    }

    string path;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        path = Application.persistentDataPath + "/savefile.json";
        Load();
    }

    public string BestLabel => bestScore == 0 ? "Best Score : " : $"Best Score : {bestName} : {bestScore}";

    public void TrySetHighScore(int score)
    {
        if (score > bestScore)
        {
            bestScore = score;
            bestName = playerName;
            Save();
        }
    }

    void Save()
    {
        SaveData data = new SaveData {bestScore = bestScore, bestName = bestName};
        File.WriteAllText(path, JsonUtility.ToJson(data));
    }

    void Load()
    {
        if (File.Exists(path))
        {
            SaveData data = JsonUtility.FromJson<SaveData>(File.ReadAllText(path));
            bestScore = data.bestScore;
            bestName = data.bestName;
        }
    }
}
