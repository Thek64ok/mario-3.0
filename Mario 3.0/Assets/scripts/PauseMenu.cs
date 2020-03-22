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
    private loadSkillTreeScen boolHere;
    private knightStats stats;
    private wasd checkForSword;
    private Knight_HealthSystem hpManaStamina;
    public GameObject SwordForDestroy;
    string filePath;
    void Start()
    {
        filePath = Application.persistentDataPath + "/save.sosi";
        boolHere = FindObjectOfType<loadSkillTreeScen>();
        stats = FindObjectOfType<knightStats>();
        checkForSword = FindObjectOfType<wasd>();
        hpManaStamina = FindObjectOfType<Knight_HealthSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (checkForSword.dayn == true)
            Destroy(SwordForDestroy);
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
        save.SaveBool(boolHere.listOfBool);
        save.lvl = stats.currentLvl;
        save.exp = stats.cureentExp;
        save.skillpoints = stats.skillPoints;
        save.TakeSword_OrNot = checkForSword.dayn;
        save.hp = hpManaStamina.knightCurrentHealth;
        save.stamina = hpManaStamina.knightCurrentStamina;
        save.mana = hpManaStamina.knightCurrentMana;
        bf.Serialize(fs, save);
        fs.Close();
        Exit();
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
        boolHere.LoadData(save);
        stats.currentLvl = save.lvl;
        stats.cureentExp = save.exp;
        stats.skillPoints = save.skillpoints;
        checkForSword.dayn = save.TakeSword_OrNot;
        hpManaStamina.knightCurrentHealth = save.hp;
        hpManaStamina.knightCurrentStamina = save.stamina;
        hpManaStamina.knightCurrentMana = save.mana;
        Exit();
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
    public int lvl;
    public int exp;
    public int skillpoints;
    public bool TakeSword_OrNot;
    public float hp;
    public float stamina;
    public float mana;
    public List<KnightSaveData> Saves = new List<KnightSaveData>();
    public List<bool> SavesOfBool = new List<bool>();
    public void SaveGame(List<GameObject> allOnSave)
    {
        foreach (var s in allOnSave)
        {
            Vec2 pos = new Vec2(s.transform.position.x, s.transform.position.y);
            Saves.Add(new KnightSaveData(pos));
        }
    }
    public void SaveBool(List<bool> allOnBoolSave)
    {
        foreach (var save in allOnBoolSave)
        {
            SavesOfBool.Add(save);
        }
    }
}
