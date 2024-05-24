using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comportementInventaireBouton : MonoBehaviour
{
    public GameObject prefabADuplique;
    public int indexASupprime;

    public GameObject deck;
    public GameObject librairie;
    public GameObject grilleInventaire;

    // Update is called once per frame
    void Update()
    {
    }

    public void EnleverCarte()
    {
        Deck.deckStat = librairie.GetComponent<librairieDeck>().enleverCarte(Deck.deckStat, indexASupprime);
        Deck.deckStat = librairie.GetComponent<librairieDeck>().ajouterCarte(Deck.deckStat, prefabADuplique);
        grilleInventaire.GetComponent<comportementInventaire>().peutMontrerBtn = false;
        grilleInventaire.GetComponent<comportementInventaire>().FermerInventaire();
    }

    public void Annuler()
    {
        grilleInventaire.GetComponent<comportementInventaire>().peutMontrerBtn = false;
    }
}
