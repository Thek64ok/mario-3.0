using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.IO;

public class LoadNextLvl : MonoBehaviour
{
    public GameObject Messege;
    public GameObject teleportPoint;
    private wasd knight;
    private PauseMenu save;
    string autosave;
    void Start()
    {
        save = FindObjectOfType<PauseMenu>();
        autosave = "C:/Users/" + Environment.UserName + "/Documents/" + Application.productName + "/Saves/" + "autoSave-" + Application.loadedLevel + ".save";
        knight = FindObjectOfType<wasd>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PressNo()
    {
        Messege.SetActive(false);
        Time.timeScale = 1f;
        knight.transform.position = teleportPoint.transform.position;
    }
    public void PressYes()
    {
        save.autosave = autosave;
        if (Application.loadedLevel == 4)
            MenuControls.IDScen = 2;
        else
        {
            if (Application.loadedLevel == 2)
                MenuControls.IDScen = 4;
        }
        PlayerPrefs.SetInt("RenameAutoSave", 1);
        save.AutoSaveBetweenScens();
        PlayerPrefs.SetInt("CurrentScene", Application.loadedLevel);
        SceneManager.LoadScene("loadScene");
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Knight")
        {
            Messege.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
