using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadSkillTreeScen : MonoBehaviour
{
    private knightStats stats;
    void Start()
    {
        stats = GetComponent<knightStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (stats.skillPoints > 0)
            SceneManager.LoadScene("Skill Tree");
    }
}
