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
    public GameObject prefabInventaire;
    public GameObject inventaire;
    public GameObject fin;

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
    public float hauteurDebug;

    void Update() 
    {
        Vector2 pos = GetComponent<RectTransform>().anchoredPosition;
        hauteurDebug = (pos.y - posYinitial);
        if (survole && ((inventaire.GetComponent<comportementInventaire>().inventaireEstMontre == false) || (fin.GetComponent<comportementFin>().finNiveau == false)))
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
            
            if ((pos.y-posYinitial) < 70f)
            {
               hauteur += (10f * Time.deltaTime);
               pos.y += hauteur;
               GetComponent<RectTransform>().anchoredPosition = new Vector2(pos.x, pos.y);
            }
            else if ((pos.y - posYinitial) > 70f)
            {;
                hauteur = 70f;
                GetComponent<RectTransform>().anchoredPosition = new Vector2(posXinitial, (posYinitial + 70f));
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (inventaire.GetComponent<comportementInventaire>().inventaireEstMontre == false)
        {
            survole = true;
            imgButton.GetComponent<Image>().color = new Color32(190, 190, 190, 255);
            transform.SetSiblingIndex(100);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        scale = 3f;
        hauteur = 0f;
        GetComponent<RectTransform>().localScale = new Vector3(3,3,3);
        GetComponent<RectTransform>().anchoredPosition = new Vector2(posXinitial, posYinitial);
        if (inventaire.GetComponent<comportementInventaire>().inventaireEstMontre == false)
        {
            survole = false;
            transform.SetSiblingIndex(indexSiblingInitial);
            imgButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
    }
}