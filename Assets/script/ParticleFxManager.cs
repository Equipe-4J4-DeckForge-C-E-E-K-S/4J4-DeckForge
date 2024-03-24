using UnityEngine;

public class ParticleFxManager : MonoBehaviour
{
    private ParticleSystem[] particleSystems;

    void Start()
    {
        // Get all child particle systems
        particleSystems = GetComponentsInChildren<ParticleSystem>();
    }

    void Update()
    {
        if (IsGamePaused())
        {
            PauseParticleEffects();
        }
        else
        {
            ResumeParticleEffects();
        }
    }

    void PauseParticleEffects()
    {
        foreach (var ps in particleSystems)
        {
            // Pause each particle system
            ps.Pause();
        }
    }

    void ResumeParticleEffects()
    {
        foreach (var ps in particleSystems)
        {
            // Resume each particle system
            ps.Play();
        }
    }

    bool IsGamePaused()
    {
        // Check if game is paused (you should replace this with your own pause logic)
        return Time.timeScale == 0;
    }
}
