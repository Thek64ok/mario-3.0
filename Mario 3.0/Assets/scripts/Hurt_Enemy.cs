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
    private loadSkillTreeScen LoadSkill;
    void Start()
    {
        ataka = knight.GetComponent<wasd>();
        LoadSkill = FindObjectOfType<loadSkillTreeScen>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (ataka.attacking == true)
        {
            if (other.gameObject.tag == "Enemy")
            {
                int damage = critical_damage();
                other.gameObject.GetComponent<EnemyHealthMeneger>().HurtEnemy(damage);
                //other.gameObject.GetComponent<EnemyHealthMeneger>().HurtEnemy(damageToGive);
                Instantiate(blood, hitPoint.position, hitPoint.rotation);
                var clone = (GameObject)Instantiate(damageNumber1, hitPoint.position, Quaternion.Euler(Vector3.zero));
                //clone.GetComponent<Numbers_of_damage>().damageNumber2 = damageToGive;
                clone.GetComponent<Numbers_of_damage>().damageNumber2 = damage;
            }
        }
    }
    public int critical_damage()
    {
        int originalDamage = damageToGive;
        int currentDamage = damageToGive;
        if(LoadSkill.pointInCriticalStrike)
        {
            Debug.Log("CRITICAL STRIKE RABOTAET");
            int r = Random.Range(0, 100);
            if(r <= 10)
            {
                currentDamage = currentDamage + 5;
                return currentDamage;
            }
            if(r >= 11)return originalDamage;
            return originalDamage;
        }
        else return originalDamage;
    }
}
