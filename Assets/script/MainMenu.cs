using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public float delayBeforeLoading = 2f; // Adjust the delay time as needed

    public void PlayGame()
    {
        // Start the delay coroutine
        StartCoroutine(DelayedLoadScene());
    }

    IEnumerator DelayedLoadScene()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delayBeforeLoading);

        // Load the next scene in the build index
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        // Quit the game
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
