using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight_HealthSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public float knightMaxHealth;
    public float knightCurrentHealth;
    public float regenHP;
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
    public SpecialAttack skillToss;
    private fireArea hideGUI;
    public HMSBarScript hpBar;
    public HMSBarScript mpBar;
    public HMSBarScript spBar;
    void Start()
    {
        knightCurrentHealth = knightMaxHealth; 
        knightCurrentStamina = knightMaxStamina;
        knightCurrentMana = knightMaxMana;
        sprint = dayn1.GetComponent<wasd>();
        skillToss = dayn1.GetComponent<SpecialAttack>();
        hideGUI = FindObjectOfType<fireArea>();
        hpBar.SetMaxValue(knightMaxHealth);
        mpBar.SetMaxValue(knightMaxMana);
        spBar.SetMaxValue(knightMaxStamina);
    }

    // Update is called once per frame
    void Update()
    {
        hpBar.SetCurrentValue(knightCurrentHealth);
        mpBar.SetCurrentValue(knightCurrentMana);
        spBar.SetCurrentValue(knightCurrentStamina);
        if (knightCurrentHealth <= -10)
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
      
        if (knightCurrentMana < 0) knightCurrentMana = 0;
        if (knightCurrentStamina < 0) knightCurrentStamina = 0;
        if (knightCurrentStamina < 5)
        {
            sprint.currentMoveSpeed = 0.6f;
        }
    }
    public void SetActiveGUI(bool boolean)
    {
        dayn1.gameObject.SetActive(boolean);
    }
    public void HurtKnight(int damageToGive)
    {
        knightCurrentHealth -= damageToGive;
    }
    /*
    public void Back(bool checkDamage)
    {
        if (checkDamage)
        {
            //knightCurrentHealth = 200;
            rigidbody2D.AddForce(Vector2.left * 200f + 400f * rigidbody2D.velocity.normalized, ForceMode2D.Impulse);
        }
        else
            rigidbody2D.AddForce(Vector2.right * 200f + 400f * rigidbody2D.velocity.normalized, ForceMode2D.Impulse);
            //knightCurrentHealth = 100;
    }
    */

    public void SetMaxHealth(float max)
    {
        knightMaxHealth = max;
        knightCurrentHealth = knightMaxHealth;
    }
    public void RegenerationHP()
    {
        knightCurrentHealth += regenHP;
        if(knightCurrentHealth > knightMaxHealth) knightCurrentHealth = knightMaxHealth;
    }
    public void SetMaxStamina(float max)
    {
        knightMaxStamina = max;
        knightCurrentStamina = knightMaxStamina;
    }
    public void SetRegenerationMana(float max)
    {
        regenMana = max;
    }
    public void SetRegenerationStamina(float max)
    {
        regenStamina = max;
    }
    public void SetMaxMana(float max)
    {
        knightMaxMana = max;
        knightCurrentMana = knightMaxMana;
    }

}
