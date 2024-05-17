using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bouttonFinTour : MonoBehaviour
{

    public GameObject deck;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (deck.GetComponent<Deck>().tourJoueur)
        {
            GetComponent<Button>().enabled = true;
        }
        else
        {
            GetComponent<Button>().enabled = false;
        }
    }

    public void FinirTour()
    {
        deck.GetComponent<Deck>().tourJoueur = false;
        deck.GetComponent<Deck>().tourEnnemi = true;
    }
}