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
    public bool pointInFirstSkill;
    public bool pointInSecondSkill;
    public bool pointInFightOrRunSkill;
    public bool pointInFreez;
    public bool pointInCriticalStrike;
    public bool pointInSkill1;
    public bool pointInSkill2;
    public bool pointInSkill3;
    public List<bool> listOfBool = new List<bool>();
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
        for (int i = 0; i < skillsArray.Length; i++)
        {
            skillsArray[i].SetActive(false);
        }
        listOfBool.Add(pointInFirstSkill);
        listOfBool.Add(pointInSecondSkill);
        listOfBool.Add(pointInFightOrRunSkill);
        listOfBool.Add(pointInFreez);
        listOfBool.Add(pointInCriticalStrike);
        listOfBool.Add(pointInSkill1);
        listOfBool.Add(pointInSkill2);
        listOfBool.Add(pointInSkill3);
    }

    void Update()
    {
        if (points.skillPoints == 0)
        {
            for (int i = 0; i < firstBust.Length; i++)
            {
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
        {
            pictureArray[0].SetActive(true);
            damage.damageToGive = 5;
        }
        if (pointInSecondSkill)
        {
            pictureArray[1].SetActive(true);
            hideGUI.knightMaxHealth = 80;
            hideGUI.hpBar.SetMaxValue(hideGUI.knightMaxHealth);
        }
        if (pointInFightOrRunSkill)
            pictureArray[2].SetActive(true);
        if (pointInCriticalStrike)
            pictureArray[3].SetActive(true);
        if (pointInFreez)
            pictureArray[4].SetActive(true);
        if (pointInSkill1)
        {
            skillsArray[0].SetActive(true);
            pictureArray[5].SetActive(true);
        }
        if (pointInSkill2)
        {
            skillsArray[1].SetActive(true);
            pictureArray[6].SetActive(true);
        }
        if (pointInSkill3)
        {
            skillsArray[2].SetActive(true);
            pictureArray[7].SetActive(true);
        }

    }
    public void Exit()
    {
        Time.timeScale = 1f;
        menu.SetActive(false);
        check.check = true;
        bars.SetActive(true);
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
        points.skillPoints--;
        pointInFirstSkill = true;
        listOfBool[0] = true;
    }
    public void secondSkill()
    {
        points.skillPoints--;
        pointInSecondSkill = true;
        listOfBool[1] = true;
    }
    public void fight_or_run()
    {
        points.skillPoints--;
        pointInFightOrRunSkill = true;
        listOfBool[2] = true;
    }
    public void freez()
    {
        points.skillPoints--;
        pointInFreez = true;
        listOfBool[3] = true;
    }
    public void critical_strike()
    {
        points.skillPoints--;
        pointInCriticalStrike = true;
        listOfBool[4] = true;
    }
    public void skill1()
    {
        points.skillPoints--;
        pointInSkill1 = true;
        listOfBool[5] = true;
    }
    public void skill2()
    {
        points.skillPoints--;
        pointInSkill2 = true;
        listOfBool[6] = true;
    }
    public void skill3()
    {
        points.skillPoints--;
        pointInSkill3 = true;
        listOfBool[7] = true;
    }
    public void LoadData(Save save)
    {
        pointInFirstSkill = save.SavesOfBool[0];
        pointInSecondSkill = save.SavesOfBool[1];
        pointInFightOrRunSkill = save.SavesOfBool[2];
        pointInFreez = save.SavesOfBool[3];
        pointInCriticalStrike = save.SavesOfBool[4];
        pointInSkill1 = save.SavesOfBool[5];
        pointInSkill2 = save.SavesOfBool[6];
        pointInSkill3 = save.SavesOfBool[7];
    }
}
