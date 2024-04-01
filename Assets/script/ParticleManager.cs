using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    // Prefab references
    public GameObject particleEffectPrefab1;
    public GameObject particleEffectPrefab2;
    public GameObject particleEffectPrefab3;
    public GameObject particleEffectPrefab4;

    // Particle effect instances
    private ParticleSystem particleEffectInstance1;
    private ParticleSystem particleEffectInstance2;
    private ParticleSystem particleEffectInstance3;
    private ParticleSystem particleEffectInstance4;

    // Flag to track if the game is paused
    private bool isPaused = false;

    // Function to toggle pause state
    public void TogglePause()
    {
        isPaused = !isPaused;
        UpdateParticleEffects();
    }

    // Function to update particle effects based on pause state
    private void UpdateParticleEffects()
    {
        if (isPaused)
        {
            // Start particle systems when paused
            StartParticleEffects();
        }
        else
        {
            // Stop particle systems when unpaused
            StopParticleEffects();
        }
    }

    // Function to instantiate and start particle effects
    private void StartParticleEffects()
    {
        particleEffectInstance1 = Instantiate(particleEffectPrefab1, transform).GetComponent<ParticleSystem>();
        particleEffectInstance2 = Instantiate(particleEffectPrefab2, transform).GetComponent<ParticleSystem>();
        particleEffectInstance3 = Instantiate(particleEffectPrefab3, transform).GetComponent<ParticleSystem>();
        particleEffectInstance4 = Instantiate(particleEffectPrefab4, transform).GetComponent<ParticleSystem>();

        // Start particle emission
        particleEffectInstance1.Play();
        particleEffectInstance2.Play();
        particleEffectInstance3.Play();
        particleEffectInstance4.Play();
    }

    // Function to stop and destroy particle effects
    private void StopParticleEffects()
    {
        // Stop particle emission
        particleEffectInstance1.Stop();
        particleEffectInstance2.Stop();
        particleEffectInstance3.Stop();
        particleEffectInstance4.Stop();

        // Destroy particle systems
        Destroy(particleEffectInstance1.gameObject);
        Destroy(particleEffectInstance2.gameObject);
        Destroy(particleEffectInstance3.gameObject);
        Destroy(particleEffectInstance4.gameObject);
    }
}
