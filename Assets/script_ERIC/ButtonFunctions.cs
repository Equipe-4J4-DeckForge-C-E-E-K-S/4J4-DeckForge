using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFunctions : MonoBehaviour
{

    public AudioSource mySounds;
    public AudioClip hoverSound;
    public AudioClip clickSound;

    public void HoverSound()
    {
         if (mySounds.enabled)
            mySounds.PlayOneShot(hoverSound);
    }

    public void ClickSound()
    {
        if (mySounds.enabled)
            mySounds.clip = clickSound;
            mySounds.Play();
    }

}
