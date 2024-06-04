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
    public GameObject fin;

    public bool pourFin;

    // Update is called once per frame
    void Update()
    {
    }

    public void EnleverCarte()
    {
        Deck.deckStat = librairie.GetComponent<librairieDeck>().ajouterCarte(Deck.deckStat, prefabADuplique);
        Deck.deckStat = librairie.GetComponent<librairieDeck>().enleverCarte(Deck.deckStat, indexASupprime);
        grilleInventaire.GetComponent<comportementInventaire>().peutMontrerBtn = false;
        grilleInventaire.GetComponent<comportementInventaire>().FermerInventaire();
        if (pourFin)
        {
            fin.GetComponent<comportementFin>().montrerMessageFin();
        }
    }

   public void Annuler()
{
    grilleInventaire.GetComponent<comportementInventaire>().peutMontrerBtn = false;
}
}
