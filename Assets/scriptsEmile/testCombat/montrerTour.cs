using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class montrerTour : MonoBehaviour
{
    public GameObject deck;
    public TextMeshProUGUI typeTour;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (deck.GetComponent<Deck>().tourJoueur) 
        {
            typeTour.text = "Tour: Joueur";
        }
        else
        {
            typeTour.text = "Tour: Ennemi";
        }
    }
}