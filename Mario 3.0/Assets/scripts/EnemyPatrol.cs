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

    void Start()
    {
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anim = GetComponent<Animator>();
        rb2 = GetComponent<Rigidbody2D>();
        DirectPos = transform.position;
        oldPosition = transform.position;
    }

    void Update()
    {
        /*
        
            */
        if(transform.position != oldPosition)
        {
            Debug.Log("Test");
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
                    // if (transform.position.x < 0)                    
                    // {
                    //     anim.SetFloat("MoveX", -1f);
                    // }
                    // else
                    // {
                    //     anim.SetFloat("MoveX", 1f);
                    // }
                }
                else
                    waitTime -= Time.deltaTime;
            }
        }
        if (Vector2.Distance(transform.position, target.position) < 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            Detected = true;
            anim.SetFloat("MoveX", target.position.x - transform.position.x);
            anim.SetFloat("MoveY", target.position.y - transform.position.y);
        }
        else
        if (Vector2.Distance(transform.position, target.position) > 2)
        {
            Detected = false;
        }
    }
}
