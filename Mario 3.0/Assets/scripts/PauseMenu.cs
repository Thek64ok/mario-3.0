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
    public List<GameObject> KnightSaves = new List<GameObject>();
    private loadSkillTreeScen boolHere;
    private knightStats stats;
    private wasd checkForSword;
    private Knight_HealthSystem hpManaStamina;
    private SaveLoadManager nameOfText;
    string filePathF5;
    public string filePathNotF5;
    public List<string> names = new List<string>();
    public GameObject ErrorButton;
    public GameObject ErrorRename;
    public bool[] zamena;
    void Start()
    {
        ErrorButton.SetActive(false);
        ErrorRename.SetActive(false);
        saveMenu.SetActive(false);
        //filePathF5 = "C:/Users/" + Environment.UserName + "/Documents/" + Application.productName + "/Saves/" + "QuikSave.save";
        boolHere = FindObjectOfType<loadSkillTreeScen>();
        stats = FindObjectOfType<knightStats>();
        checkForSword = FindObjectOfType<wasd>();
        hpManaStamina = FindObjectOfType<Knight_HealthSystem>();
        nameOfText = FindObjectOfType<SaveLoadManager>();
        for (int i = 0; i < Directory.GetFiles("C:/Users/" + Environment.UserName + "/Documents/" + Application.productName + "/Saves/").Length; i++)
        {
            names.Add(Directory.GetFiles("C:/Users/" + Environment.UserName + "/Documents/" + Application.productName + "/Saves/")[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        localData = DateTime.Now;
        filePathNotF5 = "C:/Users/" + Environment.UserName + "/Documents/" + Application.productName + "/Saves/" + localData.ToString("dd-MMMM-yyyy~hh-mm-ss-" + Application.loadedLevel) + ".save";
        if (!nameOfText.slotPressed)
        {
            SaveButton.interactable = false;
            LoadButton.interactable = false;
        }
        else
        {
            if(nameOfText.slotPressed)
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

    [Obsolete]
    public void SaveGame()
    {
        if (nameOfText.slot0 && nameOfText.filePathInFirstSlot != "Пустой слот")
        {
            ErrorRename.SetActive(true);
            pauseMenu.SetActive(false);
            saveMenu.SetActive(false);
            if (zamena[0])
            {
                filePathNotF5 = "C:/Users/" + Environment.UserName + "/Documents/" + Application.productName + "/Saves/" + nameOfText.filePathInFirstSlot + ".save";
                zamena[5] = true;
            }
            else
                return;
        }
        else
        {
            if (nameOfText.slot1 && nameOfText.filePathInSecondSlot != "Пустой слот")
            {
                ErrorRename.SetActive(true);
                pauseMenu.SetActive(false);
                saveMenu.SetActive(false);
                if (zamena[0])
                {
                    filePathNotF5 = "C:/Users/" + Environment.UserName + "/Documents/" + Application.productName + "/Saves/" + nameOfText.filePathInSecondSlot + ".save";
                    zamena[5] = true;
                }
                else
                    return;
            }
            else
            {
                if (nameOfText.slot2 && nameOfText.filePathInThirdSlot != "Пустой слот")
                {
                    ErrorRename.SetActive(true);
                    pauseMenu.SetActive(false);
                    saveMenu.SetActive(false);
                    if (zamena[0])
                    {
                        filePathNotF5 = "C:/Users/" + Environment.UserName + "/Documents/" + Application.productName + "/Saves/" + nameOfText.filePathInThirdSlot + ".save";
                        zamena[5] = true;
                    }
                    else
                        return;
                }
                else
                {
                    if (nameOfText.slot3 && nameOfText.filePathInFourthSlot != "Пустой слот")
                    {
                        ErrorRename.SetActive(true);
                        pauseMenu.SetActive(false);
                        saveMenu.SetActive(false);
                        if (zamena[0])
                        {
                            filePathNotF5 = "C:/Users/" + Environment.UserName + "/Documents/" + Application.productName + "/Saves/" + nameOfText.filePathInFourthSlot + ".save";
                            zamena[5] = true;
                        }
                        else
                            return;
                    }
                    else
                    {
                        if (nameOfText.slot4 && nameOfText.filePathInFivethSlot != "Пустой слот")
                        {
                            ErrorRename.SetActive(true);
                            pauseMenu.SetActive(false);
                            saveMenu.SetActive(false);
                            if (zamena[0])
                            {
                                filePathNotF5 = "C:/Users/" + Environment.UserName + "/Documents/" + Application.productName + "/Saves/" + nameOfText.filePathInFivethSlot + ".save";
                                zamena[5] = true;
                            }
                            else
                                return;
                        }
                    }
                }
            }
        }
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(filePathNotF5, FileMode.Create);
        //StreamWriter ff = new StreamWriter(filePathNotF5, false);
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
        if (zamena[5])
        {
            File.Move(filePathNotF5, "C:/Users/" + Environment.UserName + "/Documents/" + Application.productName + "/Saves/" + localData.ToString("dd-MMMM-yyyy~hh-mm-ss-" + Application.loadedLevel) + ".save");
            File.Delete(filePathNotF5);
            zamena[5] = false;
            zamena[0] = false;
        }
        saveMenu.SetActive(false);
        nameOfText.slotPressed = false;
        if (nameOfText.slot0)
        {
            nameOfText.filePathInFirstSlot = localData.ToString("dd-MMMM-yyyy~hh-mm-ss-" + Application.loadedLevel);
            PlayerPrefs.SetString("FirstFile", localData.ToString("dd-MMMM-yyyy~hh-mm-ss-") + Application.loadedLevel);
        }
        else
        {
            if (nameOfText.slot1)
            {
                nameOfText.filePathInSecondSlot = localData.ToString("dd-MMMM-yyyy~hh-mm-ss-" + Application.loadedLevel);
                PlayerPrefs.SetString("SecondFile", localData.ToString("dd-MMMM-yyyy~hh-mm-ss-" + Application.loadedLevel));
            }
            else
            {
                if (nameOfText.slot2)
                {
                    nameOfText.filePathInThirdSlot = localData.ToString("dd-MMMM-yyyy~hh-mm-ss-" + Application.loadedLevel);
                    PlayerPrefs.SetString("ThithFile", localData.ToString("dd-MMMM-yyyy~hh-mm-ss-" + Application.loadedLevel));
                }
                else
                {
                    if (nameOfText.slot3)
                    {
                        nameOfText.filePathInFourthSlot = localData.ToString("dd-MMMM-yyyy~hh-mm-ss-" + Application.loadedLevel);
                        PlayerPrefs.SetString("FourthFile", localData.ToString("dd-MMMM-yyyy~hh-mm-ss-" + Application.loadedLevel));
                    }
                    else
                    {
                        if (nameOfText.slot4)
                        {
                            nameOfText.filePathInFivethSlot = localData.ToString("dd-MMMM-yyyy~hh-mm-ss-" + Application.loadedLevel);
                            PlayerPrefs.SetString("FivethFile", localData.ToString("dd-MMMM-yyyy~hh-mm-ss-" + Application.loadedLevel));
                        }
                    }
                }
            }
        }
        Debug.Log(localData.ToString("dd-MMMM-yyyy~hh-mm-ss-" + Application.loadedLevel));
        ErrorRename.SetActive(false);
    }
    public void LoadGame()
    {
        if (PlayerPrefs.GetInt("check") == 0)
        {
            if (nameOfText.slot0 && nameOfText.filePathInFirstSlot != "Пустой слот")
                filePathNotF5 = "C:/Users/" + Environment.UserName + "/Documents/" + Application.productName + "/Saves/" + nameOfText.filePathInFirstSlot + ".save";
            else
            {
                if (nameOfText.slot1 && nameOfText.filePathInSecondSlot != "Пустой слот")
                    filePathNotF5 = "C:/Users/" + Environment.UserName + "/Documents/" + Application.productName + "/Saves/" + nameOfText.filePathInSecondSlot + ".save";
                else
                {
                    if (nameOfText.slot2 && nameOfText.filePathInThirdSlot != "Пустой слот")
                        filePathNotF5 = "C:/Users/" + Environment.UserName + "/Documents/" + Application.productName + "/Saves/" + nameOfText.filePathInThirdSlot + ".save";
                    else
                    {
                        if (nameOfText.slot3 && nameOfText.filePathInFourthSlot != "Пустой слот")
                            filePathNotF5 = "C:/Users/" + Environment.UserName + "/Documents/" + Application.productName + "/Saves/" + nameOfText.filePathInFourthSlot + ".save";
                        else
                        {
                            if (nameOfText.slot4 && nameOfText.filePathInFivethSlot != "Пустой слот")
                                filePathNotF5 = "C:/Users/" + Environment.UserName + "/Documents/" + Application.productName + "/Saves/" + nameOfText.filePathInFivethSlot + ".save";
                        }
                    }
                }
            }
        }
        if (!File.Exists(filePathNotF5))
        {
            ErrorButton.SetActive(true);
            pauseMenu.SetActive(false);
            saveMenu.SetActive(false);
            return;
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
        nameOfText.slotPressed = false;
        Exit();
    }
    public void LoadGameFromMenu()
    {
        
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
        nameOfText.slotPressed = false;
        saveMenu.SetActive(false);
        SaveButton.gameObject.SetActive(false);
        LoadButton.gameObject.SetActive(false);
        pauseMenu.SetActive(true);
    }
    public void OK()
    {
        ErrorButton.SetActive(false);
        pauseMenu.SetActive(true);
        saveMenu.SetActive(true);
    }
    public void Rename()
    {
        zamena[0] = true;
        ErrorRename.SetActive(false);
        pauseMenu.SetActive(true);
        saveMenu.SetActive(true);
    }
    public void NoRename()
    {
        zamena[0] = false;
        ErrorRename.SetActive(false);
        pauseMenu.SetActive(true);
        saveMenu.SetActive(true);
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
