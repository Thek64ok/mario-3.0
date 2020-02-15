using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialAttack : MonoBehaviour
{
    public GameObject knight;
    private wasd knightFromSkript;
    public float coolDown;
    private bool coolDownOver;
    public Image imageCoolDown;
    private float coolDownForSkill;
    void Start()
    {
        knightFromSkript = knight.gameObject.GetComponent<wasd>();
        coolDownOver = true;
        coolDownForSkill = coolDown;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (coolDownOver)
            {
                if (Input.GetAxisRaw("Horizontal") > 0.5f)
                    knightFromSkript.transform.position = new Vector2(transform.position.x + 0.3f, transform.position.y);
                else
                    knightFromSkript.transform.position = new Vector2(transform.position.x - 0.3f, transform.position.y);
                coolDownOver = false;
            }
           
        }
        if (coolDownOver == false)
        {
            coolDown -= Time.deltaTime;
            imageCoolDown.fillAmount += 1 / coolDownForSkill * Time.deltaTime;
            if (imageCoolDown.fillAmount >= 1)
                imageCoolDown.fillAmount = 0;
        }
        if (coolDown < 0)
        {
            coolDownOver = true;
            coolDown = 10;
        }
    }
}
