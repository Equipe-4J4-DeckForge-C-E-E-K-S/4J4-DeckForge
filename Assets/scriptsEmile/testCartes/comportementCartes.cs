using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comportementCartes : MonoBehaviour
{
    public GameObject[] ligma;
    static GameObject[] balls;
    public GameObject[] ballsDebug;
    public GameObject[] nouveauDeck;
    public int index;
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
        //ajouterCarte();
        enleverCarte();
    }


    public void ajouterCarte()
    {
        nouveauDeck = new GameObject[ligma.Length + 1];
        index = 0;
        foreach (var carte in nouveauDeck)
        {
            if (index < ligma.Length)
            {
                Debug.Log(index);
                nouveauDeck[index] = ligma[index];
            }
            else
            {
                nouveauDeck[index] = nouvelleCarte;
                Debug.Log("nouvelle carte");
            }
            index++;
        }
        ligma = nouveauDeck;
    }
    
    public void enleverCarte()
    {
        nouveauDeck = new GameObject[ligma.Length - 1];
        index = 0;
        foreach (var carte in nouveauDeck)
        {
            //if (index < ligma.Length-1)
            //{
                Debug.Log(index);
                nouveauDeck[index] = ligma[index];
            //}
            //else
            //{
                //nouveauDeck[index] = nouvelleCarte;
                //Debug.Log("nouvelle carte");
            //}
            index++;
        }
        ligma = nouveauDeck;
    }
}
