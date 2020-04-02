using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight_Hurt : MonoBehaviour
{
    // Start is called before the first frame update
    public int damageToGive;
    public int currentDamageToGive;
    public bool checkDamage;
    private float chance;
    public bool stunned;
    public float timer;
    public float cooldown;
    public AudioClip footstap;
    public Animator anim;

    void Start()
    {
        timer = cooldown;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (stunned)
            timer -= Time.deltaTime;
        if (timer <= 0)
        {
            damageToGive = 7;
            stunned = false;
            anim.SetBool("Freez", stunned);
        }
        if (!stunned)
            timer = cooldown;
        currentDamageToGive = damageToGive;
    }

    /*
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Knight_HealthSystem>().HurtKnight(currentDamageToGive);
            checkDamage = true;
        }
    }
    */
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Knight_HealthSystem>().HurtKnight(currentDamageToGive);
            checkDamage = true;
        }
    }
    
    public void Stun(float toStun)
    {
        chance = toStun;
        if (chance <= 94)
        {
            Debug.Log("я ne в стане");
        }
        else
        {
            damageToGive = 0;
            stunned = true;
            anim.SetBool("Freez", stunned);
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            checkDamage = false;
            AudioSource.PlayClipAtPoint(footstap, transform.position);
        }
    }
}
