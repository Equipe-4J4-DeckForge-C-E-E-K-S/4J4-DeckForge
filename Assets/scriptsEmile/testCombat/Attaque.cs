
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
        if (deck.GetComponent<Deck>().tourJoueur)
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
            float defCible = cible.GetComponent<statistiquesPersonnage>().defense;

            bool typeEauCarte = GetComponent<carteProfil>().typeEau;
            bool typeFeuCarte = GetComponent<carteProfil>().typeFeu;
            bool typePlanteCarte = GetComponent<carteProfil>().typePlante;

            bool typeFeuEnnemi = cible.GetComponent<statistiquesPersonnage>().typeFeu;
            bool typeEauEnnemi = cible.GetComponent<statistiquesPersonnage>().typeEau;
            bool typePlanteEnnemi = cible.GetComponent<statistiquesPersonnage>().typePlante;

            if (typeEauCarte && typeFeuEnnemi)
            {
                personnage.GetComponent<comportementJoueur>().ennemiAAttaque.GetComponent<statistiquesPersonnage>().vie -= ((attaque * ((10 - defCible) / 10)) * 2);
                float vieCible = personnage.GetComponent<comportementJoueur>().ennemiAAttaque.GetComponent<statistiquesPersonnage>().vie;
                personnage.GetComponent<comportementJoueur>().ennemiAAttaque.GetComponent<statistiquesPersonnage>().vie = Mathf.Round(vieCible * 10.0f) * 0.1f;

            }
            else if (typeFeuCarte && typePlanteEnnemi)
            {
                personnage.GetComponent<comportementJoueur>().ennemiAAttaque.GetComponent<statistiquesPersonnage>().vie -= ((attaque * ((10 - defCible) / 10)) * 2);
                float vieCible = personnage.GetComponent<comportementJoueur>().ennemiAAttaque.GetComponent<statistiquesPersonnage>().vie;
                personnage.GetComponent<comportementJoueur>().ennemiAAttaque.GetComponent<statistiquesPersonnage>().vie = Mathf.Round(vieCible * 10.0f) * 0.1f;
            }
            else if (typePlanteCarte && typeEauEnnemi)
            {
                personnage.GetComponent<comportementJoueur>().ennemiAAttaque.GetComponent<statistiquesPersonnage>().vie -= ((attaque * ((10 - defCible) / 10)) * 2);
                float vieCible = personnage.GetComponent<comportementJoueur>().ennemiAAttaque.GetComponent<statistiquesPersonnage>().vie;
                personnage.GetComponent<comportementJoueur>().ennemiAAttaque.GetComponent<statistiquesPersonnage>().vie = Mathf.Round(vieCible * 10.0f) * 0.1f;
            }
            else if (typeEauCarte && typePlanteEnnemi)
            {
                personnage.GetComponent<comportementJoueur>().ennemiAAttaque.GetComponent<statistiquesPersonnage>().vie -= ((attaque * ((10 - defCible) / 10)) * 0.5f);
                float vieCible = personnage.GetComponent<comportementJoueur>().ennemiAAttaque.GetComponent<statistiquesPersonnage>().vie;
                personnage.GetComponent<comportementJoueur>().ennemiAAttaque.GetComponent<statistiquesPersonnage>().vie = Mathf.Round(vieCible * 10.0f) * 0.1f;
            }
            else if (typeFeuCarte && typeEauEnnemi)
            {
                personnage.GetComponent<comportementJoueur>().ennemiAAttaque.GetComponent<statistiquesPersonnage>().vie -= ((attaque * ((10 - defCible) / 10)) * 0.5f);
                float vieCible = personnage.GetComponent<comportementJoueur>().ennemiAAttaque.GetComponent<statistiquesPersonnage>().vie;
                personnage.GetComponent<comportementJoueur>().ennemiAAttaque.GetComponent<statistiquesPersonnage>().vie = Mathf.Round(vieCible * 10.0f) * 0.1f;
            }
            else if (typePlanteCarte && typeFeuEnnemi)
            {
                personnage.GetComponent<comportementJoueur>().ennemiAAttaque.GetComponent<statistiquesPersonnage>().vie -= ((attaque * ((10 - defCible) / 10)) * 0.5f);
                float vieCible = personnage.GetComponent<comportementJoueur>().ennemiAAttaque.GetComponent<statistiquesPersonnage>().vie;
                personnage.GetComponent<comportementJoueur>().ennemiAAttaque.GetComponent<statistiquesPersonnage>().vie = Mathf.Round(vieCible * 10.0f) * 0.1f;
            }
            else
            {
                personnage.GetComponent<comportementJoueur>().ennemiAAttaque.GetComponent<statistiquesPersonnage>().vie -= (attaque * ((10 - defCible) / 10));
                float vieCible = personnage.GetComponent<comportementJoueur>().ennemiAAttaque.GetComponent<statistiquesPersonnage>().vie;
                personnage.GetComponent<comportementJoueur>().ennemiAAttaque.GetComponent<statistiquesPersonnage>().vie = Mathf.Round(vieCible * 10.0f) * 0.1f;
            }

            cibleTrouve = false;
            personnage.GetComponent<comportementJoueur>().cibleTrouve = cibleTrouve;

            carteADuplique = GetComponent<carteProfil>().prefab;
            indexASupprimer = GetComponent<carteProfil>().index;

            deck.GetComponent<Deck>().deckTrash = librairie.GetComponent<librairieDeck>().ajouterCarte(deck.GetComponent<Deck>().deckTrash, carteADuplique);
            deck.GetComponent<Deck>().deckJoueur = librairie.GetComponent<librairieDeck>().enleverCarte(deck.GetComponent<Deck>().deckJoueur, indexASupprimer);
            deck.GetComponent<Deck>().OrganiserDeckJoueur();
            Destroy(gameObject);
        }
    }

    public void Attaquer()
    {
        enAttaque = true;
        personnage.GetComponent<comportementJoueur>().enAttaque = enAttaque;
    }
}
