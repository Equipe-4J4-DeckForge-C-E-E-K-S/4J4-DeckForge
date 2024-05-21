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
            for (int i = 0; i < deck.GetComponent<Deck>().deckJoueur.Length; i++) 
            {
                if (i == carteAttaqueUtilisee)
                {
                    deck.GetComponent<Deck>().deckJoueur[i].GetComponent<Attaque>().cibleTrouve = true;
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
