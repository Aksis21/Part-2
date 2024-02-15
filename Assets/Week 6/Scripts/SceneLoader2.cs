using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader2 : MonoBehaviour
{
    void Update()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;

        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(nextSceneIndex);
        }

        if (Input.GetMouseButtonDown(1))
        {
            SceneManager.LoadScene(nextSceneIndex + 1);
        }
    }
}
