using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comportementEnnemi : MonoBehaviour
{
    public GameObject joueur;
    public GameObject cible;
    public bool enAttaque;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enAttaque = joueur.GetComponent<comportementJoueur>().enAttaque;
        if (enAttaque)
        {
            cible.SetActive(true);
        }
    }
}
