using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager2 : MonoBehaviour
{
    void Update()
    {
        //Begins the game upon pressing SPACE while in the menu scene.
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }
}
