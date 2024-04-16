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
    public GameObject personnage;

    public GameObject[] deckStatDebug;
    static GameObject[] deckStat;


    public GameObject[] deckLoc;
    public GameObject[] deckTrash;
    public GameObject[] deckActuel;
    public GameObject[] deckJoueur;

    public TextMeshProUGUI compteurCartes;
    public TextMeshProUGUI compteurPoubelle;
    public bool tourJoueur;
    public bool tourEnnemi;
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
    public void CommenceTourJoueur()
    {
        tourJoueurCommence = false;
        for (int carte = 0; carte < nbCartesDonnees; carte++)
        {
            if (deckActuel.Length == 0 && deckTrash.Length >= 1)
            {
                Recharger();
            }

            if (deckActuel.Length > 0)
            {
                carteADupliquer = deckActuel[0];
                carteDupliquee = Instantiate(carteADupliquer, canvas);
                IdentifierCarte(carteDupliquee);
                deckJoueur = librairie.GetComponent<librairieDeck>().ajouterCarte(deckActuel, carteDupliquee);
                deckActuel = librairie.GetComponent<librairieDeck>().enleverCarte(deckActuel, 0);
            }
        }
        OrganiserDeckJoueur();
    }



    public void IdentifierCarte(GameObject carteAIdentifier)
    {
        if (carteAIdentifier.GetComponent<carteProfil>().attaquer)
        {
            carteAIdentifier.GetComponent<Attaque>().personnage = personnage;
            carteAIdentifier.GetComponent<Attaque>().librairie = librairie;
            carteAIdentifier.GetComponent<Attaque>().deck = gameObject;
        }
        else if (carteAIdentifier.GetComponent<carteProfil>().bloquer)
        {
            carteAIdentifier.GetComponent<Bloque>().personnage = personnage;
            carteAIdentifier.GetComponent<Bloque>().librairie = librairie;
            carteAIdentifier.GetComponent<Bloque>().deck = gameObject;
            carteAIdentifier.GetComponent<Bloque>().estClique = true;
        }
        else if (carteAIdentifier.GetComponent<carteProfil>().soigner)
        {
            carteAIdentifier.GetComponent<Soin>().personnage = personnage;
            carteAIdentifier.GetComponent<Soin>().librairie = librairie;
            carteAIdentifier.GetComponent<Soin>().deck = gameObject;
        }
    }


    public void OrganiserDeckJoueur()
    {
        float distanceEntreCartes = ((540 - (deckJoueur.Length * 20)) / (deckJoueur.Length + 1)) - 270;

        int index = 0;
        foreach (var carte in deckJoueur)
        {
            index++;
            Vector2 pos;
            pos.x = -270 + (distanceEntreCartes * index);
            pos.y = -110;
            carte.GetComponent<RectTransform>().anchoredPosition = new Vector2(pos.x, pos.y);
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
