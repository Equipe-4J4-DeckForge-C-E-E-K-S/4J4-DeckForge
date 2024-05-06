using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings;

public class carteProfil : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool attaquer;
    public bool bloquer;
    public bool soigner;
    public GameObject prefab;

    public Image imgButton;

    public int index;
    public int indexSiblingInitial;

    public bool typeBasique;
    public bool typeEau;
    public bool typeFeu;
    public bool typePlante;

    public float posXinitial;
    public float posYinitial;

    public bool survole;

    public float scale = 3;
    public float hauteur;

    void Update() 
    {
        if (survole)
        {
            if (scale < 3.3f)
            {
                scale += (1f * Time.deltaTime);
                GetComponent<RectTransform>().localScale = new Vector3(scale, scale, scale);
            }
            else if (scale > 3.3f)
            {
                scale = 3.3f;
            }
            
            if (hauteur < 10f)
            {
               Vector2 pos = GetComponent<RectTransform>().anchoredPosition;
               hauteur += (4f * Time.deltaTime);
               pos.y += hauteur;
               GetComponent<RectTransform>().anchoredPosition = new Vector2(pos.x, pos.y);
            }
            else if (hauteur > 10f)
            {
                hauteur = 10;
                GetComponent<RectTransform>().anchoredPosition = new Vector2(posXinitial, posYinitial + 10f);
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        survole = true;
        imgButton.GetComponent<Image>().color = new Color32(190, 190, 190, 255);
        transform.SetSiblingIndex(100);
        Debug.Log("Mouse enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        survole = false;
        scale = 3f;
        hauteur = 0f;
        GetComponent<RectTransform>().localScale = new Vector3(3,3,3);
        GetComponent<RectTransform>().anchoredPosition = new Vector2(posXinitial, posYinitial);
        transform.SetSiblingIndex(indexSiblingInitial);
        imgButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        Debug.Log("Mouse exit");
    }
}