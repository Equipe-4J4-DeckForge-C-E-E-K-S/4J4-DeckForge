using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class montrerAttaque : MonoBehaviour
{
    public TextMeshProUGUI urmom;
    public GameObject personnage;
    public float attaque;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        attaque = personnage.GetComponent<statistiquesPersonnage>().attaque;
        urmom.text = attaque.ToString();
    }
}
