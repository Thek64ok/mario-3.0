using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseEnter : MonoBehaviour
{
    public Text[] text;
    public GameObject trap;
    void Start()
    {
        trap.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        text[0].text = "Путь Мечника";
        text[1].text = "Стоимость: 1 очко навыка";
        text[2].text = "Меч наделяется благословением солнца, что даёт прибавку к урону против нежити +20% от текущего урона меча";
        text[3].text = "Что может быть лучше побежденной нежити?\n " + " - спросили рыцаря\n" + " Две побежденные нежити";
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
