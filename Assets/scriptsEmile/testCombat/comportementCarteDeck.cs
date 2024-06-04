using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
// using static UnityEditor.PlayerSettings;

public class comportementCarteDeck : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject deck;
    public GameObject inventaire;
    public bool peutDistancierCartes;
    public bool peutRapprocherCartes;

    public bool inventaireEstMontre;
    
    public int index;
    public float distanceVersGauche;
    public float distanceVersDroite;

    public float posXDebug;

    public float ecart;

    public bool ennemisRemisEnPlace = true;

    void Update() 
    {
        inventaireEstMontre = inventaire.GetComponent<comportementInventaire>().inventaireEstMontre;
        index = GetComponent<carteProfil>().index;
        if (inventaireEstMontre == false)
        {
            RapprocherCartes();
            DistancerCartes();
        }
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        peutDistancierCartes = true;
        peutRapprocherCartes = false;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        peutRapprocherCartes = true;
        peutDistancierCartes = false;
        ennemisRemisEnPlace = true;
    }

    public void DistancerCartes() 
    {
        if (peutDistancierCartes)
        {
            if (ennemisRemisEnPlace)
            {
                for (int i = 0; i < deck.GetComponent<Deck>().deckJoueur.Length; i++)
                {
                    Vector2 pos = deck.GetComponent<Deck>().deckJoueur[i].GetComponent<RectTransform>().anchoredPosition;
                    deck.GetComponent<Deck>().deckJoueur[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(deck.GetComponent<Deck>().deckJoueur[i].GetComponent<carteProfil>().posXinitial, pos.y);
                }
                ennemisRemisEnPlace = false;
            }

            for (int i = 0; i < deck.GetComponent<Deck>().deckJoueur.Length; i++)
            {
                if (i < index)
                {
                    Vector2 pos = deck.GetComponent<Deck>().deckJoueur[i].GetComponent<RectTransform>().anchoredPosition;

                    if ((deck.GetComponent<Deck>().deckJoueur[i].GetComponent<carteProfil>().posXinitial - (ecart/2)) < pos.x)
                    {
                        pos.x -= distanceVersGauche * Time.deltaTime;
                        posXDebug = pos.x;
                    }
                    else
                    {
                        pos.x = (deck.GetComponent<Deck>().deckJoueur[i].GetComponent<carteProfil>().posXinitial - (ecart / 2));

                        if (index == (deck.GetComponent<Deck>().deckJoueur.Length - 1))
                        {
                            if (i == (deck.GetComponent<Deck>().deckJoueur.Length - 2))
                            {
                                peutRapprocherCartes = false;
                            }
                        }
                    }
                    deck.GetComponent<Deck>().deckJoueur[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(pos.x, pos.y);
                }
                else if (i > index)
                {
                    Vector2 pos = deck.GetComponent<Deck>().deckJoueur[i].GetComponent<RectTransform>().anchoredPosition;

                    if ((deck.GetComponent<Deck>().deckJoueur[i].GetComponent<carteProfil>().posXinitial + (ecart / 2)) > pos.x)
                    {
                        pos.x += distanceVersDroite * Time.deltaTime;
                    }
                    else
                    {
                        pos.x = (deck.GetComponent<Deck>().deckJoueur[i].GetComponent<carteProfil>().posXinitial + (ecart / 2));

                        if (i == (deck.GetComponent<Deck>().deckJoueur.Length - 1))
                        {
                            peutDistancierCartes = false;
                        }
                    }
                    deck.GetComponent<Deck>().deckJoueur[i].GetComponent<comportementCarteDeck>().posXDebug = pos.x;
                    deck.GetComponent<Deck>().deckJoueur[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(pos.x, pos.y);
                }
            }
        }
    }

    public void RapprocherCartes()
    {
        if (peutRapprocherCartes)
        {

            for (int i = 0; i < deck.GetComponent<Deck>().deckJoueur.Length; i++)
            {
                if (i < index)
                {
                    Vector2 pos = deck.GetComponent<Deck>().deckJoueur[i].GetComponent<RectTransform>().anchoredPosition;

                    if (deck.GetComponent<Deck>().deckJoueur[i].GetComponent<carteProfil>().posXinitial > pos.x)
                    {
                        pos.x += distanceVersGauche * Time.deltaTime;
                        posXDebug = pos.x;
                    }
                    else
                    {
                        pos.x = deck.GetComponent<Deck>().deckJoueur[i].GetComponent<carteProfil>().posXinitial;

                        if (index == (deck.GetComponent<Deck>().deckJoueur.Length - 1))
                        {
                            if (i == (deck.GetComponent<Deck>().deckJoueur.Length - 2))
                            {
                                peutRapprocherCartes = false;
                            }
                        }
                        
                    }
                    deck.GetComponent<Deck>().deckJoueur[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(pos.x, pos.y);
                }
                else if (i > index)
                {
                    Vector2 pos = deck.GetComponent<Deck>().deckJoueur[i].GetComponent<RectTransform>().anchoredPosition;
                    if (deck.GetComponent<Deck>().deckJoueur[i].GetComponent<carteProfil>().posXinitial < pos.x)
                    {
                        pos.x -= distanceVersDroite * Time.deltaTime;
                    }
                    else
                    {
                        pos.x = deck.GetComponent<Deck>().deckJoueur[i].GetComponent<carteProfil>().posXinitial;
                        if (i == (deck.GetComponent<Deck>().deckJoueur.Length - 1))
                        {
                            peutRapprocherCartes = false;
                        }
                    }
                    deck.GetComponent<Deck>().deckJoueur[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(pos.x, pos.y);
                }
            }
        }
    }
}