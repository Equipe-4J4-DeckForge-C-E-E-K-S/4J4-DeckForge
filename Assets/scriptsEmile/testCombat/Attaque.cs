using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attaque : MonoBehaviour
{
    public GameObject personnage;
    public GameObject cible;
    public float attaque;
    public bool cibleTrouve;
    public bool enAttaque;

    public GameObject librairie;
    public GameObject deck;

    public GameObject carteADuplique;
    public int indexASupprimer;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (deck.GetComponent<deck>().tourJoueur)
        {
            GetComponent<Button>().enabled = true;
        }
        else
        {
            GetComponent<Button>().enabled = false;
        }

        cibleTrouve = personnage.GetComponent<comportementJoueur>().cibleTrouve;
        if (cibleTrouve)
        {
            attaque = personnage.GetComponent<statistiquesPersonnage>().attaque;
            cible = personnage.GetComponent<comportementJoueur>().ennemiAAttaque;
            personnage.GetComponent<comportementJoueur>().ennemiAAttaque.GetComponent<statistiquesPersonnage>().vie -= attaque;
            cibleTrouve = false;
            personnage.GetComponent<comportementJoueur>().cibleTrouve = cibleTrouve;

            carteADuplique = GetComponent<carteProfil>().prefab;
            indexASupprimer = GetComponent<carteProfil>().index;

            deck.GetComponent<deck>().deckTrash = librairie.GetComponent<librairieDeck>().ajouterCarte(deck.GetComponent<deck>().deckTrash, carteADuplique);
            deck.GetComponent<deck>().deckJoueur = librairie.GetComponent<librairieDeck>().enleverCarte(deck.GetComponent<deck>().deckJoueur, indexASupprimer);
            deck.GetComponent<deck>().OrganiserDeckJoueur();
            Destroy(gameObject);
        }
    }

    public void Attaquer()
    {
        enAttaque = true;
        personnage.GetComponent<comportementJoueur>().enAttaque = enAttaque;
    }
}
