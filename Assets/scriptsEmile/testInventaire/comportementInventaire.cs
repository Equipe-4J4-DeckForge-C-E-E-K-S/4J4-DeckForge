using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comportementInventaire : MonoBehaviour
{
    public GameObject grille;
    public GameObject[] cartesInventaire;
    public GameObject librairie;
    public GameObject deck;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void MontrerInventaire()
    {
        foreach (var carte in Deck.deckStat)
        {
            GameObject carteDupliquee = Instantiate(carte/*.GetComponent<carteProfil>().prefabInventaire*/, grille.GetComponent<Transform>());
            cartesInventaire = librairie.GetComponent<librairieDeck>().ajouterCarte(cartesInventaire, carteDupliquee);
        }
        grille.SetActive(false);
        foreach (var carte in cartesInventaire)
        {
            Vector2 pos = carte.GetComponent<RectTransform>().anchoredPosition;
            float scale = carte.GetComponent<RectTransform>().localScale.x;

            carte.GetComponent<comportementInventaireCarte>().posYInitial = pos.y;
            carte.GetComponent<comportementInventaireCarte>().scaleInitial = scale;
        }
    }
}
