using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comportementCible : MonoBehaviour
{
    public GameObject joueur;
    public GameObject parent;
    public bool enAttaque;
    public bool CibleTrouve;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void clique()
    {
       joueur.GetComponent<comportementJoueur>().ennemiAAttaque = parent;
       joueur.GetComponent<comportementJoueur>().enAttaque = false;
       joueur.GetComponent<comportementJoueur>().cibleTrouve = true;
       gameObject.SetActive(false);
    }
}
