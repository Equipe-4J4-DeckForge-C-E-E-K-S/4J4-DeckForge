using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class montrerDefense : MonoBehaviour
{
    public TextMeshProUGUI urmom;
    public GameObject personnage;
    public float defense;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        defense = personnage.GetComponent<statistiquesPersonnage>().defense;
        urmom.text = defense.ToString();
    }
}
