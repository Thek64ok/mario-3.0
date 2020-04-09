using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.IO;

public class LoadedBG : MonoBehaviour
{
    private PauseMenu loading;
    public Text spaceBar;
    string autosave;
    void Start()
    {
        autosave = "C:/Users/" + Environment.UserName + "/Documents/" + Application.productName + "/Saves/" + "autoSave-" + PlayerPrefs.GetInt("CurrentScene") + ".save";
        Debug.Log(PlayerPrefs.GetInt("check"));
        gameObject.SetActive(true);
        loading = FindObjectOfType<PauseMenu>();
        Time.timeScale = 0.000001f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.SetActive(false);
            Time.timeScale = 1f;
        }
        if (Input.GetKeyDown(KeyCode.Space) && PlayerPrefs.GetInt("check") == 1)
        {
            if (File.Exists(autosave))
            {
                loading.autosave = autosave;
                loading.AutoLoadBetweenScens();
                PlayerPrefs.SetInt("RenameAutoSave", 0);
                loading.AutoSaveBetweenScens();
                gameObject.SetActive(false);
                Time.timeScale = 0.1f;
                PlayerPrefs.SetInt("check", 0);
                Debug.Log("dayn");
            }
            else
            {
                loading.filePathNotF5 = "C:/Users/" + Environment.UserName + "/Documents/" + Application.productName + "/Saves/" + PlayerPrefs.GetString("FileToLoad") + ".save";
                loading.LoadGame();
                gameObject.SetActive(false);
                Time.timeScale = 0.1f;
                PlayerPrefs.SetInt("check", 0);
                Debug.Log("dayn1");
            }
        }
    }
}
