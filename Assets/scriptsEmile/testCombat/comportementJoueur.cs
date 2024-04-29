using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comportementJoueur : MonoBehaviour
{
    public GameObject ennemiAAttaque;
    public GameObject objetADupliquer;
    public Transform canvas;
    public bool enAttaque;
    public bool cibleTrouve;
    public float floatX;
    public float floatY;

    public GameObject librairie;

   //public GameObject deck;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(GetComponent<statistiquesPersonnage>().vie <= 0)
        {
            librairie.GetComponent<comportementFin>().FinirNiveau(false);
        }   
    }
}
