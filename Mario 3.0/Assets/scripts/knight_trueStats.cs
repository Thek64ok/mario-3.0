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
        strength = 30;
        agility = 30;
        intelligence = 30;
        endurance = 30;
        HealthSys = FindObjectOfType<Knight_HealthSystem>();
        wasdSys = FindObjectOfType<wasd>();
        StartAttribute();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void StartAttribute(){
        HealthSys.SetMaxHealth((strength + endurance) / 2);
        HealthSys.SetMaxMana(intelligence + 10);
        HealthSys.SetMaxStamina(endurance + strength + agility);
        HealthSys.SetRegenerationMana(intelligence * 0.0015f);
        HealthSys.SetRegenerationStamina((strength + agility + endurance)*0.001f);
    }
    void funk2()
    {
        
    }
}
