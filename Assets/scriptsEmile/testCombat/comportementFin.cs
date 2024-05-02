using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class comportementFin : MonoBehaviour
{
    public GameObject deck;
    public bool test;
    public bool finNiveau;

    public GameObject messageVictoire;
    public GameObject messageDefaite;
    public GameObject bouton;

    public bool resultatNiveau;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (test)
        {
            FinirNiveau(true);
        }   
    }

    public void FinirNiveau(bool victoire)
    {
        finNiveau = true;

        for (int i=0; i < (deck.GetComponent<Deck>().deckJoueur.Length); i++)
        {
            deck.GetComponent<Deck>().deckJoueur[i].GetComponent<Button>().enabled = false;
        }

        if (victoire)
        {
            messageVictoire.SetActive(true);
            resultatNiveau = true;
            bouton.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene("GAMEOVER");
        }

    }
}
