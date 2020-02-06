using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight_HealthSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public int knightMaxHealth;
    public int knightCurrentHealth;
    public Texture2D texHealth;
    void Start()
    {
        knightCurrentHealth = knightMaxHealth; 
    }

    // Update is called once per frame
    void Update()
    {
        if (knightCurrentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
    void OnGUI()
    {
        GUI.Box(new Rect(40,Screen.height-127,(knightMaxHealth*10)/2,20),"");
        GUI.DrawTexture(new Rect(40,Screen.height-127,(knightCurrentHealth*10)/2,20),texHealth);
    }

    public void HurtKnight(int damageToGive)
    {
        knightCurrentHealth -= damageToGive;
    }
    public void SetMaxHealth()
    {
        knightCurrentHealth = knightMaxHealth;
    }
}
