using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenu;
    private PauseMenu quickSave;
    void Start()
    {
        pauseMenu.SetActive(false);
        quickSave = FindObjectOfType<PauseMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0.000000001f;
        }
        if (Input.GetKeyDown(KeyCode.F5))
        {
            quickSave.filePathF5 = "C:/Users/" + Environment.UserName + "/Documents/" + Application.productName + "/Saves/" + "QuickSave" + ".save";
            quickSave.QuickSaveF5();
        }
        if (Input.GetKeyDown(KeyCode.F9))
            quickSave.QuickLoadFile();
    }
}
