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

    public TextMeshProUGUI compteurCartes;
    public TextMeshProUGUI compteurPoubelle;
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
        compteurCartes.text = deckActuel.Length.ToString();
        compteurPoubelle.text = deckTrash.Length.ToString();

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
        //Debug.Log(deckActuel.Length);
        for (int carte = 0; carte < nbCartesDonnees; carte++)
        {
            if (deckActuel.Length == 0 && deckTrash.Length >=1)
            {
                Recharger();
            }

            if(deckActuel.Length > 0)
            {
                carteADupliquer = deckActuel[0];
                Vector2 pos;
                carteDupliquee = Instantiate(carteADupliquer, canvas);
                pos.x = -200f + (150f * carte);
                pos.y = -110;
                carteDupliquee.GetComponent<RectTransform>().anchoredPosition = new Vector2(pos.x, pos.y);
                deckActuel = librairie.GetComponent<librairieDeck>().enleverCarte(deckActuel, 0);
            }
        }
    }


    public void Recharger()
    {
        if (deckTrash.Length > 0)
        {
            deckActuel = deckTrash;
            deckActuel = librairie.GetComponent<librairieDeck>().SufflerCartes(deckActuel);
        }
    }
}
