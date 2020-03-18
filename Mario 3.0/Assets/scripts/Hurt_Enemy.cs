using System.Collections;
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
    private loadSkillTreeScen LoadSkill;
    private int chanceToStun;
    public float timer, cooldown;
    public bool stunned;
    private EnemyPatrol moveSpeed;
    private Knight_Hurt damageGiven;
    void Start()
    {
        ataka = knight.GetComponent<wasd>();
        freez = FindObjectOfType<loadSkillTreeScen>();
        moveSpeed = FindObjectOfType<EnemyPatrol>();
        damageGiven = FindObjectOfType<Knight_Hurt>();
        LoadSkill = FindObjectOfType<loadSkillTreeScen>();
        timer = cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (stunned)
            timer -= Time.deltaTime;
        if (timer <= 0)
        {
            moveSpeed.speed = 0.18f;
            damageGiven.damageToGive = 7;
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
                int damage = critical_damage();
                chanceToStun = Random.Range(1, 100);
                Debug.Log(chanceToStun);
                other.gameObject.GetComponent<EnemyHealthMeneger>().HurtEnemy(damage);
                Instantiate(blood, hitPoint.position, hitPoint.rotation);
                var clone = (GameObject)Instantiate(damageNumber1, hitPoint.position, Quaternion.Euler(Vector3.zero));
                clone.GetComponent<Numbers_of_damage>().damageNumber2 = damage;
                if (freez.pointInFreez == true)
                {
                    if (chanceToStun <= 10)
                    {
                        other.gameObject.GetComponent<EnemyPatrol>().speed = 0.18f;
                        other.gameObject.GetComponent<Knight_Hurt>().damageToGive = 7;
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
