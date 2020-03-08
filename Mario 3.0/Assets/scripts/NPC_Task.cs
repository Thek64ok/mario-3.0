using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Task : MonoBehaviour
{
    public bool EndDialog;
    public GameObject Dialog1;
    public Quest_Event EE;
    void Start()
    {

    }

    void Update()
    {
        if (EndDialog == true)
        {
            Time.timeScale = 1;
            EE.Quest1 = true;
            Dialog1.SetActive(false);
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            Time.timeScale = 0;
            Dialog1.SetActive(true);
        }
    }
}

