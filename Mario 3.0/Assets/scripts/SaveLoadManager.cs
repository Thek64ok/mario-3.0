using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class SaveLoadManager : MonoBehaviour
{
    public bool slotPressed;
    public bool slot0;
    public bool slot1;
    public bool slot2;
    public bool slot3;
    public bool slot4;
    public Text textInFirstSlot;
    public Text textInSecondSlot;
    public Text textInThirdSlot;
    public Text textInFourthSlot;
    public Text textInFivethSlot;
    public string filePathInFirstSlot;
    public string filePathInSecondSlot;
    public string filePathInThirdSlot;
    public string filePathInFourthSlot;
    public string filePathInFivethSlot;
    void Start()
    {
        filePathInFirstSlot = textInFirstSlot.text;
        filePathInSecondSlot = textInSecondSlot.text;
        filePathInThirdSlot = textInThirdSlot.text;
        filePathInFourthSlot = textInFourthSlot.text;
        filePathInFivethSlot = textInFivethSlot.text;
    }

    // Update is called once per frame
    void Update()
    {
        textInFirstSlot.text = PlayerPrefs.GetString("FirstFile");
        textInSecondSlot.text = PlayerPrefs.GetString("SecondFile");
        textInThirdSlot.text = PlayerPrefs.GetString("ThithFile");
        textInFourthSlot.text = PlayerPrefs.GetString("FourthFile");
        textInFivethSlot.text = PlayerPrefs.GetString("FivethFile");
        if (File.Exists("C:/Users/" + Environment.UserName + "/Documents/" + Application.productName + "/Saves/" + textInFirstSlot.text + ".save"))
            filePathInFirstSlot = textInFirstSlot.text;
        else
            textInFirstSlot.text = filePathInFirstSlot;
        if (File.Exists("C:/Users/" + Environment.UserName + "/Documents/" + Application.productName + "/Saves/" + textInSecondSlot.text + ".save"))
            filePathInSecondSlot = textInSecondSlot.text;
        else
            textInSecondSlot.text = filePathInSecondSlot;
        if (File.Exists("C:/Users/" + Environment.UserName + "/Documents/" + Application.productName + "/Saves/" + textInThirdSlot.text + ".save"))
            filePathInThirdSlot = textInThirdSlot.text;
        else
            textInThirdSlot.text = filePathInThirdSlot;
        if (File.Exists("C:/Users/" + Environment.UserName + "/Documents/" + Application.productName + "/Saves/" + textInFourthSlot.text + ".save"))
            filePathInFourthSlot = textInFourthSlot.text;
        else
            textInFourthSlot.text = filePathInFourthSlot;
        if (File.Exists("C:/Users/" + Environment.UserName + "/Documents/" + Application.productName + "/Saves/" + textInFivethSlot.text + ".save"))
            filePathInFivethSlot = textInFivethSlot.text;
        else
            textInFivethSlot.text = filePathInFivethSlot;
    }
    public void SpecialSaveLoad()
    {
        slotPressed = true;
    }
    public void Button0Pressed()
    {
        slotPressed = true;
        slot0 = true;
        slot1 = false;
        slot2 = false;
        slot3 = false;
        slot4 = false;
    }
    public void Button1Pressed()
    {
        slotPressed = true;
        slot0 = false;
        slot1 = true;
        slot2 = false;
        slot3 = false;
        slot4 = false;
    }
    public void Button2Pressed()
    {
        slotPressed = true;
        slot0 = false;
        slot1 = false;
        slot2 = true;
        slot3 = false;
        slot4 = false;
    }
    public void Button3Pressed()
    {
        slotPressed = true;
        slot0 = false;
        slot1 = false;
        slot2 = false;
        slot3 = true;
        slot4 = false;
    }
    public void Button4Pressed()
    {
        slotPressed = true;
        slot0 = false;
        slot1 = false;
        slot2 = false;
        slot3 = false;
        slot4 = true;
    }
}
