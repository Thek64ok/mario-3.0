using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public List<GameObject> KnightSaves = new List<GameObject>();
    string filePath;
    void Start()
    {
        filePath = Application.persistentDataPath + "/save.sosi";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Exit()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void LeaveToMainMenu()
    {
        SceneManager.LoadScene("Main menu");
        Time.timeScale = 1f;
    }
    public void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(filePath, FileMode.Create);
        Save save = new Save();
        save.SaveGame(KnightSaves);
        bf.Serialize(fs, save);
        fs.Close();
    }
    public void LoadGame()
    {
        if (!File.Exists(filePath))
            return;
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(filePath, FileMode.Open);
        Save save =(Save)bf.Deserialize(fs);
        fs.Close();
        int i = 0;
        foreach (var knight in save.Saves)
        {
            KnightSaves[i].GetComponent<wasd>().LoadDate(knight);
            i++;
        }
    }
}

[System.Serializable]
public class Save
{
    [System.Serializable]
    public struct Vec2
    {
        public float x, y;
        public Vec2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
    }
    [System.Serializable]
    public struct KnightSaveData
    {
        public Vec2 Position;
        public KnightSaveData(Vec2 pos)
        {
            Position = pos;
        }
    }
    public List<KnightSaveData> Saves = new List<KnightSaveData>();
    public void SaveGame(List<GameObject> allOnSave)
    {
        foreach (var s in allOnSave)
        {
            Vec2 pos = new Vec2(s.transform.position.x, s.transform.position.y);
            Saves.Add(new KnightSaveData(pos));
        }
    }
}
