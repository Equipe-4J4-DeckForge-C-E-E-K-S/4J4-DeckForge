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
    public GameObject[] indexBoss;

    public GameObject[] listeLocale;
    public GameObject[] listeRecompense;
    public GameObject[] listeRecompenseFinale;

    public int nombreRecompense;

    public GameObject librairie;
    public Transform canvas;

    public float ecartPourMettreEnnemi = 500f;
    public float posYEnnemi = -30f;
    public float posEnnemiDepart = 200f;

    public GameObject joueur;
    public GameObject deck;

    public bool tourEnnemiEnCours;
    public bool tourEnnemiTermine;
    public bool peutMettreFin;

    public bool niveauBoss;

    public int delai;

    public int nbEnnemi;
    
    public static float difficulte;
    public int indexListeLocale;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(difficulte);
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


        if (listeLocale.Length <= 0 && peutMettreFin)
        {
            Debug.Log("oki");
            peutMettreFin = false;
            if (niveauBoss == false)
            {
                nombreRecompense = Random.Range(1, 3);
                for (int i = 0; i < nombreRecompense; i++)
                {
                    int carteChoisie = Random.Range(1, (listeRecompense.Length-1));
                    listeRecompenseFinale = librairie.GetComponent<librairieDeck>().ajouterCarte(listeRecompenseFinale, listeRecompense[carteChoisie]);
                }
            }
            librairie.GetComponent<comportementFin>().FinirNiveau(true);
        }


        if(tourEnnemiTermine)
        {
            Invoke("ChangerLeTour", delai);
            tourEnnemiTermine = false;
        }
    }

    public void FaireApparaitreEnnemi()
    {
        if (difficulte <= 0f)
        {
            difficulte = 1f;
        }

        if (difficulte < 3.5f && difficulte >= 1f)
        {
            indexLocal = indexBasique;
        }
        else if (difficulte < 6.5f && difficulte >= 4f)
        {
            indexLocal = indexPlante;
        }
        else if (difficulte < 12.5f && difficulte >= 10f)
        {
            indexLocal = indexFeu;
        }
        else if (difficulte < 9.5f && difficulte >= 7f)
        {
            indexLocal = indexEau;
        }

        if (difficulte == 3.5f)
        {
            niveauBoss = true;
            indexLocal = librairie.GetComponent<librairieDeck>().ajouterCarte(indexLocal, indexBoss[0]);
        }
        else if (difficulte == 6.5f)
        {
            niveauBoss = true;
            indexLocal = librairie.GetComponent<librairieDeck>().ajouterCarte(indexLocal, indexBoss[1]);
        }
        else if (difficulte == 10f)
        {
            niveauBoss = true;
            indexLocal = librairie.GetComponent<librairieDeck>().ajouterCarte(indexLocal, indexBoss[2]);
        }
        else if (difficulte >= 12.5f)
        {
            niveauBoss = true;
            indexLocal = librairie.GetComponent<librairieDeck>().ajouterCarte(indexLocal, indexBoss[3]);
        }

        if (niveauBoss)
        {
            nbEnnemi = 1;
        }
        else
        {
            nbEnnemi = Random.Range(1, 4);
        }

        for (int i = 0; i < nbEnnemi; i++)
        {
            int choixEnnemi = Random.Range(0, indexLocal.Length);
            Debug.Log("choix" + choixEnnemi);
            GameObject ennemi = Instantiate(indexLocal[choixEnnemi], canvas);
            ennemi.GetComponent<statistiquesPersonnage>().vie = ((ennemi.GetComponent<statistiquesPersonnage>().vie * difficulte) / nbEnnemi);
            ennemi.GetComponent<statistiquesPersonnage>().vie = Mathf.Round(ennemi.GetComponent<statistiquesPersonnage>().vie * 10.0f) * 0.1f;

            ennemi.GetComponent<statistiquesPersonnage>().attaque = ((ennemi.GetComponent<statistiquesPersonnage>().attaque * difficulte) / nbEnnemi);
            ennemi.GetComponent<statistiquesPersonnage>().attaque = Mathf.Round(ennemi.GetComponent<statistiquesPersonnage>().attaque * 10.0f) * 0.1f;

            ennemi.GetComponent<statistiquesPersonnage>().defense = ((ennemi.GetComponent<statistiquesPersonnage>().defense * (difficulte/2)) / nbEnnemi);
            if (ennemi.GetComponent<statistiquesPersonnage>().defense >= 10f)
            {
                ennemi.GetComponent<statistiquesPersonnage>().defense = 9f;
            }
            ennemi.GetComponent<statistiquesPersonnage>().defense = Mathf.Round(ennemi.GetComponent<statistiquesPersonnage>().defense * 10.0f) * 0.1f;

            ennemi.GetComponent<comportementEnnemi>().index = i;
            ennemi.GetComponent<comportementEnnemi>().joueur = joueur;
            ennemi.GetComponent<comportementEnnemi>().librairie = librairie;
            ennemi.GetComponent<comportementEnnemi>().deck = deck;
            ennemi.GetComponent<comportementEnnemi>().gestionnaireEnnemi = gameObject;


            listeLocale = librairie.GetComponent<librairieDeck>().ajouterCarte(listeLocale, ennemi);
            if (niveauBoss == false)
            {
                listeRecompense = librairie.GetComponent<librairieDeck>().ajouterCarte(listeRecompense, ennemi.GetComponent<comportementEnnemi>().carte1);
                listeRecompense = librairie.GetComponent<librairieDeck>().ajouterCarte(listeRecompense, ennemi.GetComponent<comportementEnnemi>().carte2);
                listeRecompense = librairie.GetComponent<librairieDeck>().ajouterCarte(listeRecompense, ennemi.GetComponent<comportementEnnemi>().carte3);
            }
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

    public void ReclasserOrdreEnnemi()
    {
        int i = 0;
        foreach (var ennemi in listeLocale)
        {
            ennemi.GetComponent<comportementEnnemi>().index = i;
            i++;
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
        indexListeLocale ++;
        if (indexListeLocale == listeLocale.Length + 1)
        {
            tourEnnemiTermine = true;
        }
        else if (indexListeLocale > listeLocale.Length + 1)
        {
            indexListeLocale = 1;
        }

        if (indexListeLocale < listeLocale.Length + 1)
        {
            listeLocale[(indexListeLocale - 1)].GetComponent<comportementEnnemi>().Ennemi();
        }

    }
}