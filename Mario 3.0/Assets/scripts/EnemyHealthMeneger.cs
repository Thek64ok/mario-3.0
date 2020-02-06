using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthMeneger : MonoBehaviour
{
    // Start is called before the first frame update
    public int MaxHealth;
    public int CurrentHealth;
  //  public Texture2D texHealth;
    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    /*
    void OnGUI()
    {
        GUI.Box(new Rect(600, Screen.height - 200, (knightMaxHealth * 10) / 2, 10), "");
        GUI.DrawTexture(new Rect(600, Screen.height - 200, (knightCurrentHealth * 10) / 2, 10), texHealth);
    }
    */
    public void HurtEnemy(int damageToGive)
    {
        CurrentHealth -= damageToGive;
    }
    public void SetMaxHealth()
    {
       CurrentHealth = MaxHealth;
    }
}
