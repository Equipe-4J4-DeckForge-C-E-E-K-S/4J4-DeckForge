using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bouttonShuffletest : MonoBehaviour
{
    public GameObject listeGameObject;
    public GameObject librairies;
    public GameObject[] listeCherche;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        listeCherche = listeGameObject.GetComponent<bouttonAjoutTest>().listeLocale;
    }

    public void setUp() 
    {
        listeGameObject.GetComponent<bouttonAjoutTest>().listeLocale = librairies.GetComponent<librairieDeck>().SufflerCartes(listeCherche);
    }
}
