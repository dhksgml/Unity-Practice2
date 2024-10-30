using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public int bestScore;
    public string bestUserName;
    public string userName;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadJson();
    }

    [System.Serializable]
    class SaveData 
    {
        public int bestScore;
        public string bestUserName;
        public string userName;
    }
    public void SaveJson()
    {
        SaveData data = new SaveData();
        data.bestScore = bestScore;
        data.bestUserName = bestUserName;
        data.userName = userName;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadJson()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestScore = data.bestScore;
            bestUserName = data.bestUserName;
            userName = data.userName;
        }
    }
}
