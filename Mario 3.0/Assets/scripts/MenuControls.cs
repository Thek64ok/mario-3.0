using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuControls : MonoBehaviour
{
    public GameObject loadPanel;
    public GameObject mainPanel;
    private PauseMenu load;
    void Start()
    {
        load = FindObjectOfType<PauseMenu>();
    }
    public void PlayPressed()
    {
        SceneManager.LoadScene("SampleScene");
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
}
