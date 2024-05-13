using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.U2D;

public class Deck : MonoBehaviour
{
    public GameObject librairie;
    public Transform canvas;
    public GameObject carteADupliquer;
    public GameObject carteDupliquee;
    public GameObject personnage;
    public GameObject btnContinuer;

    public GameObject[] deckStatDebug;
    public static GameObject[] deckStat;

    public GameObject[] deckFull;
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

    public float posYCarteJeu = -370f;
    public float ecartPourMettreCartes = 975f;
    public float posCarteDepart = -487.5f;

    public float difficulteDEBUG;


    //800w  340h

    void Start()
    {
        if (comportementGestionnaireEnnemi.difficulte <= 1)
        {
            for (int i = 0; i < 25; i++)
            {
                int carteAleatoireChoisie = Random.Range(0, deckFull.Length);
                GameObject carteChoisie = deckFull[carteAleatoireChoisie];
                deckStatDebug = librairie.gameObject.GetComponent<librairieDeck>().ajouterCarte(deckStatDebug, carteChoisie);
            }
            deckStat = deckStatDebug;
        }

        deckLoc = deckStat;
        deckActuel = deckLoc;
        deckActuel = librairie.GetComponent<librairieDeck>().SufflerCartes(deckActuel);
    }

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
        else
        {
            tourJoueurCommence = true;
        }
    }


    // Update is called once per frame
    public void CommenceTourJoueur()
    {
        personnage.GetComponent<statistiquesPersonnage>().defense = personnage.GetComponent<statistiquesPersonnage>().defenseInitiale;
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
                carteDupliquee.SetActive(true);
                deckJoueur = librairie.GetComponent<librairieDeck>().ajouterCarte(deckJoueur, carteDupliquee);
                deckActuel = librairie.GetComponent<librairieDeck>().enleverCarte(deckActuel, 0);
            }
        }
        OrganiserDeckJoueur();
    }



    public void IdentifierCarte(GameObject carteAIdentifier)
    {
        carteAIdentifier.GetComponent<comportementCarteDeck>().deck = gameObject;

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
        float distanceEntreCartes = ((ecartPourMettreCartes - (deckJoueur.Length)) / (deckJoueur.Length + 1));

        int index = 0;
        foreach (var carte in deckJoueur)
        {
            carte.GetComponent<carteProfil>().index = index;
            index++;
            Vector2 pos;
            pos.x = posCarteDepart + (distanceEntreCartes * index);
            pos.y = posYCarteJeu;
            carte.GetComponent<RectTransform>().anchoredPosition = new Vector2(pos.x, pos.y);
            carte.GetComponent<carteProfil>().indexSiblingInitial = carte.transform.GetSiblingIndex();
            carte.GetComponent<carteProfil>().posXinitial = pos.x;
            carte.GetComponent<carteProfil>().posYinitial = pos.y;
        }
        btnContinuer.transform.SetSiblingIndex(100);
    }


    public void Recharger()
    {
        deckActuel = deckTrash;
        deckActuel = librairie.GetComponent<librairieDeck>().SufflerCartes(deckActuel);

        foreach (GameObject carte in deckTrash)
        {
            deckTrash = librairie.GetComponent<librairieDeck>().enleverCarte(deckTrash, 0);
        }
    }
}
