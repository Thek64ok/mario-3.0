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
    public static int IDScen;
    public static bool check1;
    void Start()
    {
        textInFirstSlot.text = PlayerPrefs.GetString("FirstFile");
        textInSecondSlot.text = PlayerPrefs.GetString("SecondFile");
        textInThirdSlot.text = PlayerPrefs.GetString("ThithFile");
        textInFourthSlot.text = PlayerPrefs.GetString("FourthFile");
        textInFivethSlot.text = PlayerPrefs.GetString("FivethFile");
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
        SceneManager.LoadScene("loadScene");
        IDScen = 2;
        check1 = false;
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
    }
    public void LoadGameFromFile()
    {
        SceneManager.LoadScene("loadScene");
        check1 = true;
    }
}
