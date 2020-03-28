using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuControls : MonoBehaviour
{
    public GameObject loadPanel;
    public GameObject mainPanel;
    public Text textInFirstSlot;
    public Text textInSecondSlot;
    public Text textInThirdSlot;
    public Text textInFourthSlot;
    public Text textInFivethSlot;
    private PauseMenu load;
    void Start()
    {
        load = FindObjectOfType<PauseMenu>();
        textInFirstSlot.text = PlayerPrefs.GetString("FirstFile");
        textInSecondSlot.text = PlayerPrefs.GetString("SecondFile");
        textInThirdSlot.text = PlayerPrefs.GetString("ThithFile");
        textInFourthSlot.text = PlayerPrefs.GetString("FourthFile");
        textInFivethSlot.text = PlayerPrefs.GetString("FivethFile");
    }
    private void Update()
    {
        /*
        textInFirstSlot.text = PlayerPrefs.GetString("FirstFile");
        textInSecondSlot.text = PlayerPrefs.GetString("SecondFile");
        textInThirdSlot.text = PlayerPrefs.GetString("ThithFile");
        textInFourthSlot.text = PlayerPrefs.GetString("FourthFile");
        textInFivethSlot.text = PlayerPrefs.GetString("FivethFile");
        */
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
