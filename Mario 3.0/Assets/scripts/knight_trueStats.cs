using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knight_trueStats : MonoBehaviour
{
    private int strength;
    private int agility;
    private int intelligence;
    private int endurance;
    public Knight_HealthSystem HealthSys;
    public wasd wasdSys;
    // Start is called before the first frame update
    void Start()
    {
        strength = 5;
        agility = 5;
        intelligence = 5;
        endurance = 5;
        HealthSys = FindObjectOfType<Knight_HealthSystem>();
        wasdSys = FindObjectOfType<wasd>();
        //funk();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void funk(){
        HealthSys.SetMaxHealth(strength * 2);
        HealthSys.SetMaxMana(intelligence * 2);
        HealthSys.SetMaxStamina(endurance * 2);
    }
    void funk2()
    {
        
    }
}
