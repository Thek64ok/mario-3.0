using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knightStats : MonoBehaviour
{
    public int skillPoints;
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
        //skillPoints = currentLvl - 1;
        if (currentLvl == 1)
            skillPoints = 0;
        if (cureentExp >= toLevelUp[currentLvl])
        {
            currentLvl++;
            if (currentLvl > 1)
                skillPoints++;
        }
    }

    public void AddExp(int expAdd)
    {
        cureentExp += expAdd;
    }
    public void Points()
    {
        skillPoints -= 1;
    }
}
