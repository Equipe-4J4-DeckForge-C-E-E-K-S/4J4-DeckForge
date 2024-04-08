using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comportementFleche : MonoBehaviour
{
    // Start is called before the first frame update
    public Texture2D cursorTexture;

    public Vector2 cursorHotspot;

    // Start is called before the first frame update
    void Start()
    {
        cursorHotspot = new Vector2(cursorTexture.width / 2, cursorTexture.height / 2);
        Cursor.SetCursor(cursorTexture, cursorHotspot, CursorMode.Auto);
    }

}
