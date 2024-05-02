using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class librairieDeck : MonoBehaviour
{
    public GameObject[] deckDebug;

    public GameObject[] ajouterCarte(GameObject[] deckUtilise, GameObject carteAAjouter)
    {
        GameObject[] nouveauDeck = new GameObject[deckUtilise.Length + 1];
        int index = 0;
        foreach (var carte in nouveauDeck)
        {
            if (index < deckUtilise.Length)
            {
                nouveauDeck[index] = deckUtilise[index];
            }
            else
            {
                nouveauDeck[index] = carteAAjouter;
            }
            index++;
        }
        return nouveauDeck;
    }
    
    public GameObject[] enleverCarte(GameObject[] deckUtlise, int indexAEnlever)
    {
        GameObject[] nouveauDeck = new GameObject[deckUtlise.Length - 1];
        int index = 0;
        foreach (var carte in nouveauDeck)
        {
            if (index < indexAEnlever)
            {
                nouveauDeck[index] = deckUtlise[index];
            }
            else if (index >= indexAEnlever)
            {
                nouveauDeck[index] = deckUtlise[index + 1];
            }
            index++;
        }
        return nouveauDeck;
    }
    
    public GameObject[] SufflerCartes(GameObject[] deckUtilise)
    {
        GameObject[] nouveauDeck = new GameObject[deckUtilise.Length];
        int algorithmeChoisi = 0;
        int nbShuffleAFaire = Random.Range(1, 6);
        for (int i = 0; i < nbShuffleAFaire; i++)
        {
            algorithmeChoisi = Random.Range(0, 2);
            if (algorithmeChoisi == 0)
            {
                nouveauDeck = SauterOrdreCartes(deckUtilise);
                nouveauDeck = InverserOrdreCartes(nouveauDeck);
            }
            else
            {
                nouveauDeck = InverserOrdreCartes(deckUtilise);
                nouveauDeck = SauterOrdreCartes(nouveauDeck);
            }
        }
        
        return nouveauDeck;
    }

    private GameObject[] SauterOrdreCartes(GameObject[] deckUtilise)
    {
        GameObject[] nouveauDeck = new GameObject[deckUtilise.Length];
        int index = 0;
        foreach (var carte in nouveauDeck)
        {
            if (index < deckUtilise.Length-1)
            {
                nouveauDeck[index] = deckUtilise[index + 1];
            }
            else if (index == deckUtilise.Length-1)
            {
                nouveauDeck[index] = deckUtilise[0];
            }
            index++;
        }
        return nouveauDeck;
    }

    private GameObject[] InverserOrdreCartes(GameObject[] deckUtilise)
    {
        GameObject[] nouveauDeck = new GameObject[deckUtilise.Length];
        int index = 0;
        bool inverse = true;
        foreach (var carte in nouveauDeck)
        {
            if (inverse)
            {
                if (index + 1 < deckUtilise.Length)
                {
                    nouveauDeck[index] = deckUtilise[index + 1];
                }
                else if (index + 1 == deckUtilise.Length)
                {
                    nouveauDeck[index] = deckUtilise[(deckUtilise.Length -1)];
                }
            }
            else
            {
                nouveauDeck[index] = deckUtilise[index - 1];
            }
            inverse = !inverse;
            index++;
        }
        return nouveauDeck;
    }
}
