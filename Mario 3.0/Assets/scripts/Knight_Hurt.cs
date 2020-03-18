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

    void Start()
    {
        checkD = knight.GetComponent<wasd>();
        rPoint = pointR.GetComponent<pointRight>();
        lPoint = pointL.GetComponent<pointLeft>();
        uPoint = pointU.GetComponent<pointUp>();
        dPoint = pointD.GetComponent<pointDown>();
    }

    // Update is called once per frame
    void Update()
    {
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
            /*
            if (Physics2D.OverlapPoint(pointRight.transform.position))
                checkD.myrigidbody2D.AddForce(Vector2.left * 5f, ForceMode2D.Impulse);
            else
            {
                if (Physics2D.OverlapPoint(pointLeft.transform.position))
                    checkD.myrigidbody2D.AddForce(Vector2.right * 5f, ForceMode2D.Impulse);
            }
            */
        }
        /*
        if (gameObject.transform.position.x + checkD.transform.position.x < 0)
        if (checkDamage)
            checkD.myrigidbody2D.AddForce(gameObject.transform.position /2f, ForceMode2D.Impulse);
            */
        /*
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
        */
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Knight")
        {
            other.gameObject.GetComponent<Knight_HealthSystem>().HurtKnight(currentDamageToGive);
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
