using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeRestarter : MonoBehaviour
{
    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneFader fader = FindObjectOfType<SceneFader>();
        if (fader != null)
        {
            fader.ForceFadeFromBlack();
        }

        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}

