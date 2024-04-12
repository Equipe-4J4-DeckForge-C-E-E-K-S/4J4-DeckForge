using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comportementJoueur : MonoBehaviour
{
    public GameObject ennemiAAttaque;
    public GameObject objetADupliquer;
    public GameObject ligma;
    public Transform canvas;
    public bool enAttaque;
    public bool cibleTrouve;
    public float floatX;
    public float floatY;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        /*Vector2 pos = objetADupliquer.GetComponent<RectTransform>().anchoredPosition;
        pos.x = floatX;
        pos.y = floatY;
        gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(pos.x, pos.y);
        if (enAttaque == false)
        {
            
            ligma = Instantiate(objetADupliquer, canvas);
            enAttaque = true;
        }
        ligma.GetComponent<RectTransform>().anchoredPosition = new Vector2(pos.x, pos.y);*/
    }
}
