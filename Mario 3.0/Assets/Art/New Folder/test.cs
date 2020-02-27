using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    private skillPoints points;
    public bool check;
    public Button button;
    void Start()
    {
        points = FindObjectOfType<skillPoints>();
    }

    // Update is called once per frame
    void Update()
    {
        if (check)
            button.enabled = false;
    }
    public void attackBust()
    {
        points.skillToPoints -= 1;
        check = true;
    }
}
