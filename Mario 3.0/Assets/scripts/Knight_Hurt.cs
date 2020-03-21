using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight_Hurt : MonoBehaviour
{
    // Start is called before the first frame update
    public int damageToGive;
    public int currentDamageToGive;
    public bool checkDamage;
    private pointRight right;
    private pointLeft left;
    private pointUp up;
    private pointDown down;
    private wasd rigidbodyKnight;
    private float chance;
    public bool stunned;
    public float timer;
    public float cooldown;
    public AudioClip footstap;

    void Start()
    {
        right = FindObjectOfType<pointRight>();
        left = FindObjectOfType<pointLeft>();
        up = FindObjectOfType<pointUp>();
        down = FindObjectOfType<pointDown>();
        rigidbodyKnight = FindObjectOfType<wasd>();
        timer = cooldown;
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
        }
        if (!stunned)
            timer = cooldown;
        currentDamageToGive = damageToGive;
        /*
        if (checkDamage)
        {
            if (right.right == true)
                rigidbodyKnight.myrigidbody2D.AddForce(Vector2.left * 20f, ForceMode2D.Impulse);
            else
            {
                if (left.left == true)
                    rigidbodyKnight.myrigidbody2D.AddForce(Vector2.right * 20f, ForceMode2D.Impulse);
                else
                {
                    if (up.up == true)
                        rigidbodyKnight.myrigidbody2D.AddForce(Vector2.down * 20f, ForceMode2D.Impulse);
                    else
                    {
                        if (down.down == true)
                            rigidbodyKnight.myrigidbody2D.AddForce(Vector2.up * 20f, ForceMode2D.Impulse);
                        /*
                        else
                        {
                            if (rPoint.right == true && lPoint.left)
                                checkD.myrigidbody2D.AddForce(Vector2.right * 30f, ForceMode2D.Impulse);
                        }
                        
                    }
                }
            }
        }
        */
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Knight_HealthSystem>().HurtKnight(currentDamageToGive);
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
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            checkDamage = false;
            AudioSource.PlayClipAtPoint(footstap, transform.position);
        }
    }
}
