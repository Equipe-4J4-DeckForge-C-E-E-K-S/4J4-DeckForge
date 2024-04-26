using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Soin : MonoBehaviour
{

    public GameObject personnage;
    public float vie;
    public bool estClique;

    public GameObject librairie;
    public GameObject deck;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(deck.GetComponent<Deck>().tourJoueur)
        {
            GetComponent<Button>().enabled = true;
        }
        else
        {
            GetComponent<Button>().enabled = false;
        }
    }

    public void Soigner()
    {
            vie = personnage.GetComponent<statistiquesPersonnage>().vie;
            vie += 2;
            personnage.GetComponent<statistiquesPersonnage>().vie = vie;
            estClique = false;

            GameObject carteADuplique = GetComponent<carteProfil>().prefab;
            int indexASupprimer = GetComponent<carteProfil>().index;
            deck.GetComponent<Deck>().deckTrash = librairie.GetComponent<librairieDeck>().ajouterCarte(deck.GetComponent<Deck>().deckTrash, carteADuplique);
            deck.GetComponent<Deck>().deckJoueur = librairie.GetComponent<librairieDeck>().enleverCarte(deck.GetComponent<Deck>().deckJoueur, indexASupprimer);
            deck.GetComponent<Deck>().OrganiserDeckJoueur();
            Destroy(gameObject);
    }
}
