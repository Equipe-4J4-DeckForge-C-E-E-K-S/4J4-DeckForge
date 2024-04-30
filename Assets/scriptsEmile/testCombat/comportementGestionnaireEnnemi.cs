using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comportementGestionnaireEnnemi : MonoBehaviour
{
    public bool biomeBasique;
    public bool biomeEau;
    public bool biomeFeu;
    public bool biomePlante;

    public GameObject[] indexLocal;
    public GameObject[] indexBasique;
    public GameObject[] indexEau;
    public GameObject[] indexFeu;
    public GameObject[] indexPlante;

    public GameObject[] listeLocale;

    public GameObject librairie;
    public Transform canvas;

    public float ecartPourMettreEnnemi = 500f;
    public float posYEnnemi = -30f;
    public float posEnnemiDepart = 200f;

    public GameObject joueur;
    public GameObject deck;

    public bool tourEnnemiEnCours;

    public int delai;
    public int difficulte;

    // Start is called before the first frame update
    void Start()
    {
        FaireApparaitreEnnemi();
    }

    // Update is called once per frame
    void Update()
    {
        if (deck.GetComponent<Deck>().tourEnnemi == false && tourEnnemiEnCours == false)
        {
            tourEnnemiEnCours = true;
        }

        if (deck.GetComponent<Deck>().tourEnnemi == true && tourEnnemiEnCours == true)
        {
            tourEnnemiEnCours = false;
            AttaquerJoueur();
        }

        GererReactionAttaqueEnnemi();


        if (listeLocale.Length <= 0)
        {
            librairie.GetComponent<comportementFin>().FinirNiveau(true);
        }

        //Debug.Log("delai hors loop " + delai);
    }

    public void FaireApparaitreEnnemi()
    {
        if (biomeBasique)
        {
            indexLocal = indexBasique;
        }
        else if (biomeEau)
        {
            indexLocal = indexEau;
        }
        else if (biomeFeu)
        {
            indexLocal = indexFeu;
        }
        else if (biomePlante)
        {
            indexLocal = indexPlante;
        }


        int nbEnnemi = 2;//Random.Range(1, 3);

        for (int i = 0; i < nbEnnemi; i++)
        {
            int choixEnnemi = Random.Range(0, indexLocal.Length);
            GameObject ennemi = Instantiate(indexLocal[choixEnnemi], canvas);
            ennemi.GetComponent<statistiquesPersonnage>().vie = ((ennemi.GetComponent<statistiquesPersonnage>().vie * difficulte) / nbEnnemi);
            ennemi.GetComponent<statistiquesPersonnage>().attaque = ((ennemi.GetComponent<statistiquesPersonnage>().attaque * difficulte) / nbEnnemi);
            ennemi.GetComponent<statistiquesPersonnage>().defense = ((ennemi.GetComponent<statistiquesPersonnage>().defense * difficulte) / nbEnnemi);
            ennemi.GetComponent<comportementEnnemi>().joueur = joueur;
            ennemi.GetComponent<comportementEnnemi>().librairie = librairie;
            ennemi.GetComponent<comportementEnnemi>().deck = deck;
            ennemi.GetComponent<comportementEnnemi>().gestionnaireEnnemi = gameObject;

            listeLocale = librairie.GetComponent<librairieDeck>().ajouterCarte(listeLocale, ennemi);
            ennemi.SetActive(true);
        }

        OrganiserPositionEnnemi();
    }

    public void OrganiserPositionEnnemi()
    {
        float distanceEntreEnnemis = ((ecartPourMettreEnnemi - (listeLocale.Length * 10)) / (listeLocale.Length + 1));

        int index = 0;
        foreach (var ennemi in listeLocale)
        {
            index++;
            Vector2 pos;
            pos.x = posEnnemiDepart + (distanceEntreEnnemis * index);

            pos.y = posYEnnemi;
            ennemi.GetComponent<RectTransform>().anchoredPosition = new Vector2(pos.x, pos.y);
        }
    }


    public void GererReactionAttaqueEnnemi()
    {
        if (joueur.GetComponent<comportementJoueur>().enAttaque)
        {
            foreach (var ennemi in listeLocale)
            {
                ennemi.GetComponent<comportementEnnemi>().enAttaque = true;
            }
        }
        else
        {
            foreach (var ennemi in listeLocale)
            {
                ennemi.GetComponent<comportementEnnemi>().enAttaque = false;
            }
        }
    }


    public void ChangerLeTour()
    {
        deck.GetComponent<Deck>().tourEnnemi = false;
        deck.GetComponent<Deck>().tourJoueur = true;
    }

    public void AttaquerJoueur()
    {
        delai = 0;
        foreach (var ennemi in listeLocale)
        {
            Debug.Log("delai pre loop " +delai);
            ennemi.GetComponent<comportementEnnemi>().LancerAttaque(delai);
            Debug.Log("delai p loop " +delai);
        }

        Invoke("ChangerLeTour", delai);
    }
}