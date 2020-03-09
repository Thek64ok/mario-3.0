using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class loadSkillTreeScen : MonoBehaviour
{
    public GameObject menu;
    private fireArea check;
    public GameObject Tree;
    private knightStats points;
    public GameObject knight;
    private Hurt_Enemy damage;
    public Button[] firstBust;

    void Start()
    {
        check = FindObjectOfType<fireArea>();
        points = FindObjectOfType<knightStats>();
        damage = knight.GetComponent<Hurt_Enemy>();
    }

    void Update()
    {
        if (points.skillPoints == 0)
        {
            for (int i = 0; i < firstBust.Length; i++)
            {
                ColorBlock colors = firstBust[i].colors;
                colors.normalColor = new Color(100, 110, 110, 100);
                firstBust[i].interactable = false;
            }
        }
        else
        {  
            if (points.skillPoints > 0)
            {
                for (int i = 0; i < firstBust.Length; i++)
                    firstBust[i].interactable = true;
            }   
        }
    }
    public void Exit()
    {
        Time.timeScale = 1f;
        menu.SetActive(false);
        check.check = true;
    }
    public void Points()
    {
        Tree.SetActive(true);
    }

    public void BackToMenu()
    {
        Tree.SetActive(false);
    }
    public void firstSkill()
    {
        Debug.Log(points.skillPoints);
        damage.damageToGive = 5;
        points.skillPoints--;
        Debug.Log(points.skillPoints);
    }
    public void secondSkill()
    {
        
    }
}
