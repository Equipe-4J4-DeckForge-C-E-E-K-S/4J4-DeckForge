using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soin : MonoBehaviour
{

    public GameObject personnage;
    public float vie;
    public bool estClique;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Soigner()
    {
            vie = personnage.GetComponent<statistiquesPersonnage>().vie;
            vie += 2;
            personnage.GetComponent<statistiquesPersonnage>().vie = vie;
            estClique = false;
    }
}
