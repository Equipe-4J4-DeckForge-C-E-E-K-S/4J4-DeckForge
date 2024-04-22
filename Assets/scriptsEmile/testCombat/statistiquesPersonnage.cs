using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statistiquesPersonnage : MonoBehaviour
{
    public float vie;
    public float defense;
    public float attaque;

    public bool typeBasique;
    public bool typeEau;
    public bool typeFeu;
    public bool typePlante;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (vie <= 0) {
            //Destroy(gameObject);
        }
    }
}
