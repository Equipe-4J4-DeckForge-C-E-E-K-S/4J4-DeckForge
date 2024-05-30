using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementPersonnage : MonoBehaviour
{
    public float vitesseMouvement;

    public Rigidbody2D rigidBody;
    public Animator animator;

    private Vector2 directionDeplacement;
    Vector2 deplacement;


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

        deplacement.x = Input.GetAxisRaw("Horizontal");
        deplacement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", deplacement.x);
        animator.SetFloat("Vertical", deplacement.y);
        animator.SetFloat("Vitesse", deplacement.sqrMagnitude);

        //directionDeplacement = new Vector2(deplacementX, deplacementY).normalized;

        //animator.SetFloat("Horizontal", deplacementX);
        //animator.SetFloat("Vertical", deplacementY);
    }

    void FixedUpdate()
    {
        Deplacement();
    }

    void Deplacement() {
        //rigidBody.velocity = new Vector2(directionDeplacement.x * vitesseMouvement, directionDeplacement.y * vitesseMouvement);
        rigidBody.MovePosition(rigidBody.position + deplacement * vitesseMouvement * Time.fixedDeltaTime);
    }
}
