using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    void Start()
    {
        
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
}
