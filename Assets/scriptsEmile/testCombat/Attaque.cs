using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attaque : MonoBehaviour
{
    public GameObject personnage;
    public GameObject cible;
    public float attaque;
    public bool estClique;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attaquer()
    {
        attaque = personnage.GetComponent<statistiquesPersonnage>().attaque;
        cible = personnage.GetComponent<comportementJoueur>().ennemiAAttaque;
        personnage.GetComponent<comportementJoueur>().ennemiAAttaque.GetComponent<statistiquesPersonnage>().vie -= attaque;
        estClique = false;
    }
}
