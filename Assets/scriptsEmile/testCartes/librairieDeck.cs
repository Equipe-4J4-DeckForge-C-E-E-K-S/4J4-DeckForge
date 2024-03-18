using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class librairieDeck : MonoBehaviour
{
    public GameObject[] ajouterCarte(GameObject[] deckUtilise, GameObject carteAAjouter)
    {
        GameObject[] nouveauDeck = new GameObject[deckUtilise.Length + 1];
        int index = 0;
        foreach (var carte in nouveauDeck)
        {
            if (index < deckUtilise.Length)
            {
                Debug.Log(index);
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
}
