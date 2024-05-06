using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class carteProfil : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool attaquer;
    public bool bloquer;
    public bool soigner;
    public GameObject prefab;

    public Image imgButton;

    public int index;

    public bool typeBasique;
    public bool typeEau;
    public bool typeFeu;
    public bool typePlante;



    public void OnPointerEnter(PointerEventData eventData)
    {
        imgButton.GetComponent<Image>().color = new Color32(190, 190, 190, 255);
        Debug.Log("Mouse enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        imgButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        Debug.Log("Mouse exit");
    }
}