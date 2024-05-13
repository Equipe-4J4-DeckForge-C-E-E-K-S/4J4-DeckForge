
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
    public GameObject carteBouton;

    public GameObject carteADuplique;
    public int indexASupprimer;

    public bool finNiveau;

    public bool debug;
    public int debug2;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        finNiveau = librairie.GetComponent<comportementFin>().finNiveau;

        if (finNiveau == false)
        {
            if (deck.GetComponent<Deck>().tourJoueur)
            {
                GetComponent<Button>().enabled = true;
            }
            else
            {
                GetComponent<Button>().enabled = false;
            }
        }

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
                float attaqueTotale = ((attaque * ((10 - defCible) / 10)) * 2);
                if (attaqueTotale < 0)
                {
                    attaqueTotale = 0;
                }
                personnage.GetComponent<comportementJoueur>().ennemiAAttaque.GetComponent<statistiquesPersonnage>().vie -= attaqueTotale;
                float vieCible = personnage.GetComponent<comportementJoueur>().ennemiAAttaque.GetComponent<statistiquesPersonnage>().vie;
                personnage.GetComponent<comportementJoueur>().ennemiAAttaque.GetComponent<statistiquesPersonnage>().vie = Mathf.Round(vieCible * 10.0f) * 0.1f;

            }
            else if (typeFeuCarte && typePlanteEnnemi)
            {
                float attaqueTotale = ((attaque * ((10 - defCible) / 10)) * 2);
                if (attaqueTotale < 0)
                {
                    attaqueTotale = 0;
                }
                personnage.GetComponent<comportementJoueur>().ennemiAAttaque.GetComponent<statistiquesPersonnage>().vie -= attaqueTotale;
                float vieCible = personnage.GetComponent<comportementJoueur>().ennemiAAttaque.GetComponent<statistiquesPersonnage>().vie;
                personnage.GetComponent<comportementJoueur>().ennemiAAttaque.GetComponent<statistiquesPersonnage>().vie = Mathf.Round(vieCible * 10.0f) * 0.1f;
            }
            else if (typePlanteCarte && typeEauEnnemi)
            {
                float attaqueTotale = ((attaque * ((10 - defCible) / 10)) * 2);
                if (attaqueTotale < 0)
                {
                    attaqueTotale = 0;
                }
                personnage.GetComponent<comportementJoueur>().ennemiAAttaque.GetComponent<statistiquesPersonnage>().vie -= attaqueTotale;
                float vieCible = personnage.GetComponent<comportementJoueur>().ennemiAAttaque.GetComponent<statistiquesPersonnage>().vie;
                personnage.GetComponent<comportementJoueur>().ennemiAAttaque.GetComponent<statistiquesPersonnage>().vie = Mathf.Round(vieCible * 10.0f) * 0.1f;
            }
            else if (typeEauCarte && typePlanteEnnemi)
            {
                float attaqueTotale = ((attaque * ((10 - defCible) / 10)) * 0.5f);
                if (attaqueTotale < 0)
                {
                    attaqueTotale = 0;
                }
                personnage.GetComponent<comportementJoueur>().ennemiAAttaque.GetComponent<statistiquesPersonnage>().vie -= attaqueTotale;
                float vieCible = personnage.GetComponent<comportementJoueur>().ennemiAAttaque.GetComponent<statistiquesPersonnage>().vie;
                personnage.GetComponent<comportementJoueur>().ennemiAAttaque.GetComponent<statistiquesPersonnage>().vie = Mathf.Round(vieCible * 10.0f) * 0.1f;
            }
            else if (typeFeuCarte && typeEauEnnemi)
            {
                float attaqueTotale = ((attaque * ((10 - defCible) / 10)) * 0.5f);
                if (attaqueTotale < 0)
                {
                    attaqueTotale = 0;
                }
                personnage.GetComponent<comportementJoueur>().ennemiAAttaque.GetComponent<statistiquesPersonnage>().vie -= attaqueTotale;
                float vieCible = personnage.GetComponent<comportementJoueur>().ennemiAAttaque.GetComponent<statistiquesPersonnage>().vie;
                personnage.GetComponent<comportementJoueur>().ennemiAAttaque.GetComponent<statistiquesPersonnage>().vie = Mathf.Round(vieCible * 10.0f) * 0.1f;
            }
            else if (typePlanteCarte && typeFeuEnnemi)
            {
                float attaqueTotale = ((attaque * ((10 - defCible) / 10)) * 0.5f);
                if (attaqueTotale < 0)
                {
                    attaqueTotale = 0;
                }
                personnage.GetComponent<comportementJoueur>().ennemiAAttaque.GetComponent<statistiquesPersonnage>().vie -= attaqueTotale;
                float vieCible = personnage.GetComponent<comportementJoueur>().ennemiAAttaque.GetComponent<statistiquesPersonnage>().vie;
                personnage.GetComponent<comportementJoueur>().ennemiAAttaque.GetComponent<statistiquesPersonnage>().vie = Mathf.Round(vieCible * 10.0f) * 0.1f;
            }
            else
            {
                float attaqueTotale = (attaque * ((10 - defCible) / 10));
                if (attaqueTotale < 0)
                {
                    attaqueTotale = 0;
                }
                personnage.GetComponent<comportementJoueur>().ennemiAAttaque.GetComponent<statistiquesPersonnage>().vie -= attaqueTotale;
                float vieCible = personnage.GetComponent<comportementJoueur>().ennemiAAttaque.GetComponent<statistiquesPersonnage>().vie;
                personnage.GetComponent<comportementJoueur>().ennemiAAttaque.GetComponent<statistiquesPersonnage>().vie = Mathf.Round(vieCible * 10.0f) * 0.1f;
            }

            cibleTrouve = false;
            personnage.GetComponent<comportementJoueur>().cibleTrouve = cibleTrouve;

            carteADuplique = GetComponent<carteProfil>().prefab;
            indexASupprimer = GetComponent<carteProfil>().index;

            Debug.Log(carteADuplique);
            Debug.Log(indexASupprimer);

            deck.GetComponent<Deck>().deckTrash = librairie.GetComponent<librairieDeck>().ajouterCarte(deck.GetComponent<Deck>().deckTrash, carteADuplique);
            deck.GetComponent<Deck>().deckJoueur = librairie.GetComponent<librairieDeck>().enleverCarte(deck.GetComponent<Deck>().deckJoueur, indexASupprimer);
            deck.GetComponent<Deck>().OrganiserDeckJoueur();
            Destroy(gameObject);
        }
    }

    public void Attaquer()
    {
        //carteADuplique = GetComponent<carteProfil>().prefab;
        //indexASupprimer = GetComponent<carteProfil>().index;

        personnage.GetComponent<comportementJoueur>().enAttaque = true;
        personnage.GetComponent<comportementJoueur>().carteAttaqueUtilisee = GetComponent<carteProfil>().index;
    }
}
