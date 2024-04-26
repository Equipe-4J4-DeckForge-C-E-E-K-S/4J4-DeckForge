using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class librairieAttaque : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AttaquerNormal(GameObject cible, float attaque, bool typeEau, bool typeFeu, bool typePlante)
    {
        float defCible = cible.GetComponent<statistiquesPersonnage>().defense;
        bool typeEauCible = cible.GetComponent<statistiquesPersonnage>().typeEau;
        bool typeFeuCible = cible.GetComponent<statistiquesPersonnage>().typeFeu;
        bool typePlanteCible = cible.GetComponent<statistiquesPersonnage>().typePlante;

        if (typeEau && typeFeuCible)
        {
            cible.GetComponent<statistiquesPersonnage>().vie -= ((attaque * ((10 - defCible) / 10)) * 2);
        }
        else if (typeFeu && typePlanteCible)
        {
            cible.GetComponent<statistiquesPersonnage>().vie -= ((attaque * ((10 - defCible) / 10)) * 2);
        }
        else if (typePlante && typeEauCible)
        {
            cible.GetComponent<statistiquesPersonnage>().vie -= ((attaque * ((10 - defCible) / 10)) * 2);
        }
        else if (typeEau && typePlanteCible)
        {
            cible.GetComponent<statistiquesPersonnage>().vie -= ((attaque * ((10 - defCible) / 10)) * 0.5f);
        }
        else if (typeFeu && typeEauCible)
        {
            cible.GetComponent<statistiquesPersonnage>().vie -= ((attaque * ((10 - defCible) / 10)) * 0.5f);
        }
        else if (typePlante && typeFeuCible)
        {
            cible.GetComponent<statistiquesPersonnage>().vie -= ((attaque * ((10 - defCible) / 10)) * 0.5f);
        }
        else
        {
            cible.GetComponent<statistiquesPersonnage>().vie -= (attaque * ((10 - defCible) / 10));
        }
    }
}
