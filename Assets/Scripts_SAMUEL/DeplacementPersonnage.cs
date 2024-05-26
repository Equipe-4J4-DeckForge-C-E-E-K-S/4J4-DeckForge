using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementPersonnage : MonoBehaviour
{
    public float vitesseMouvement;

    public Rigidbody2D rigidBody;

    private Vector2 directionDeplacement;


    // Start is called before the first frame update
    void Start()
    {
        // Rigidbody du personnage
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        /*vitesseX = Input.GetAxisRaw("Horizontal") + vitesseMouvement;
        vitesseY = Input.GetAxisRaw("Vertical") + vitesseMouvement;
        rigidBody.velocity = new Vector2(vitesseX, vitesseY);*/

        float deplacementX = Input.GetAxisRaw("Horizontal");
        float deplacementY = Input.GetAxisRaw("Vertical");

        directionDeplacement = new Vector2(deplacementX, deplacementY).normalized;
    }

    void FixedUpdate()
    {
        Deplacement();
    }

    void Deplacement() {
        rigidBody.velocity = new Vector2(directionDeplacement.x * vitesseMouvement, directionDeplacement.y * vitesseMouvement);
    }
}
