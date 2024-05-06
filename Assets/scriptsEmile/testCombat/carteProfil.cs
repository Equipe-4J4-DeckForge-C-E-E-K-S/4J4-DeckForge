using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class carteProfil : MonoBehaviour
{
    public bool attaquer;
    public bool bloquer;
    public bool soigner;
    public GameObject prefab;

    public Image imgButton;

    public int index;

    public bool typeBasique;
    public bool typeEau;
    public bool typeFeu;
    public bool typePlante;


    void OnMouseOver()
    {
        imgButton.GetComponent<Image>().color = new Color32(190, 190, 190, 255);
        Debug.Log("Mouse is over GameObject.");
    }

    void OnMouseExit()
    {
        imgButton.GetComponent<Image>().color = new Color32(190, 190, 190, 255);
        Debug.Log("Mouse is no longer on GameObject.");
    }
}