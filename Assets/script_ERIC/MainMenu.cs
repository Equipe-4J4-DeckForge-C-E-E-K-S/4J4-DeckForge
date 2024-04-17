using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public float delayBeforeLoading = 2f; // Adjust the delay time as needed
    public float fadeDuration = 1f; // Duration of the crossfade effect

    public void PlayGame()
    {
        // Start the delay coroutine
        StartCoroutine(DelayedLoadScene());
    }

    IEnumerator DelayedLoadScene()
    {
        // Fade out
        yield return StartCoroutine(FadeOut(fadeDuration));

        // Load the next scene in the build index
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        // Fade in
        yield return StartCoroutine(FadeIn(fadeDuration));
    }

    IEnumerator FadeOut(float duration)
    {
        CanvasGroup canvasGroup = FindObjectOfType<CanvasGroup>();
        float startAlpha = canvasGroup.alpha;
        float t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime / duration;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, 0f, t);
            yield return null;
        }
    }

    IEnumerator FadeIn(float duration)
    {
        CanvasGroup canvasGroup = FindObjectOfType<CanvasGroup>();
        float startAlpha = canvasGroup.alpha;
        float t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime / duration;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, 1f, t);
            yield return null;
        }
    }

    public void QuitGame()
    {
        // Quit the game
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
