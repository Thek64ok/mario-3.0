using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    DateTime localData = DateTime.Now;
    public GameObject pauseMenu;
    public GameObject saveMenu;
    public Button SaveButton;
    public Button LoadButton;
    private SaveLoadManager pressedOrNo;
    public List<GameObject> KnightSaves = new List<GameObject>();
    private loadSkillTreeScen boolHere;
    private knightStats stats;
    private wasd checkForSword;
    private Knight_HealthSystem hpManaStamina;
    //public GameObject SwordForDestroy;
    private SaveLoadManager nameOfText;
    string filePathF5;
    string filePathNotF5;
    void Start()
    {
        saveMenu.SetActive(false);
        //filePathF5 = "C:/Users/" + Environment.UserName + "/Documents/" + Application.productName + "/Saves/" + "QuikSave.save";
        boolHere = FindObjectOfType<loadSkillTreeScen>();
        stats = FindObjectOfType<knightStats>();
        checkForSword = FindObjectOfType<wasd>();
        hpManaStamina = FindObjectOfType<Knight_HealthSystem>();
        pressedOrNo = FindObjectOfType<SaveLoadManager>();
        nameOfText = FindObjectOfType<SaveLoadManager>();
    }

    // Update is called once per frame
    void Update()
    {
        localData = DateTime.Now;
        filePathNotF5 = "C:/Users/" + Environment.UserName + "/Documents/" + Application.productName + "/Saves/" + localData.ToString("dd-MMMM-yyyy~hh-mm-ss") + ".save";
       // if (checkForSword.dayn == true)
           // Destroy(SwordForDestroy);
        if (!pressedOrNo.slotPressed)
        {
            SaveButton.interactable = false;
            LoadButton.interactable = false;
        }
        else
        {
            if(pressedOrNo.slotPressed)
            SaveButton.interactable = true;
            LoadButton.interactable = true;
        }
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
        FileStream fs = new FileStream(filePathNotF5, FileMode.Create);
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
        saveMenu.SetActive(false);
        pressedOrNo.slotPressed = false;
        if (nameOfText.slot0)
            nameOfText.filePathInFirstSlot = localData.ToString("dd-MMMM-yyyy~hh-mm-ss");
        else
        {
            if (nameOfText.slot1)
                nameOfText.filePathInSecondSlot = localData.ToString("dd-MMMM-yyyy~hh-mm-ss");
            else
            {
                if (nameOfText.slot2)
                    nameOfText.filePathInThirdSlot = localData.ToString("dd-MMMM-yyyy~hh-mm-ss");
                else
                {
                    if (nameOfText.slot3)
                        nameOfText.filePathInFourthSlot = localData.ToString("dd-MMMM-yyyy~hh-mm-ss");
                    else
                    {
                        if (nameOfText.slot4)
                            nameOfText.filePathInFivethSlot = localData.ToString("dd-MMMM-yyyy~hh-mm-ss");
                    }
                }
            }
        }
        Debug.Log(localData.ToString("dd-MMMM-yyyy~hh-mm-ss"));
    }
    public void LoadGame()
    {

        if (nameOfText.slot0 && nameOfText.filePathInFirstSlot != "Пустой слот") 
            filePathNotF5 = "C:/Users/" + Environment.UserName + "/Documents/" + Application.productName + "/Saves/" + nameOfText.filePathInFirstSlot + ".save";
        else
        {
            Debug.Log("думой");
            return;
            //if (!File.Exists(filePathNotF5))
            //{
                
            //}
            //if (nameOfText.slot1)
              //  filePathNotF5 = "C:/Users/" + Environment.UserName + "/Documents/" + Application.productName + "/Saves/" + nameOfText.filePathInSecondSlot + ".save";
        }
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(filePathNotF5, FileMode.Open);
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
        saveMenu.SetActive(false);
        pressedOrNo.slotPressed = false;
        Exit();
    }
    public void ShowSaveMenu()
    {
        saveMenu.SetActive(true);
        SaveButton.gameObject.SetActive(true);
        LoadButton.gameObject.SetActive(false);
        pauseMenu.SetActive(false);
    }
    public void ShowLoadMenu()
    {
        saveMenu.SetActive(true);
        SaveButton.gameObject.SetActive(false);
        LoadButton.gameObject.SetActive(true);
        pauseMenu.SetActive(false);
    }
    public void CloseSaveMenu()
    {
        pressedOrNo.slotPressed = false;
        saveMenu.SetActive(false);
        SaveButton.gameObject.SetActive(false);
        LoadButton.gameObject.SetActive(false);
        pauseMenu.SetActive(true);
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
