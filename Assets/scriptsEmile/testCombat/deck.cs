using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class deck : MonoBehaviour
{
    public GameObject librairie;
    public Transform canvas;
    public GameObject carteADupliquer;
    public GameObject carteDupliquee;

    public GameObject[] deckStatDebug;
    static GameObject[] deckStat;


    public GameObject[] deckLoc;
    public GameObject[] deckTrash;
    public GameObject[] deckActuel;

    public TextMeshProUGUI compteur;
    public bool tourJoueur;
    public bool tourJoueurCommence;
    public int nbCartesDonnees;

    //800w  340h

    void Start()
    {
        deckStat = deckStatDebug;
        deckLoc = deckStat;
        deckActuel = deckLoc;
    }

    // Update is called once per frame
    void Update()
    {
        compteur.text = deckActuel.Length.ToString();
        if (tourJoueur)
        {
            if (tourJoueurCommence)
            {
                CommenceTourJoueur();
            }
        }
    }

    public void CommenceTourJoueur()
    {
        tourJoueurCommence = false;
        for (int carte = 0; carte < nbCartesDonnees; carte++)
        {
            Debug.Log("oki");
            /*GameObject*/ carteADupliquer = deckActuel[carte];
            Vector2 pos;
            carteDupliquee = Instantiate(carteADupliquer, canvas);
            //pos.x = -200f + (50f * carte);
            //pos.y = -110;
            //carteDupliquee.GetComponent<RectTransform>().anchoredPosition = new Vector2(pos.x, pos.y);
        }
    }
}
