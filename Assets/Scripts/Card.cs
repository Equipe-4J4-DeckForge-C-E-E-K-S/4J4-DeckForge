using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Card : MonoBehaviour
{
    public int number;
    public Color color;
     public  Canvas canvas;

     void Start() {
         if (canvas == null)
        {
            canvas = FindObjectOfType<Canvas>();
        }
     }

    // Méthode pour déplacer la carte vers le centre du Canvas
    public void MoveToCenter()
    {
        StartCoroutine(MoveToCenterRoutine());
    }

    IEnumerator MoveToCenterRoutine()
    {
        // Calculer le centre du Canvas World Space
        RectTransform canvasRect = canvas.GetComponent<RectTransform>();
        Vector3 centerPosition = canvas.transform.position + new Vector3(canvasRect.sizeDelta.x * canvasRect.pivot.x, canvasRect.sizeDelta.y * canvasRect.pivot.y, 0) * canvas.transform.localScale.x;

        float time = 0;
        while (time < 1)
        {
            transform.position = Vector3.Lerp(transform.position, centerPosition, time);
            time += Time.deltaTime * 0.5f; // Ajustez la vitesse de l'animation ici
            yield return null;
        }
    }

    // Détecter les clics sur la carte
    void OnMouseDown()
    {
        MoveToCenter();
    }
}


