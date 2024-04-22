using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comportementJoueur : MonoBehaviour
{
    public GameObject ennemiAAttaque;
    public GameObject objetADupliquer;
    public GameObject[] ligma;
    public Transform canvas;
    public bool enAttaque;
    public bool cibleTrouve;
    public float floatX;
    public float floatY;

   //public GameObject deck;

    // Start is called before the first frame update
    void Start()
    {
        ligma = Deck.deckStat;
        /*foreach (var carte in ligma)
        {
            
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
