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
    private Transform target;
    void Start()
    {
        knightFromSkript = knight.gameObject.GetComponent<wasd>();
        coolDownOver = true;
        coolDownForSkill = coolDown;
        target = GameObject.FindGameObjectWithTag("a").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (coolDownOver)
            {
                if (Input.GetAxisRaw("Horizontal") > 0.5f)
                    if (Vector2.Distance(knight.transform.position, target.transform.position) < 1.5f)
                        target.transform.position = new Vector2(target.transform.position.x + 1.5f, target.transform.position.y);
                if (Input.GetAxisRaw("Horizontal") < 0.5f)
                    if(Vector2.Distance(knight.transform.position, target.transform.position) < 1.5f)
                        target.transform.position = new Vector2(target.transform.position.x - 1.5f, target.transform.position.y);
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
            coolDown = 5;
        }
    }
    public bool GetCoolDownOver()
    {
        return coolDownOver;
    }
}
