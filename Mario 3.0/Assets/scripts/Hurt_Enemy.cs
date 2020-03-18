﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurt_Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public int damageToGive;
    public GameObject blood;
    public Transform hitPoint;
    public GameObject damageNumber1;
    public GameObject knight;
    private wasd ataka;
    private loadSkillTreeScen freez;
    private int chanceToStun;
    public float timer, cooldown;
    public bool stunned;
    public bool dayn;
    void Start()
    {
        ataka = knight.GetComponent<wasd>();
        freez = FindObjectOfType<loadSkillTreeScen>();
        timer = cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (stunned)
            timer -= Time.deltaTime;
        if (timer <= 0)
        {
            gameObject.GetComponent<EnemyPatrol>().speed = gameObject.GetComponent<EnemyPatrol>().currentSpeed;
            gameObject.GetComponent<Knight_Hurt>().damageToGive = gameObject.GetComponent<Knight_Hurt>().currentDamageToGive;
            stunned = false;
        }
        if (!stunned)
            timer = cooldown;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (ataka.attacking == true)
        {
            if (other.gameObject.tag == "Enemy")
            {
                chanceToStun = Random.Range(1, 100);
                Debug.Log(chanceToStun);
                other.gameObject.GetComponent<EnemyHealthMeneger>().HurtEnemy(damageToGive);
                Instantiate(blood, hitPoint.position, hitPoint.rotation);
                var clone = (GameObject)Instantiate(damageNumber1, hitPoint.position, Quaternion.Euler(Vector3.zero));
                clone.GetComponent<Numbers_of_damage>().damageNumber2 = damageToGive;
                if (freez.pointInFreez == true)
                {
                    if (chanceToStun <= 10)
                    {
                        other.gameObject.GetComponent<EnemyPatrol>().speed = other.gameObject.GetComponent<EnemyPatrol>().currentSpeed;
                        other.gameObject.GetComponent<Knight_Hurt>().damageToGive = other.gameObject.GetComponent<Knight_Hurt>().currentDamageToGive;
                        dayn = true;
                    }
                    else
                    {
                        other.gameObject.GetComponent<EnemyPatrol>().speed = 0;
                        other.gameObject.GetComponent<Knight_Hurt>().damageToGive = 0;
                        stunned = true;
                    }
                }
            }
        }
    }
}
