using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
{
    StartCoroutine(LoadSceneAfterDelay(5));
}

IEnumerator LoadSceneAfterDelay(int delay)
{
    yield return new WaitForSeconds(delay);
    SceneManager.LoadScene("uimenueric");
}
}
