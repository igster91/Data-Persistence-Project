using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OtherMainManager : MonoBehaviour
{
    // deleted start and update methods

    public TMP_InputField inputField;
    public string userName;

    public static OtherMainManager Instance;

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

    private void Update()
    {
        if (userName != inputField.text)
        {
            userName = inputField.text;
        }
    }
[System.Serializable]
class SaveData
    {
        public string userName;
    }

    public void SaveName()
    {
        SaveData data = new SaveData();
        data.userName = userName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            userName = data.userName;
        }
    }
}
