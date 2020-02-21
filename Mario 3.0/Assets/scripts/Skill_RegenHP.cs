using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill_RegenHP : MonoBehaviour
{
    public GameObject knight;
    private wasd knightFromSkript;
    public float coolDown;
    public bool coolDownOver;
    public Image imageCoolDown;

    private Knight_HealthSystem regenSkill;
    private float timeForCoolDown;
    void Start()
    {
        knightFromSkript = knight.gameObject.GetComponent<wasd>();
        coolDownOver = true;

        regenSkill = knight.GetComponent<Knight_HealthSystem>();
        timeForCoolDown = coolDown;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (coolDownOver && regenSkill.knightCurrentMana > 30f)
            {
                regenSkill.regenHP = 0.05f;
                coolDownOver = false;
                regenSkill.knightCurrentMana -= 30f;
            }
        }
        if (!coolDownOver)
        {
            coolDown -= Time.deltaTime;
            //imageCoolDown.fillAmount += 1 / timeForCoolDown * Time.deltaTime;
            //if (imageCoolDown.fillAmount >= 1) imageCoolDown.fillAmount = 0;
            regenSkill.RegenerationHP();
        }
        if (coolDown < 0)
        {
            regenSkill.regenHP = 0;
            coolDownOver = true;
            coolDown = 5f;
        }    
    }
    public bool GetCoolDownOver()
    {
        return coolDownOver;
    }
}
