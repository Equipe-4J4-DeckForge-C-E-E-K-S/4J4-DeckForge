using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorText : MonoBehaviour
{
    public Text textElement; // Assign the UI Text element in the Inspector

    void Update()
    {
        // Update the text position to follow the cursor
        transform.position = Input.mousePosition;

        // Check if the mouse is hovering over a door
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        {
            DoorInfo doorInfo = hit.collider.GetComponent<DoorInfo>(); // Get the DoorInfo component
            if (doorInfo != null)
            {
                // Update the text to display the door's information
                textElement.text = doorInfo.hoverText; // Use the text associated with the door
                textElement.enabled = true;
                return;
            }
        }

        // If not hovering over a door, hide the text
        textElement.enabled = false;
    }
}