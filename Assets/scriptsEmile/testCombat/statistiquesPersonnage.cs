using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statistiquesPersonnage : MonoBehaviour
{
    public float vie;
    public float defense;
    public float defenseInitiale;
    public float attaque;

    public bool typeBasique;
    public bool typeEau;
    public bool typeFeu;
    public bool typePlante;

    // Start is called before the first frame update
    void Start()
    {
        defenseInitiale = defense;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
