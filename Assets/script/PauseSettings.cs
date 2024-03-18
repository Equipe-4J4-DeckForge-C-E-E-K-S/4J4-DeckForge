using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseSettings : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    private AudioSource musicAudioSource;
    private float previousMusicTimeScale;

    void Start()
    {
        musicAudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = previousMusicTimeScale;
        musicAudioSource.UnPause();
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        previousMusicTimeScale = Time.timeScale;
        Time.timeScale = 0f; // Pause the game
        musicAudioSource.Pause();
        GameIsPaused = true;
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("uimenueric"); // Load your main menu scene
    }

    public void QuitGame()
    {
        // Quit the game
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
