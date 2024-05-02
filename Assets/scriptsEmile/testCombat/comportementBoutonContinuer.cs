using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class comportementBoutonContinuer : MonoBehaviour
{
    public GameObject librairie;
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
            SceneManager.LoadScene("testEmileCombat");
        }
        /*else
        {
            
        }*/
    }
}
