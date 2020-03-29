using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthMeneger : MonoBehaviour
{
    // Start is called before the first frame update
    public int MaxHealth;
    public int CurrentHealth;
    public int expGive;
    private knightStats stats;
    void Start()
    {
        CurrentHealth = MaxHealth;
        stats = FindObjectOfType<knightStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentHealth <= 0)
        {
            Destroy(gameObject);
            if (PlayerPrefs.GetInt("Quest1") == 1)
            {
                PlayerPrefs.SetInt("Quest1", 2);
            }
            stats.AddExp(expGive);
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
