using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;


    public string PlayerName;
    public int BestScore;
    public string BestScoreName;

    // Start is called before the first frame update
    void Start()
    {
        DataManager.Instance.LoadBestScore();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveData
    {
        public int BestScore;
        public string BestScoreName;
        public string PlayerName;
    }

    public void SaveBestScore()
    {
        SaveData data = new SaveData();
        data.BestScore = BestScore;
        data.BestScoreName = BestScoreName;
        data.PlayerName = PlayerName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            BestScore = data.BestScore;
            BestScoreName = data.BestScoreName;
            PlayerName = data.PlayerName;
        }
    }
}
