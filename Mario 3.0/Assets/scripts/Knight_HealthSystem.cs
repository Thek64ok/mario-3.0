using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight_HealthSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public int knightMaxHealth;
    public int knightCurrentHealth;
    void Start()
    {
        knightCurrentHealth = knightMaxHealth; 
    }

    // Update is called once per frame
    void Update()
    {
        if (knightCurrentHealth < 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void Heart(int damageToGive)
    {
        knightCurrentHealth -= damageToGive;
    }
    public void SetMaxHealth()
    {
        knightCurrentHealth = knightMaxHealth;
    }
}
