using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bouttonAjoutTest : MonoBehaviour
{
    public GameObject[] listeLocale;
    static GameObject[] listeStatique;
    public GameObject[] listeStatiqueDebug;
    public GameObject nouvelleCarte;

    public GameObject librairies;

    // Start is called before the first frame update
    void Start()
    {
        listeStatique = listeStatiqueDebug;
        listeLocale = listeStatique;
    }


    public void setup()
    {
        listeLocale = librairies.GetComponent<librairieDeck>().ajouterCarte(listeLocale, nouvelleCarte);
    }
}
