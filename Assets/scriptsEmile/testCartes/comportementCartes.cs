using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comportementCartes : MonoBehaviour
{
    public GameObject[] ligma;
    static GameObject[] balls;
    public GameObject[] ballsDebug;
    //public GameObject[] nouveauDeck;
    public int index2;
    public GameObject nouvelleCarte;

    // Start is called before the first frame update
    void Start()
    {
        //ballsDebug = new GameObject[10];
        balls = ballsDebug;
        ligma = balls;
    }

    // Update is called once per frame
    void Update()
    {
        balls = ballsDebug;
        
    }

    public void setup()
    {
        //ligma = ajouterCarte(ligma, nouvelleCarte);
        ligma = enleverCarte(ligma, index2);
    }


    public GameObject[] ajouterCarte(GameObject[] deckUtilise, GameObject carteAAjouter)
    {
        GameObject[] nouveauDeck = new GameObject[deckUtilise.Length + 1];
        int index = 0;
        foreach (var carte in nouveauDeck)
        {
            if (index < ligma.Length)
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
