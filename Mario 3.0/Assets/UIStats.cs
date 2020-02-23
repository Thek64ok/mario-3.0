using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStats : MonoBehaviour
{
    // Start is called before the first frame update
    public Text currentLvl;
    public Text currentExp;
    private knightStats stats;
    void Start()
    {
        stats = GetComponent<knightStats>();
    }

    // Update is called once per frame
    void Update()
    {
        currentLvl.text = "Lvl: " + stats.currentLvl;
        currentExp.text = "Exp: " + stats.cureentExp + "/" + stats.toLevelUp[stats.currentLvl];
    }
}
