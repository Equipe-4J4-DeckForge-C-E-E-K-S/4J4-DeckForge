using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comportementFleche : MonoBehaviour
{
    public Texture2D cursorTexture;
    public Vector2 cursorHotspot;

    public GameObject joueur;
    public bool enAttaque;

    private void Update()
    {
        if (joueur.GetComponent<comportementJoueur>().enAttaque)
        {
            cursorHotspot = new Vector2(cursorTexture.width / 2, cursorTexture.height / 2);
            Cursor.SetCursor(cursorTexture, cursorHotspot, CursorMode.Auto);
        }
        else
        {
            Cursor.SetCursor(null, cursorHotspot, CursorMode.Auto);
        }
        enAttaque = joueur.GetComponent<comportementJoueur>().enAttaque;
    }

}
