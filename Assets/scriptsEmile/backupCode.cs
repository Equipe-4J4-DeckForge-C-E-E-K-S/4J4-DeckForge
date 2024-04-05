using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backupCode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int xcount = Random.Range(1, 6);
    }

    // Update is called once per frame
    void Update()
    {
    }



    public int CheckerIndexAleatoire(int indexUtilise, int[] indexUtilises, GameObject[] deckUtilise)
    {
        int index = 0;
        indexUtilise = Random.Range(0, (deckUtilise.Length - 1));
        foreach (var indexAChecker in indexUtilises)
        {
            if (indexUtilise == indexUtilises[index])
            {

            }
            index++;
        }
        return indexUtilise;
    }

    /*public GameObject[] SufflerCartes(GameObject[] deckUtilise)
{
    GameObject[] nouveauDeck = new GameObject[deckUtilise.Length];
    int[] indexUtilises = new int[0];
    int index = 0;
    int indexAleatoire = 0;
    foreach (var carte in deckUtilise)
    {
        indexAleatoire = Random.Range(0, (deckUtilise.Length - 1));//CheckerIndexAleatoire(indexAleatoire, indexUtilises, deckUtilise);
        nouveauDeck[index] = deckUtilise[indexAleatoire];
        index++;
        indexUtilises = EnregistrerNouveauIndex(indexUtilises, indexAleatoire);//pour debugger maintenant
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
    return nouvelEnregistrementIndexs;*/
}
