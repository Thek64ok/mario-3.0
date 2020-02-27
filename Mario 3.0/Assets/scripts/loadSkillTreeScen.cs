using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class loadSkillTreeScen : MonoBehaviour
{
    private knightStats stats;
    public Button button;
    void Start()
    {
        stats = FindObjectOfType<knightStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (stats.skillPoints == 0)
            button.enabled = false;
        else
            if (stats.skillPoints > 0)
            button.enabled = true;
    }

    public void PlayPressed()
    {
        SceneManager.LoadScene("Skill Tree");
    }
}
