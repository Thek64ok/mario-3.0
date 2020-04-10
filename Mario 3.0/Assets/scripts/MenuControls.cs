using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System;


public class MenuControls : MonoBehaviour
{
    public GameObject loadPanel;
    public GameObject mainPanel;
    public Text textInFirstSlot;
    public Text textInSecondSlot;
    public Text textInThirdSlot;
    public Text textInFourthSlot;
    public Text textInFivethSlot;
    public Button[] arrayButton;
    public Text[] arrayText;
    public Button quickSave;
    public Button autoSave;
    string autosavePath;
    string quickSavePath;
    public static int IDScen;
    public static bool check1;
    void Start()
    {
        quickSave.interactable = false;
        autoSave.interactable = false;
        textInFirstSlot.text = PlayerPrefs.GetString("FirstFile");
        textInSecondSlot.text = PlayerPrefs.GetString("SecondFile");
        textInThirdSlot.text = PlayerPrefs.GetString("ThithFile");
        textInFourthSlot.text = PlayerPrefs.GetString("FourthFile");
        textInFivethSlot.text = PlayerPrefs.GetString("FivethFile");
        for (int i = 0; i < Directory.GetFiles("C:/Users/" + Environment.UserName + "/Documents/" + Application.productName + "/Saves/").Length; i++)
        {
            if (Directory.GetFiles("C:/Users/" + Environment.UserName + "/Documents/" + Application.productName + "/Saves/")[i].IndexOf("autoSave") >= 0)
            {
                autoSave.interactable = true;
                autosavePath = Path.GetFileNameWithoutExtension(Directory.GetFiles("C:/Users/" + Environment.UserName + "/Documents/" + Application.productName + "/Saves/")[i]);
            }
            else
            {
                if (Directory.GetFiles("C:/Users/" + Environment.UserName + "/Documents/" + Application.productName + "/Saves/")[i].IndexOf("QuickSave") >= 0)
                {
                    quickSave.interactable = true;
                    quickSavePath = Path.GetFileNameWithoutExtension(Directory.GetFiles("C:/Users/" + Environment.UserName + "/Documents/" + Application.productName + "/Saves/")[i]);
                }
            }

        }
    }
    private void Update()
    {
        for (int i = 0; i < arrayButton.Length; i++)
        {
            if (arrayText[i].text == "")
                arrayButton[i].interactable = false;
            else
                arrayButton[i].interactable = true;
        }
        
        //textInFirstSlot.text = PlayerPrefs.GetString("FirstFile");
        //textInSecondSlot.text = PlayerPrefs.GetString("SecondFile");
        //textInThirdSlot.text = PlayerPrefs.GetString("ThithFile");
       // textInFourthSlot.text = PlayerPrefs.GetString("FourthFile");
       // textInFivethSlot.text = PlayerPrefs.GetString("FivethFile");
        if (File.Exists("C:/Users/" + Environment.UserName + "/Documents/" + Application.productName + "/Saves/" + textInFirstSlot.text + ".save"))
            textInFirstSlot.text = PlayerPrefs.GetString("FirstFile");
        else
            textInFirstSlot.text = "";
        if (File.Exists("C:/Users/" + Environment.UserName + "/Documents/" + Application.productName + "/Saves/" + textInSecondSlot.text + ".save"))
            textInSecondSlot.text = PlayerPrefs.GetString("SecondFile");
        else
            textInSecondSlot.text = "";
        if (File.Exists("C:/Users/" + Environment.UserName + "/Documents/" + Application.productName + "/Saves/" + textInThirdSlot.text + ".save"))
            textInThirdSlot.text = PlayerPrefs.GetString("ThithFile");
        else
            textInThirdSlot.text = "";
        if (File.Exists("C:/Users/" + Environment.UserName + "/Documents/" + Application.productName + "/Saves/" + textInFourthSlot.text + ".save"))
            textInFourthSlot.text = PlayerPrefs.GetString("FourthFile");
        else
            textInFourthSlot.text = "";
        if (File.Exists("C:/Users/" + Environment.UserName + "/Documents/" + Application.productName + "/Saves/" + textInFivethSlot.text + ".save"))
            textInFivethSlot.text = PlayerPrefs.GetString("FivethFile");
        else
            textInFivethSlot.text = "";
    }
    public void PlayPressed()
    {
        IDScen = 2;
        check1 = false;
        //PlayerPrefs.DeleteKey("FileToLoad");
        SceneManager.LoadScene("loadScene");
    }

    public void ExitPressed()
    {
        Debug.Log("Exit pressed!");
        Application.Quit();
    }
    public void toLoadPanel()
    {
        loadPanel.SetActive(true);
        mainPanel.SetActive(false);
    }
    public void backToMane()
    {
        loadPanel.SetActive(false);
        mainPanel.SetActive(true);
    }
    public void LoadFromFirstFile(Text text)
    {
        Debug.Log(text.text);
        PlayerPrefs.SetString("FileToLoad", text.text);
        if (text.text.EndsWith("2"))
            IDScen = 2;
        else
        {
            if (text.text.EndsWith("4"))
                IDScen = 4;
        }
    }
    public void LoadFromAutoSave()
    {
        PlayerPrefs.SetString("FileToLoad", autosavePath);
        if (autosavePath.EndsWith("2"))
            IDScen = 2;
        else
        {
            if (autosavePath.EndsWith("4"))
                IDScen = 4;
        }
    }
    public void LoadFromQuickSave()
    {
        PlayerPrefs.SetString("FileToLoad", quickSavePath);
        if (quickSavePath.EndsWith("2"))
            IDScen = 2;
        else
        {
            if (quickSavePath.EndsWith("4"))
                IDScen = 4;
        }
    }
    public void LoadGameFromFile()
    {
        check1 = true;
        SceneManager.LoadScene("loadScene");
    }
}
