using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Choixporte : MonoBehaviour
{
    public Material outlineMaterial; // Materiel de selection
    public string SceneACharger; //Nom de la scene a loader quand on clique
    private Material originalMaterial;

    void Start()
    {
        // Storage pour le mat�riel original
        originalMaterial = GetComponent<Renderer>().material;
    }

    void OnMouseEnter()
    {
        // Remplacement du materiel de base avec le mat�riel de selection
        GetComponent<Renderer>().material = outlineMaterial;
    }

    void OnMouseExit()
    {
        // Restoration du materiel de base
        GetComponent<Renderer>().material = originalMaterial;
    }
    void OnMouseDown()
    {
        //Regarde si l'object est vraiment une "porte"
        if (SceneACharger != "" && IsDoor())
        {
            // Charge la scene associ�e..
            SceneManager.LoadScene(SceneACharger);
        }
    }

    bool IsDoor()
    {
        //Retourne le tag "porte" comme v�rification
        return gameObject.CompareTag("Porte");
    }
}
