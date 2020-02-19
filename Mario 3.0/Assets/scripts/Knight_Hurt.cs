using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight_Hurt : MonoBehaviour
{
    // Start is called before the first frame update
    public int damageToGive;
    public bool checkDamage;
    public GameObject knight;
    private wasd checkD;
    void Start()
    {
        checkD = knight.GetComponent<wasd>();
    }

    // Update is called once per frame
    void Update()
    {
        if (checkDamage)
        {
            if (checkD.lastMove.x > 0)
                checkD.myrigidbody2D.AddForce(Vector2.left * 10f + 15f * checkD.myrigidbody2D.velocity.normalized, ForceMode2D.Impulse);
            else
            {
                if (checkD.lastMove.x < 0)
                    checkD.myrigidbody2D.AddForce(Vector2.right * 10f + 15f * checkD.myrigidbody2D.velocity.normalized, ForceMode2D.Impulse);
                else
                {
                    if (checkD.lastMove.y > 0)
                        checkD.myrigidbody2D.AddForce(Vector2.down * 10f + 15f * checkD.myrigidbody2D.velocity.normalized, ForceMode2D.Impulse);
                    else
                        checkD.myrigidbody2D.AddForce(Vector2.up * 10f + 15f * checkD.myrigidbody2D.velocity.normalized, ForceMode2D.Impulse);
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Knight")
        {
            other.gameObject.GetComponent<Knight_HealthSystem>().HurtKnight(damageToGive);
            checkDamage = true;
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
