using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wasd : MonoBehaviour
{
    public float speed;
    public float currentMoveSpeed;
    public Animator anime;
    public bool moving;
    public Vector2 lastMove;
    public Rigidbody2D myrigidbody2D;
    public bool dayn;
    public GameObject Readl_Sword;
    public bool attacking;
    public float attackTime;
    private float attackTimeCounter;
    public GameObject FakeSword;
    private pointRight rr;
    private pointLeft ll;
    private pointUp uu;
    private pointDown dd;


    void Start()
    {   
        anime = GetComponent<Animator>();
        Readl_Sword.SetActive(false);
        myrigidbody2D = GetComponent<Rigidbody2D>();
        rr = FindObjectOfType<pointRight>();
        ll = FindObjectOfType<pointLeft>();
        uu = FindObjectOfType<pointUp>();
        dd = FindObjectOfType<pointDown>();
    }
    void Update()
    {
        moving = false;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 0.9f;
        }
        else
            speed = 0.6f;
        if (!attacking)
        {
            if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
            {
                myrigidbody2D.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * currentMoveSpeed, myrigidbody2D.velocity.y);
                moving = true;
                lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
            }
            if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
            {
                myrigidbody2D.velocity = new Vector2(myrigidbody2D.velocity.x, Input.GetAxisRaw("Vertical") * currentMoveSpeed);
                moving = true;
                lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
            }
            if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
            {
                myrigidbody2D.velocity = new Vector2(0f, myrigidbody2D.velocity.y);
            }
            if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
            {
                myrigidbody2D.velocity = new Vector2(myrigidbody2D.velocity.x, 0f);
            }
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (Readl_Sword.gameObject.activeInHierarchy == true)
                {
                    attackTimeCounter = attackTime;
                    attacking = true;
                    myrigidbody2D.velocity = Vector2.zero;
                    anime.SetBool("Attack", true);
                }
            }
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.5f && Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.5f)
            {
                currentMoveSpeed = speed / 1.3f;
            }
            else
            {
                currentMoveSpeed = speed;
            }
        }
        if (attackTimeCounter > 0)
        {
            attackTimeCounter -= Time.deltaTime * 5;
        }
        if (attackTimeCounter <= 0)
        {
            attacking = false;
            anime.SetBool("Attack", false);
        }
        anime.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anime.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anime.SetBool("Moving", moving);
        anime.SetFloat("LastMoveX", lastMove.x);
        anime.SetFloat("LastMoveY", lastMove.y);
        if (dayn == true)
        {
            anime.SetBool("tacking", dayn);
            Readl_Sword.SetActive(true);
        }
        else
        {
            anime.SetBool("tacking", dayn);
            Readl_Sword.SetActive(false);
            FakeSword.SetActive(true);
        }
        
        if (rr.right)
        {
            myrigidbody2D.AddForce(Vector2.left * 20f, ForceMode2D.Impulse);
        }
        if (ll.left)
            myrigidbody2D.AddForce(Vector2.right * 20f, ForceMode2D.Impulse);
        if (uu.up)
            myrigidbody2D.AddForce(Vector2.down * 20f, ForceMode2D.Impulse);
        if (dd.down)
            myrigidbody2D.AddForce(Vector2.up * 20f, ForceMode2D.Impulse);
    }
    public void SetSpeed(float max)
    {
        
    }
    public void LoadDate(Save.KnightSaveData save)
    {
        transform.position = new Vector2(save.Position.x, save.Position.y);
    }
}
