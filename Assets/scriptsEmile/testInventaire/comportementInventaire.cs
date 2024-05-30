using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comportementInventaire : MonoBehaviour
{
    public GameObject grille;
    public GameObject[] cartesInventaire;
    public GameObject librairie;
    public GameObject deck;
    public GameObject carteZoom;
    public bool peutMontrerBtn;
    public bool inventaireEstMontre;
    public bool inventaireEstUtilise;

    public GameObject btnEnlever;
    public GameObject btnAnnuler;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inventaireEstUtilise)
        {
            if (peutMontrerBtn)
            {
                btnEnlever.SetActive(true);
                btnAnnuler.SetActive(true);
                carteZoom.SetActive(true);
            }
            else
            {
                btnEnlever.SetActive(false);
                btnAnnuler.SetActive(false);
                carteZoom.SetActive(false);
            }
        }
    }


    public void MontrerInventaire()
    {
        inventaireEstMontre = true;
        foreach (var carte in Deck.deckStat)
        {
            GameObject carteDupliquee = Instantiate(carte.GetComponent<carteProfil>().prefabInventaire, grille.GetComponent<Transform>());
            carteDupliquee.GetComponent<comportementInventaireCarte>().grilleInventaire = gameObject;
            carteDupliquee.GetComponent<comportementInventaireCarte>().btnInventaire = btnEnlever;
            carteDupliquee.GetComponent<comportementInventaireCarte>().carteZoom = carteZoom;
            cartesInventaire = librairie.GetComponent<librairieDeck>().ajouterCarte(cartesInventaire, carteDupliquee);
        }
        grille.transform.SetSiblingIndex(100);
        carteZoom.transform.SetSiblingIndex(100);
        btnAnnuler.transform.SetSiblingIndex(100);
        btnEnlever.transform.SetSiblingIndex(100);
        grille.SetActive(true);

        int index = 0;
        foreach (var carte in cartesInventaire)
        {
            float scale = carte.GetComponent<RectTransform>().localScale.x;
            carte.GetComponent<comportementInventaireCarte>().scaleInitial = scale;
            carte.GetComponent<comportementInventaireCarte>().indexInventaire = index;
            index++;
        }
    }

    public void FermerInventaire()
    {
        foreach (var carte in cartesInventaire)
        {
            Destroy(carte);
        }
        foreach (var carte in cartesInventaire)
        {
            cartesInventaire = librairie.GetComponent<librairieDeck>().enleverCarte(cartesInventaire, 0);
        }
        inventaireEstMontre = false;
        grille.SetActive(false);
    }
}
