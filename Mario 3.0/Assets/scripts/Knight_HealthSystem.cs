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
    public GameObject dayn1;//forStamina
    private wasd sprint;
    public float knightMaxMana;
    public float knightCurrentMana;
    public float regenMana;
    public Texture2D texMana;
    public GameObject skills;//ForMana
    private SpecialAttack skillToss;
    void Start()
    {
        knightCurrentHealth = knightMaxHealth; 
        knightCurrentStamina = knightMaxStamina;
        knightCurrentMana = knightMaxMana;
        sprint = dayn1.GetComponent<wasd>();
        skillToss = skills.GetComponent<SpecialAttack>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (knightCurrentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
        if (knightCurrentStamina < knightMaxStamina)
        {
            knightCurrentStamina += regenStamina;//Regen Stamina
        }
        if (knightCurrentMana < knightMaxMana)
        {
            knightCurrentMana += regenMana;//Regen Mana
        }
        
        if(Input.GetKey(KeyCode.LeftShift) && knightCurrentStamina > 1)
        {
            knightCurrentStamina -= 0.2f;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (sprint.Readl_Sword.gameObject.activeInHierarchy == true)
                knightCurrentStamina -= 5f;
        }
        if(skillToss.GetCoolDownOver() && Input.GetKeyDown(KeyCode.Alpha1))
        {
            knightCurrentMana -= 20f;
        }
        if (knightCurrentStamina < 0)
            knightCurrentStamina = 0;
        if (knightCurrentStamina < 5)
        {
            sprint.currentMoveSpeed = 1f;
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
        //texture Mana
        GUI.Box(new Rect(100, Screen.height - 50, knightMaxMana, 15), "");
        GUI.DrawTexture(new Rect(100, Screen.height - 50, knightCurrentMana, 15), texMana);
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
    public void SetMaxMana()
    {
        knightCurrentMana = knightMaxMana;
    }

}
