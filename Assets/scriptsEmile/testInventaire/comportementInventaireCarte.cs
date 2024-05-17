using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class comportementInventaireCarte : MonoBehaviour
{
    public GameObject btnInventaire;
    public GameObject carteZoom;
    public GameObject prefab;
    public GameObject imgButton;

    public float posYInitial;
    public float scaleInitial;
    public float scale;
    public float hauteur;

    public bool survole;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = GetComponent<RectTransform>().anchoredPosition;
        if (survole)
        {
            if (scale < (scaleInitial * 1.1f))
            {
                scale += (1f * Time.deltaTime);
                GetComponent<RectTransform>().localScale = new Vector3(scale, scale, scale);
            }
            else if (scale > (scaleInitial * 1.1f))
            {
                scale = (scaleInitial * 1.1f);
            }

            if ((pos.y - posYInitial) < 70f)
            {
                hauteur += (10f * Time.deltaTime);
                pos.y += hauteur;
                GetComponent<RectTransform>().anchoredPosition = new Vector2(pos.x, pos.y);
            }
            else if ((pos.y - posYInitial) > 70f)
            {
                hauteur = 70f;
                GetComponent<RectTransform>().anchoredPosition = new Vector2(pos.x, (posYInitial + 70f));
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        survole = true;
        //imgButton.GetComponent<Image>().color = new Color32(190, 190, 190, 255);
        transform.SetSiblingIndex(100);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Vector2 pos = GetComponent<RectTransform>().anchoredPosition;
        survole = false;
        scale = 0f;
        hauteur = 0f;
        GetComponent<RectTransform>().localScale = new Vector3(scaleInitial, scaleInitial, scaleInitial);
        GetComponent<RectTransform>().anchoredPosition = new Vector2(pos.x, posYInitial);
        //imgButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
    }
}
}
