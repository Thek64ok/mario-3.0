using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knightStats : MonoBehaviour
{
    public int currentLvl;
    public int cureentExp;
    public int[] toLevelUp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cureentExp >= toLevelUp[currentLvl])
            currentLvl++;
    }

    public void AddExp(int expAdd)
    {
        cureentExp += expAdd;
    }
}
