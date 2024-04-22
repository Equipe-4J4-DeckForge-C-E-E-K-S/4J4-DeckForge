using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public float fadeDuration = 2f;
    public GameObject loadingScreen; // Reference to your loading screen canvas

    public void PlayGame()
    {
        StartCoroutine(TransitionToNextScene());
    }

    IEnumerator TransitionToNextScene()
    {
        // Fade out
        yield return StartCoroutine(FadeOut(fadeDuration));

        // Activate the loading screen
        loadingScreen.SetActive(true);

        // Load the next scene asynchronously
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        asyncLoad.allowSceneActivation = false;

        // Wait until the next scene is fully loaded
        while (!asyncLoad.isDone)
        {
            if (asyncLoad.progress >= 0.9f) // Check if the scene is almost loaded
            {
                asyncLoad.allowSceneActivation = true; // Activate the scene
            }
            yield return null;
        }

        // Fade in
        yield return StartCoroutine(FadeIn(fadeDuration));

        // Deactivate the loading screen
        loadingScreen.SetActive(false);
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
