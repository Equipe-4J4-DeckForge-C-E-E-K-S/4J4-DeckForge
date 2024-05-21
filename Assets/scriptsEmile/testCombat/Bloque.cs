using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bloque : MonoBehaviour
{

    public GameObject personnage;
    public float defense;
    public bool estClique;


    public GameObject librairie;
    public GameObject deck;

    public bool finNiveau;

    // Start is called before the first frame update
    void Start()
    {
        estClique = true;
    }

    // Update is called once per frame
    void Update()
    {
        finNiveau = librairie.GetComponent<comportementFin>().finNiveau;

        if (finNiveau == false)
        {
            if (deck.GetComponent<Deck>().tourJoueur)
            {
                GetComponent<Button>().enabled = true;
            }
            else
            {
                GetComponent<Button>().enabled = false;
            }
        }
    }

    public void Bloquer()
    {
        if(estClique){
            personnage.GetComponent<statistiquesPersonnage>().defense += defense;
            estClique = false;

            GameObject carteADuplique = GetComponent<carteProfil>().prefab;
            int indexASupprimer = GetComponent<carteProfil>().index;
            deck.GetComponent<Deck>().deckTrash = librairie.GetComponent<librairieDeck>().ajouterCarte(deck.GetComponent<Deck>().deckTrash, carteADuplique);
            deck.GetComponent<Deck>().deckJoueur = librairie.GetComponent<librairieDeck>().enleverCarte(deck.GetComponent<Deck>().deckJoueur, indexASupprimer);
            deck.GetComponent<Deck>().OrganiserDeckJoueur();
            Destroy(gameObject);
        }
    }
}
