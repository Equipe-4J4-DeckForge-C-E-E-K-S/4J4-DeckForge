using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class librairieDeck : MonoBehaviour
{
    public int[] indexsDebug;

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
        int[] indexUtilises = new int[0];
        int index = 0;
        int indexAleatoire = 0;
        foreach (var carte in deckUtilise)
        {
            Debug.Log(deckUtilise.Length);
            indexAleatoire = Random.Range(0, (deckUtilise.Length - 1));

            index++;
            indexUtilises = EnregistrerNouveauIndex(indexUtilises, indexAleatoire);
        }
        indexsDebug = indexUtilises;

        return nouveauDeck;
    }

    public int[] EnregistrerNouveauIndex(int[] indexEnregistres, int nouveauIndex)
    {
        int index = 0;
        int[] nouvelEnregistrementIndexs = new int[indexEnregistres.Length + 1];
        foreach (var indexUtilise in nouvelEnregistrementIndexs)
        {
            if (index < indexEnregistres.Length)
            {
                nouvelEnregistrementIndexs[index] = indexEnregistres[index];
            }
            else
            {
                nouvelEnregistrementIndexs[index] = nouveauIndex;
            }
            index++;
        }
        return nouvelEnregistrementIndexs;
    }
}
