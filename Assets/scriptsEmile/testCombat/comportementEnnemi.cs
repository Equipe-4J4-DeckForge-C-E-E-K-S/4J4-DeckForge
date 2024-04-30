using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comportementEnnemi : MonoBehaviour
{
    public GameObject joueur;
    public GameObject cible;
    public bool enAttaque;

    public bool doitChercher;

    public GameObject librairie;
    public GameObject deck;
    public GameObject gestionnaireEnnemi;

    public int actionChoisie1;
    public int actionChoisie2;
    public int actionChoisie3;
    public int actionChoisie4;

    public int delaiFinTour;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (enAttaque)
        {
            cible.GetComponent<comportementCible>().parent = gameObject;
            cible.GetComponent<comportementCible>().joueur = joueur;
            cible.SetActive(true);
        }
        else if (enAttaque == false)
        {
            cible.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        if (GetComponent<statistiquesPersonnage>().vie <= 0)
        {
            gestionnaireEnnemi.GetComponent<comportementGestionnaireEnnemi>().listeLocale = librairie.GetComponent<librairieDeck>().enleverCarte(gestionnaireEnnemi.GetComponent<comportementGestionnaireEnnemi>().listeLocale, 0);
            Destroy(gameObject);
        }
    }

    public void Ennemi()
    {
        delaiFinTour = 0;
        int nbActions = Random.Range(1, 5);
        //Debug.Log("nombres actions: " + nbActions);
        for (int i = 0; i < nbActions; i++)
        {
            int delai = i;
            //Debug.Log("delai:" + i);
            int TempsActivation = 0 + delai;
            //Debug.Log("temps d'activation:" + TempsActivation);
            delaiFinTour += (delai + (1 / nbActions));
            //Debug.Log("delai fin tour boucle:" + delaiFinTour);
            int actionChoisie = Random.Range(1, 5);

            if (actionChoisie == 1)
            {
                Invoke("Action1", TempsActivation);
            }
            else if (actionChoisie == 2)
            {
                Invoke("Action2", TempsActivation);
            }
            else if (actionChoisie == 3)
            {
                Invoke("Action3", TempsActivation);
            }
            else if (actionChoisie == 4)
            {
                Invoke("Action4", TempsActivation);
            }
        }
        //Debug.Log("delai fin tour: " + delaiFinTour);
        Invoke("LancerProchaineAttaque", delaiFinTour);
    }

    public void Action1()
    {
        RegarderListeActions(actionChoisie1);
    }

    public void Action2()
    {
        RegarderListeActions(actionChoisie2);

    }

    public void Action3()
    {
        RegarderListeActions(actionChoisie3);

    }

    public void Action4()
    {
        RegarderListeActions(actionChoisie4);
    }

    public void LancerProchaineAttaque() 
    {
        gestionnaireEnnemi.GetComponent<comportementGestionnaireEnnemi>().AttaquerJoueur();
    }

    public void RegarderListeActions(int actionChoisie)
    {
        bool typeEau = GetComponent<statistiquesPersonnage>().typeEau;
        bool typeFeu = GetComponent<statistiquesPersonnage>().typeFeu;
        bool typePlante = GetComponent<statistiquesPersonnage>().typePlante;

        if (actionChoisie >= 0)
        {
            librairie.GetComponent<librairieAttaque>().AttaquerNormal(joueur, GetComponent<statistiquesPersonnage>().attaque, typeEau, typeFeu, typePlante);
        }
    }
}