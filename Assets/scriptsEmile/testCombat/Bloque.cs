using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloque : MonoBehaviour
{

    public GameObject personnage;
    public float defense;
    public bool estClique;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Bloquer()
    {
        if(estClique){
            defense = personnage.GetComponent<statistiquesPersonnage>().defense;
            defense *= 2;
            personnage.GetComponent<statistiquesPersonnage>().defense = defense;
            estClique = false;
        }
    }
}
