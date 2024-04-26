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
            float attaqueTotale = (attaque * ((10 - defCible) / 10));
            if (attaqueTotale < 0)
            {
                attaqueTotale = 0;
            }
            cible.GetComponent<statistiquesPersonnage>().vie -= attaqueTotale;
            cible.GetComponent<statistiquesPersonnage>().vie -= ((attaque * ((10 - defCible) / 10)) * 2);
            float vieCible = cible.GetComponent<statistiquesPersonnage>().vie;
            cible.GetComponent<statistiquesPersonnage>().vie = Mathf.Round(vieCible * 10.0f) * 0.1f;
        }
        else if (typeFeu && typePlanteCible)
        {
            float attaqueTotale = (attaque * ((10 - defCible) / 10));
            if (attaqueTotale < 0)
            {
                attaqueTotale = 0;
            }
            cible.GetComponent<statistiquesPersonnage>().vie -= attaqueTotale;
            cible.GetComponent<statistiquesPersonnage>().vie -= ((attaque * ((10 - defCible) / 10)) * 2);
            float vieCible = cible.GetComponent<statistiquesPersonnage>().vie;
            cible.GetComponent<statistiquesPersonnage>().vie = Mathf.Round(vieCible * 10.0f) * 0.1f;
        }
        else if (typePlante && typeEauCible)
        {
            float attaqueTotale = (attaque * ((10 - defCible) / 10));
            if (attaqueTotale < 0)
            {
                attaqueTotale = 0;
            }
            cible.GetComponent<statistiquesPersonnage>().vie -= attaqueTotale;
            cible.GetComponent<statistiquesPersonnage>().vie -= ((attaque * ((10 - defCible) / 10)) * 2);
            float vieCible = cible.GetComponent<statistiquesPersonnage>().vie;
            cible.GetComponent<statistiquesPersonnage>().vie = Mathf.Round(vieCible * 10.0f) * 0.1f;
        }
        else if (typeEau && typePlanteCible)
        {
            float attaqueTotale = (attaque * ((10 - defCible) / 10));
            if (attaqueTotale < 0)
            {
                attaqueTotale = 0;
            }
            cible.GetComponent<statistiquesPersonnage>().vie -= attaqueTotale;
            cible.GetComponent<statistiquesPersonnage>().vie -= ((attaque * ((10 - defCible) / 10)) * 0.5f);
            float vieCible = cible.GetComponent<statistiquesPersonnage>().vie;
            cible.GetComponent<statistiquesPersonnage>().vie = Mathf.Round(vieCible * 10.0f) * 0.1f;
        }
        else if (typeFeu && typeEauCible)
        {
            float attaqueTotale = (attaque * ((10 - defCible) / 10));
            if (attaqueTotale < 0)
            {
                attaqueTotale = 0;
            }
            cible.GetComponent<statistiquesPersonnage>().vie -= attaqueTotale;
            cible.GetComponent<statistiquesPersonnage>().vie -= ((attaque * ((10 - defCible) / 10)) * 0.5f);
            float vieCible = cible.GetComponent<statistiquesPersonnage>().vie;
            cible.GetComponent<statistiquesPersonnage>().vie = Mathf.Round(vieCible * 10.0f) * 0.1f;
        }
        else if (typePlante && typeFeuCible)
        {
            float attaqueTotale = (attaque * ((10 - defCible) / 10));
            if (attaqueTotale < 0)
            {
                attaqueTotale = 0;
            }
            cible.GetComponent<statistiquesPersonnage>().vie -= attaqueTotale;
            cible.GetComponent<statistiquesPersonnage>().vie -= ((attaque * ((10 - defCible) / 10)) * 0.5f);
            float vieCible = cible.GetComponent<statistiquesPersonnage>().vie;
            cible.GetComponent<statistiquesPersonnage>().vie = Mathf.Round(vieCible * 10.0f) * 0.1f;
        }
        else
        {
            float attaqueTotale = (attaque * ((10 - defCible) / 10));
            if (attaqueTotale < 0)
            {
                attaqueTotale = 0;
            }
            cible.GetComponent<statistiquesPersonnage>().vie -= attaqueTotale;
            float vieCible = cible.GetComponent<statistiquesPersonnage>().vie;
            cible.GetComponent<statistiquesPersonnage>().vie = Mathf.Round(vieCible * 10.0f) * 0.1f;
        }
    }
}
