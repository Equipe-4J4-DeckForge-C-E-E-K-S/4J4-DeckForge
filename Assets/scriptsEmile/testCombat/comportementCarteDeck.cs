using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings;

public class comportementCarteDeck : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject deck;
    public bool peutDistancierCartes;
    public bool peutRapprocherCartes;
    public int index;
    public float distanceVersGauche;
    public float distanceVersDroite;

    public float ecart;


    void Update() 
    {
        index = GetComponent<carteProfil>().index;
        RapprocherCartes();
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        DistancerCartes();
        Debug.Log("Mouse enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        peutRapprocherCartes = true;
        Debug.Log("Mouse exit");
    }

    public void DistancerCartes() 
    {
        for (int i = 0; i < deck.GetComponent<Deck>().deckJoueur.Length; i++)
        {
            if (i < index)
            {
                Vector2 pos = deck.GetComponent<Deck>().deckJoueur[i].GetComponent<RectTransform>().anchoredPosition;
                if ((deck.GetComponent<Deck>().deckJoueur[i].GetComponent<carteProfil>().posXinitial - ecart) < pos.x)
                {
                    pos.x -= distanceVersGauche * Time.deltaTime;
                }
                else
                {
                    pos.x = (deck.GetComponent<Deck>().deckJoueur[i].GetComponent<carteProfil>().posXinitial - ecart);
                }
                deck.GetComponent<Deck>().deckJoueur[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(pos.x, pos.y);
            }
            else if (i > index)
            {
                Vector2 pos = deck.GetComponent<Deck>().deckJoueur[i].GetComponent<RectTransform>().anchoredPosition;
                if ((deck.GetComponent<Deck>().deckJoueur[i].GetComponent<carteProfil>().posXinitial + ecart) > pos.x)
                {
                    pos.x += distanceVersDroite * Time.deltaTime;
                }
                else
                {
                    pos.x = (deck.GetComponent<Deck>().deckJoueur[i].GetComponent<carteProfil>().posXinitial + ecart);
                }
                deck.GetComponent<Deck>().deckJoueur[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(pos.x, pos.y);
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
                    }
                    else
                    {
                        pos.x = deck.GetComponent<Deck>().deckJoueur[i].GetComponent<carteProfil>().posXinitial;
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
                        pos.x = deck.GetComponent<Deck>().deckJoueur[i].GetComponent<carteProfil>().posXinitial + ecart;
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