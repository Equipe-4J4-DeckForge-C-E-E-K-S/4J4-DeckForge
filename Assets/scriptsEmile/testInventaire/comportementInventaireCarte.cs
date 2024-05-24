using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings;

public class comportementInventaireCarte : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject btnInventaire;
    public GameObject grilleInventaire;
    public int indexInventaire;
    public GameObject carteZoom;
    public GameObject prefab;
    public GameObject imgButton;

    public Sprite spriteCarte;

    public float posYInitial;
    public float scaleInitial;
    public float scale;
    public float hauteur;

    public bool survole;
    public bool debug;

    // Start is called before the first frame update
    void Start()
    {
        scale = scaleInitial;
        spriteCarte = imgButton.GetComponent<Image>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (survole && (grilleInventaire.GetComponent<comportementInventaire>().peutMontrerBtn == false))
        {
            Vector2 pos = GetComponent<RectTransform>().anchoredPosition;

            if (scale < (scaleInitial * 1.1f))
            {
                scale += (1f * Time.deltaTime);
                GetComponent<RectTransform>().localScale = new Vector3(scale, scale, scale);
            }
            else if (scale > (scaleInitial * 1.1f))
            {
                scale = (scaleInitial * 1.1f);
            }

            if ((pos.y - posYInitial) < 35f)
            {
                hauteur = 120f;
                pos.y += hauteur * Time.deltaTime;
                GetComponent<RectTransform>().anchoredPosition = new Vector2(pos.x, pos.y);
            }
            else if ((pos.y - posYInitial) > 35f)
            {
                GetComponent<RectTransform>().anchoredPosition = new Vector2(pos.x, (posYInitial + 35f));
            }
        }

        if (debug)
        {
            Vector2 pos = GetComponent<RectTransform>().anchoredPosition;
            GetComponent<RectTransform>().anchoredPosition = new Vector2(pos.x, posYInitial + hauteur);
        }
    }

    public void ReactionClic()
    {
        Debug.Log(btnInventaire);
        grilleInventaire.GetComponent<comportementInventaire>().peutMontrerBtn = true;
        btnInventaire.GetComponent<comportementInventaireBouton>().prefabADuplique = prefab; // A ENLEVER
        btnInventaire.GetComponent<comportementInventaireBouton>().indexASupprime = indexInventaire;
        carteZoom.GetComponent<Image>().sprite = spriteCarte;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        posYInitial = GetComponent<RectTransform>().anchoredPosition.y;
        survole = true;
        imgButton.GetComponent<Image>().color = new Color32(190, 190, 190, 255);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Vector2 pos = GetComponent<RectTransform>().anchoredPosition;
        survole = false;
        scale = scaleInitial;
        GetComponent<RectTransform>().localScale = new Vector3(scaleInitial, scaleInitial, scaleInitial);
        GetComponent<RectTransform>().anchoredPosition = new Vector2(pos.x, posYInitial);
        imgButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
    }
}
