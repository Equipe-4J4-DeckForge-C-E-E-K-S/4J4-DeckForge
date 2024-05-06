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
    public int distanceVersGauche;
    public int distanceVersDroite;


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
        RapprocherCartes();
        Debug.Log("Mouse exit");
    }

    public void DistancerCartes() 
    {
    
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
                    if ()
                    {
                        pos.x -= distanceVersGauche;
                    }
                    deck.GetComponent<Deck>().deckJoueur[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(pos.x, pos.y);
                }
                else if (i > index)
                {
                    Vector2 pos = deck.GetComponent<Deck>().deckJoueur[i].GetComponent<RectTransform>().anchoredPosition;
                    pos.x -= distanceVersDroite;
                    deck.GetComponent<Deck>().deckJoueur[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(pos.x, pos.y);
                }
            }
        }
    }
}