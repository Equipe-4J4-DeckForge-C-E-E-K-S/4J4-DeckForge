using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class comportementFin : MonoBehaviour
{
    public GameObject deck;
    public GameObject librairie;
    public bool test;
    public bool finNiveau;

    public GameObject messageVictoire;
    public GameObject messageDefaite;
    public GameObject bouton;
    public GameObject btnAjouter;
    public GameObject btnSauter;
    public GameObject btnAnnuler;
    public GameObject btnEnlever;
    public GameObject instructions;

    public GameObject[] cartesRecompenses;

    public GameObject grilleRecompense;
    public GameObject carteZoom;


    public GameObject inventaire;

    public bool resultatNiveau;
    public bool peutSurvole;

    // Start is called before the first frame update
    void Start()
    {
        peutSurvole = true;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void FinirNiveau(bool victoire)
    {
        finNiveau = true;

        for (int i=0; i < (deck.GetComponent<Deck>().deckJoueur.Length); i++)
        {
            deck.GetComponent<Deck>().deckJoueur[i].GetComponent<Button>().enabled = false;
        }

        if (victoire)
        {
            foreach (var carte in librairie.GetComponent<comportementGestionnaireEnnemi>().listeRecompenseFinale)
            {
                GameObject carteDupliquee = Instantiate(carte, grilleRecompense.GetComponent<Transform>());
                carteDupliquee.GetComponent<comportementRecompenseCarte>().btnAjoutRecompense = btnAjouter;
                carteDupliquee.GetComponent<comportementRecompenseCarte>().btnAnnulerRecompense = btnAnnuler;
                carteDupliquee.GetComponent<comportementRecompenseCarte>().btnSauterRecompense = btnSauter;
                carteDupliquee.GetComponent<comportementRecompenseCarte>().carteZoom = carteZoom;
                carteDupliquee.GetComponent<comportementRecompenseCarte>().instructions = instructions;
                carteDupliquee.GetComponent<comportementRecompenseCarte>().grilleRecompense = grilleRecompense;
                carteDupliquee.GetComponent<comportementRecompenseCarte>().fin = gameObject;
                cartesRecompenses = librairie.GetComponent<librairieDeck>().ajouterCarte(cartesRecompenses, carteDupliquee);
            }
            instructions.transform.SetSiblingIndex(100);
            grilleRecompense.transform.SetSiblingIndex(100);
            carteZoom.transform.SetSiblingIndex(100);
            btnSauter.transform.SetSiblingIndex(100);
            btnAnnuler.transform.SetSiblingIndex(100);
            btnAjouter.transform.SetSiblingIndex(100);
            instructions.SetActive(true);
            grilleRecompense.SetActive(true);
            btnSauter.SetActive(true);

            int index = 0;
            foreach (var carte in cartesRecompenses)
            {
                float scale = carte.GetComponent<RectTransform>().localScale.x;
                carte.GetComponent<comportementRecompenseCarte>().scaleInitial = scale;
                index++;
            }
        }
        else
        {
            SceneManager.LoadScene("GAMEOVER");
        }

    }


    public void montrerMessageFin()
    {
        messageVictoire.SetActive(true);
        resultatNiveau = true;
        bouton.SetActive(true);
    }
}
