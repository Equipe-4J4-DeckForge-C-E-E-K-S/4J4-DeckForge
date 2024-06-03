using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comportementJoueur : MonoBehaviour
{
    public GameObject ennemiAAttaque;
    public GameObject objetADupliquer;
    public Transform canvas;
    public bool enAttaque;
    public bool cibleTrouve;
    public float floatX;
    public float floatY;

    public static float viePartie = 100f;
    public static float defPartie = 1f;

    public GameObject librairie;

   public GameObject deck;

   public int carteAttaqueUtilisee;

    public bool enrDefInitiale = true;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<statistiquesPersonnage>().vie = viePartie;
    }

    void Update()
{
    if(enrDefInitiale)
    {
        GetComponent<statistiquesPersonnage>().defense = defPartie;
        GetComponent<statistiquesPersonnage>().defenseInitiale = defPartie;
        enrDefInitiale=false;
    }

    if (cibleTrouve)
    {
        if (deck != null)
        {
            Deck deckComponent = deck.GetComponent<Deck>();
            if (deckComponent != null && deckComponent.deckJoueur != null)
            {
                for (int i = 0; i < deckComponent.deckJoueur.Length; i++) 
                {
                    if (i == carteAttaqueUtilisee)
                    {
                        GameObject joueur = deckComponent.deckJoueur[i];
                        if (joueur != null)
                        {
                            Attaque attaqueComponent = joueur.GetComponent<Attaque>();
                            if (attaqueComponent != null)
                            {
                                attaqueComponent.cibleTrouve = true;
                            }
                        }
                    }
                }
            }
        }
        cibleTrouve=false;
    }
}

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(GetComponent<statistiquesPersonnage>().vie <= 0)
        {
            librairie.GetComponent<comportementFin>().FinirNiveau(false);
        }   
    }
}
