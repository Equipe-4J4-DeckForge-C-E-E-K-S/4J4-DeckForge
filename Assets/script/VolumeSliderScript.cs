using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeSliderScript : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetVolume(float volume)
    {
        // Ensure volume stays within a reasonable range (optional)
        volume = Mathf.Clamp(volume, 0.0001f, 1.0f);

        // Set the volume in the AudioMixer
        audioMixer.SetFloat("Volume", Mathf.Log10(volume) * 20);

        // Log the current volume level to the console
        float currentVolume;
        audioMixer.GetFloat("Volume", out currentVolume);
        Debug.Log("Current Volume: " + currentVolume);
    }
}
