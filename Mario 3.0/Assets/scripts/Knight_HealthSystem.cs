using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight_HealthSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public int knightMaxHealth;
    public int knightCurrentHealth;
    public Texture2D texHealth;
    public float knightMaxStamina;
    public float knightCurrentStamina;
    public float regenStamina;
    public Texture2D texStamina;

    void Start()
    {
        knightCurrentHealth = knightMaxHealth; 
        knightCurrentStamina = knightMaxStamina;
    }

    // Update is called once per frame
    void Update()
    {
        if (knightCurrentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
        if(knightCurrentStamina < knightMaxStamina)knightCurrentStamina = knightCurrentStamina + regenStamina;//Regen Stamina
        if(knightCurrentStamina > knightMaxStamina)knightCurrentStamina = knightMaxStamina;
        if(Input.GetKey(KeyCode.LeftShift) && knightCurrentStamina > 0.5f)
        {
            knightCurrentStamina = knightCurrentStamina - 0.5f;
        }
    }
    void OnGUI()
    {
        //texture HP
        GUI.Box(new Rect((Screen.width/2)-(knightMaxHealth), Screen.height - 50, knightMaxHealth*2, 15), "");
        GUI.DrawTexture(new Rect((Screen.width/2)-(knightMaxHealth), Screen.height - 50, knightCurrentHealth*2, 15), texHealth);
        //texture Stamina
        GUI.Box(new Rect((Screen.width)-(knightMaxStamina)-50, Screen.height - 50, knightMaxStamina, 15), "");
        GUI.DrawTexture(new Rect((Screen.width)-(knightCurrentStamina)-50, Screen.height - 50, knightCurrentStamina, 15), texStamina);
    }

    public void HurtKnight(int damageToGive)
    {
        knightCurrentHealth -= damageToGive;
    }
    public void SetMaxHealth()
    {
        knightCurrentHealth = knightMaxHealth;
    }
    public void SetMaxStamina()
    {
        knightCurrentStamina = knightMaxStamina;
    }
}
