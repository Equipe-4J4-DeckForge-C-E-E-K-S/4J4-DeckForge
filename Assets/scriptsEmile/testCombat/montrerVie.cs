using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class montrerVie : MonoBehaviour
{
    public TextMeshProUGUI urmom;
    public GameObject personnage;
    public float vie;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vie = personnage.GetComponent<statistiquesPersonnage>().vie;
        urmom.text = vie.ToString();
    }
}