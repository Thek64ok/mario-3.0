using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    public GameObject[] pictureArray;
    private bool pointInFirstSkill;
    private bool pointInSecondSkill;
    private bool pointInFightOrRunSkill;
    public bool pointInFreez;
    public bool pointInCriticalStrike;
    public bool pointInSkill1;
    public bool pointInSkill2;
    public GameObject[] skillsArray;
    private float timer = 300f;
    private bool cooldown;
    private Knight_HealthSystem hideGUI;
    public GameObject bars;
    

    void Start()
    {
        check = FindObjectOfType<fireArea>();
        points = FindObjectOfType<knightStats>();
        damage = knight.GetComponent<Hurt_Enemy>();
        hideGUI = FindObjectOfType<Knight_HealthSystem>();
        for(int i = 0; i < skillsArray.Length; i++)
        {
            skillsArray[i].SetActive(false); 
        }
    }

    void Update()
    {
        
        if (points.skillPoints == 0)
        {
            for (int i = 0; i < firstBust.Length; i++)
            {
                //ColorBlock colors = firstBust[i].colors;
                //colors.normalColor = new Color(100, 110, 110, 100);
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
        if (pointInFightOrRunSkill)
        {
            if (timer == 300f)
            {
                if (hideGUI.knightCurrentHealth <= 0)
                {
                    hideGUI.knightCurrentHealth = hideGUI.knightMaxHealth * 0.4f;
                    cooldown = true;
                }
            }
            if (cooldown)
                timer -= Time.deltaTime;
            if (timer <= 0)
            {
                cooldown = false;
                timer = 300f;
            }
        }
        if (pointInFirstSkill)
            pictureArray[0].SetActive(true);
        if (pointInSecondSkill)
            pictureArray[1].SetActive(true);
        if (pointInFightOrRunSkill)
            pictureArray[2].SetActive(true);
        if (pointInCriticalStrike)
            pictureArray[3].SetActive(true);
        if (pointInFreez)
            pictureArray[4].SetActive(true);
        if(pointInSkill1)
        {
            skillsArray[0].SetActive(true);
            pictureArray[5].SetActive(true);
        }
        if(pointInSkill2)
        {
            skillsArray[1].SetActive(true);
            pictureArray[6].SetActive(true);
        }
        
    }
    public void Exit()
    {
        Time.timeScale = 1f;
        menu.SetActive(false);
        check.check = true;
        bars.SetActive(true);
        //hideGUI.SetActiveGUI(true);
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
        damage.damageToGive = 5;
        points.skillPoints--;
        pointInFirstSkill = true;
    }
    public void secondSkill()
    {
        hideGUI.knightMaxHealth += 30;
        hideGUI.hpBar.SetMaxValue(hideGUI.knightMaxHealth);
        points.skillPoints--;
        pointInSecondSkill = true;
    }
    public void fight_or_run()
    {
        points.skillPoints--;
        pointInFightOrRunSkill = true;
    }
    public void freez()
    {
        points.skillPoints--;
        pointInFreez = true;
    }
    public void critical_strike()
    {
        points.skillPoints--;
        pointInCriticalStrike = true;
    }
    public void skill1()
    {
        points.skillPoints--;
        pointInSkill1 = true;
    }
    public void skill2()
    {
        points.skillPoints--;
        pointInSkill2 = true;
    }
}
