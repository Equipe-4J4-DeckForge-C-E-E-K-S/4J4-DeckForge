using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionSceneGameOver : MonoBehaviour
{
  
    // Update is called once per frame
     void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
    {
        SceneManager.LoadScene("uimenueric");
    }
    }
}