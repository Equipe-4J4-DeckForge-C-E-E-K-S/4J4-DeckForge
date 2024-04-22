using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class montrerStatusAttaque : MonoBehaviour
{
    public TextMeshProUGUI urmom;
    public TextMeshProUGUI urdad;
    public GameObject personnage;
    public bool cibleTrouve;
    public bool enAttaque;

    void Start() 
    {
    }

    // Update is called once per frame
    void Update()
    {
        enAttaque = personnage.GetComponent<comportementJoueur>().enAttaque;
        cibleTrouve = personnage.GetComponent<comportementJoueur>().cibleTrouve;
        urmom.text = "Cible trouvée: " + cibleTrouve.ToString();
        urdad.text = "En attaque: " + enAttaque.ToString();
    }
}
