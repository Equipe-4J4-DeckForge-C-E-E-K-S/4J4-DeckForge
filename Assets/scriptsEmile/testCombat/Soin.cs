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
        if(deck.GetComponent<deck>().tourJoueur)
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
            deck.GetComponent<deck>().deckTrash = librairie.GetComponent<librairieDeck>().ajouterCarte(deck.GetComponent<deck>().deckTrash, carteADuplique);
            deck.GetComponent<deck>().deckJoueur = librairie.GetComponent<librairieDeck>().enleverCarte(deck.GetComponent<deck>().deckJoueur, indexASupprimer);
            deck.GetComponent<deck>().OrganiserDeckJoueur();
            Debug.Log("oki");
            Destroy(gameObject);
    }
}
