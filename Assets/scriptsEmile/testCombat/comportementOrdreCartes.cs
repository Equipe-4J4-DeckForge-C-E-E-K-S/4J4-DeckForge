using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class comportementOrdreCartes : MonoBehaviour
{
    public int[] carteOrdreDebug;
    public GameObject deck;
    public GameObject objetAcheck;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void DireOrdreCartes()
    {
        //int spriteOrder = objetAcheck.transform.GetSiblingIndex();
        //objetAcheck.transform.SetSiblingIndex(100);
        //Debug.Log(spriteOrder);

        int index = 0;
        foreach (var carte in deck.GetComponent<Deck>().deckJoueur)
        {
            //int spriteOrder = carte.transform.GetSiblingIndex();
            //Debug.Log(spriteOrder);
            //carte.transform.SetSiblingIndex(0);
        }
    }
}
