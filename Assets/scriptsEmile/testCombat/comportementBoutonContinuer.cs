using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class comportementBoutonContinuer : MonoBehaviour
{
    public GameObject librairie;
    public GameObject joueur;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changerScene() 
    {
        bool resultat = librairie.GetComponent<comportementFin>().resultatNiveau;
        
        if(resultat)
        {
            comportementJoueur.viePartie = (joueur.GetComponent<statistiquesPersonnage>().vie + 20f);
            comportementGestionnaireEnnemi.difficulte += 0.5f;
            SceneManager.LoadScene("TUNNEL");
        }
    }
}
