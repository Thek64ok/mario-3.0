using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FromUnder : MonoBehaviour
{
    public GameObject Spider;
    public Animator anim;
    private Transform Knight;
    public float TimeOf;
    private float TimeOffCurrent;
    void Start()
    {
        Spider.SetActive(false);
        anim = GetComponent<Animator>();
        Knight = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        TimeOffCurrent = TimeOf;
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, Knight.position) < 2.7)
        {
            anim.SetBool("CloseUp", true);
            TimeOffCurrent -= Time.deltaTime;
        }
        if (TimeOffCurrent < 0)
        {
            Spider.SetActive(true);
            anim.SetBool("CloseUp", false);
        }
    }
}
