using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Sprite activeCell;
    private Sprite cell;
    private Image img;
    void OnDisable()
    {
        img.sprite = cell;
    }
    void Start()
    {
        img = GetComponent<Image>();
        cell = img.sprite;
        img.sprite = cell;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        img.sprite = activeCell;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        img.sprite = cell;
    }
}
