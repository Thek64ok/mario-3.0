using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight_Hurt : MonoBehaviour
{
    // Start is called before the first frame update
    public int damageToGive;
    public int currentDamageToGive;
    public bool checkDamage;
    public GameObject knight;
    public GameObject pointR;
    public GameObject pointL;
    public GameObject pointU;
    public GameObject pointD;
    private pointRight rPoint;
    private pointLeft lPoint;
    private pointUp uPoint;
    private pointDown dPoint;
    private wasd checkD;
    private float chance;
    public bool stunned;
    public float timer;
    public float cooldown;

    void Start()
    {
        checkD = knight.GetComponent<wasd>();
        rPoint = pointR.GetComponent<pointRight>();
        lPoint = pointL.GetComponent<pointLeft>();
        uPoint = pointU.GetComponent<pointUp>();
        dPoint = pointD.GetComponent<pointDown>();
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
        if (checkDamage)
        {
            if (rPoint.right == true)
                checkD.myrigidbody2D.AddForce(Vector2.left * 20f, ForceMode2D.Impulse);
            else
            {
                if (lPoint.left == true)
                    checkD.myrigidbody2D.AddForce(Vector2.right * 20f, ForceMode2D.Impulse);
                else
                {
                    if (uPoint.up == true)
                        checkD.myrigidbody2D.AddForce(Vector2.down * 20f, ForceMode2D.Impulse);
                    else
                    {
                        if (dPoint.down == true)
                            checkD.myrigidbody2D.AddForce(Vector2.up * 20f, ForceMode2D.Impulse);
                        else
                        {
                            if (rPoint.right == true && lPoint.left)
                                checkD.myrigidbody2D.AddForce(Vector2.right * 30f, ForceMode2D.Impulse);
                        }
                    }
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Knight")
        {
            other.gameObject.GetComponent<Knight_HealthSystem>().HurtKnight(currentDamageToGive);
            checkDamage = true;
        }
    }
    public void Stun(float toStun)
    {
        chance = toStun;
        if (chance <= 80)
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
        if (collision.gameObject.name == "Knight")
        {
            checkDamage = false;
        }
    }
}
