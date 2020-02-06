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
        GUI.Box(new Rect((Screen.width/2)-150, Screen.height - 50, (knightMaxHealth * 10) / 2, 15), "");
        GUI.DrawTexture(new Rect((Screen.width/2)-150, Screen.height - 50, (knightCurrentHealth * 10) / 2, 15), texHealth);
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
