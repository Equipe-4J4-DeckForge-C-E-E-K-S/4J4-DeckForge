using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScript : MonoBehaviour
{

     public ParticleSystem particleEffect;
     private bool isPaused = false;
    // Start is called before the first frame update
void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // You can replace this with your pause/unpause input
        {
            TogglePause();
        }
    }

    void TogglePause()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            // Pause the particle effect
            particleEffect.Pause();
        }
        else
        {
            // Resume the particle effect
            particleEffect.Play();
        }
    }
}
