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
    public float timeToCast = 1f;
    private Knight_HealthSystem regenSkill;
    private float timeForCoolDown;
    public GameObject health;
    public Transform pointOfHp;
    public ParticleSystem awake;
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
                awake.playOnAwake = true;
                timeToCast = 1f;
                regenSkill.regenHP = 0.05f;
                coolDownOver = false;
                regenSkill.knightCurrentMana -= 30f;
                Instantiate(health, pointOfHp.position, pointOfHp.rotation, pointOfHp);

            }
        }
        if (!coolDownOver)
        {
            knightFromSkript.currentMoveSpeed = 0.4f;
            timeToCast -= Time.deltaTime;
            coolDown -= Time.deltaTime;
            imageCoolDown.fillAmount += 1 / timeForCoolDown * Time.deltaTime;
            if (imageCoolDown.fillAmount >= 1) imageCoolDown.fillAmount = 0;
            regenSkill.RegenerationHP();
        }
        if (coolDown < 0 && timeToCast < 0)
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
