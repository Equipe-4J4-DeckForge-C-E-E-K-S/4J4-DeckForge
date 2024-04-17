using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinuationMusic : MonoBehaviour
{

    private static ContinuationMusic instance;
   // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Checker si c'est game over scene, et arreter l'audio 
        if (scene.name == "GameOverScene")
        {
            StopAudio();
        }
        else
        {
           
            PlayAudio();
        }
    }

    void PlayAudio()
    {
       
    }

    void StopAudio()
    {
        
    }
}
