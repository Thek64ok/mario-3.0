using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed;
    private float waitTime;
    public float startWaitTime;
    public Transform[] moveSpots;
    private int randomSpot;
    private Transform target;
    private bool Detected;
    public Animator anim;
    private Rigidbody2D rb2;
    private Vector3 oldPosition;
    private Vector3 DirectPos;
    private float chanceStan;
    private float timer;
    public float cooldown;
    public bool stunned;

    void Start()
    {
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anim = GetComponent<Animator>();
        rb2 = GetComponent<Rigidbody2D>();
        DirectPos = transform.position;
        oldPosition = transform.position;
        timer = cooldown;
    }

    void Update()
    {
        if (stunned)
            timer -= Time.deltaTime;
        if (timer <= 0)
        {
            stunned = false;
            speed = 0.18f;
        }
        if (!stunned)
            timer = cooldown;
        if(transform.position != oldPosition)
        {
            DirectPos = transform.position - oldPosition;
            oldPosition = transform.position;
        }
        if (!Detected)
        {
            
            transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
            if (DirectPos.x < 0)                    
            {
                anim.SetFloat("MoveX", -1f);
            }
            else
            {
                anim.SetFloat("MoveX", 1f);
            }
            if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
            {
                if (waitTime <= 0)
                {
                    randomSpot = Random.Range(0, moveSpots.Length);
                    waitTime = startWaitTime;
                }
                else
                    waitTime -= Time.deltaTime;
            }
        }
        if (Vector2.Distance(transform.position, target.position) < 1f)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            Detected = true;
            anim.SetFloat("MoveX", target.position.x - transform.position.x);
            anim.SetFloat("MoveY", target.position.y - transform.position.y);
        }
        else
        if (Vector2.Distance(transform.position, target.position) > 1.2f)
        {
            Detected = false;
        }
    }
    public void Stun(float toStun)
    {
        chanceStan = toStun;
        if (chanceStan <= 94)
        {
            Debug.Log("я ne в стане");
        }
        else
        {
            speed = 0;
            stunned = true;
        }
    }
}
