using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skillPoints : MonoBehaviour
{
    public int skillToPoints;
    public Text text;
    void Start()
    {
        skillToPoints = PlayerPrefs.GetInt("skillPoints");
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Points: " + skillToPoints;
    }
}
