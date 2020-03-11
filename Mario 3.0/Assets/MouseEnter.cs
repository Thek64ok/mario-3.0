using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseEnter : MonoBehaviour
{
    public GameObject trap;
    void Start()
    {
        trap.SetActive(false);
    }
    public void OnMouseEnter()
    {
        trap.SetActive(true);
    }
    public void OnMouseExit()
    {
        trap.SetActive(false);
    }
}
