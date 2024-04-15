using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bouttonSuprimmerTest : MonoBehaviour
{
    public int indexAEnlever;
    public GameObject listeGameObject;
    public GameObject[] listeCherche;
    public GameObject librairies;

    public void Update()
    {
        listeCherche = listeGameObject.GetComponent<bouttonAjoutTest>().listeLocale;
    }

    public void setup()
    {
        listeGameObject.GetComponent<bouttonAjoutTest>().listeLocale = librairies.GetComponent<librairieDeck>().enleverCarte(listeCherche, indexAEnlever);
    }
}
