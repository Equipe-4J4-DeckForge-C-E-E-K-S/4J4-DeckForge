using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class comportementFin : MonoBehaviour
{
    public GameObject deck;
    public bool test;
    public bool finNiveau;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (test)
        {
            FinirNiveau();
        }
    }

    public void FinirNiveau()
    {
        finNiveau = true;

        for (int i=0; i < (deck.GetComponent<Deck>().deckJoueur.Length); i++)
        {
            deck.GetComponent<Deck>().deckJoueur[i].GetComponent<Button>().enabled = false;
            //Debug.Log("oki");
        }
    }
}
