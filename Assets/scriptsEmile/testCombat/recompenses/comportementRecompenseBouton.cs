using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comportementRecompenseBouton : MonoBehaviour
{
    public GameObject prefabADuplique;
    public GameObject fin;
    public GameObject inventaire;
    public int indexASupprime;

    public GameObject deck;
    public GameObject librairie;
    public GameObject grilleRecompense;

    public GameObject carteZoom;
    public GameObject instructions;
    public GameObject btnSauterRecompenses;
    public GameObject btnAjouterRecompenses;
    public GameObject btnAnnulerRecompenses;
    public GameObject btnEnlever;

    // Update is called once per frame
    void Update()
    {
    }

    public void AjouterCarte()
    {
        if (Deck.deckStat.Length >= Deck.maxLenght)
        {
            inventaire.GetComponent<comportementInventaire>().inventaireEstUtilise = true;
            btnEnlever.GetComponent<comportementInventaireBouton>().prefabADuplique = prefabADuplique;
            inventaire.GetComponent<comportementInventaire>().MontrerInventaire();
        }
        else
        {
            Deck.deckStat = librairie.GetComponent<librairieDeck>().ajouterCarte(Deck.deckStat, prefabADuplique);
            fin.GetComponent<comportementFin>().montrerMessageFin();
        }
        carteZoom.SetActive(false);
        instructions.SetActive(false);
        btnAnnulerRecompenses.SetActive(false);
        btnSauterRecompenses.SetActive(false);
        grilleRecompense.SetActive(false);
        gameObject.SetActive(false);
    }

    public void Annuler()
    {
        fin.GetComponent<comportementFin>().peutSurvole = true;
        btnSauterRecompenses.SetActive(true);
        instructions.SetActive(true);
        grilleRecompense.SetActive(true);
        carteZoom.SetActive(false);
        btnAjouterRecompenses.SetActive(false);
        gameObject.SetActive(false);
    }

    public void Sauter()
    {
        carteZoom.SetActive(false);
        instructions.SetActive(false);
        btnAnnulerRecompenses.SetActive(false);
        btnAjouterRecompenses.SetActive(false);
        grilleRecompense.SetActive(false);
        gameObject.SetActive(false);
        fin.GetComponent<comportementFin>().montrerMessageFin();
    }
}
