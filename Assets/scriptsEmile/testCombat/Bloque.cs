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

    public GameObject debugGameObject;

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
    }

    public void Bloquer()
    {
        if(estClique){
            defense = personnage.GetComponent<statistiquesPersonnage>().defense;
            defense *= 2;
            personnage.GetComponent<statistiquesPersonnage>().defense = defense;
            estClique = false;

            deck.GetComponent<deck>().deckTrash = librairie.GetComponent<librairieDeck>().ajouterCarte(deck.GetComponent<deck>().deckTrash, gameObject);
            Destroy(gameObject);
        }
    }
}
