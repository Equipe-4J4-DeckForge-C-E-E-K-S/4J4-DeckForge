using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
// using static UnityEditor.PlayerSettings;

public class comportementRecompenseCarte : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject btnAjoutRecompense;
    public GameObject btnAnnulerRecompense;
    public GameObject btnSauterRecompense;
    public GameObject grilleRecompense;
    public GameObject carteZoom;
    public GameObject instructions;
    public GameObject prefab;
    public GameObject imgButton;

    public GameObject fin;

    public Sprite spriteCarte;

    public float posYInitial;
    public float scaleInitial;
    public float scale;
    public float hauteur;

    public bool survole;

    // Start is called before the first frame update
    void Start()
    {
        scale = scaleInitial;
        spriteCarte = imgButton.GetComponent<Image>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (survole && fin.GetComponent<comportementFin>().peutSurvole)
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
    }

    public void ReactionClic()
    {
        if (fin.GetComponent<comportementFin>().peutSurvole == true)
        {
            fin.GetComponent<comportementFin>().peutSurvole = false;
            btnAjoutRecompense.GetComponent<comportementRecompenseBouton>().prefabADuplique = prefab;
            carteZoom.GetComponent<Image>().sprite = spriteCarte;
            btnSauterRecompense.SetActive(false);
            instructions.SetActive(false);
            btnAjoutRecompense.SetActive(true);
            btnAnnulerRecompense.SetActive(true);
            carteZoom.SetActive(true);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        posYInitial = GetComponent<RectTransform>().anchoredPosition.y;
        survole = true;
        if (fin.GetComponent<comportementFin>().peutSurvole)
        {
            imgButton.GetComponent<Image>().color = new Color32(190, 190, 190, 255);
        }
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
