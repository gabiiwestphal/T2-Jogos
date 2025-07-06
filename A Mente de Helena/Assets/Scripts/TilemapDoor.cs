using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TilemapDoor : MonoBehaviour
{
    public string sceneToLoad; 
    public SceneFader fader;

    private void Start()
    {
        GameObject gameSession = GameObject.Find("GameSession");
        if (gameSession != null)
        fader = gameSession.GetComponentInChildren<SceneFader>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        if (fader != null)
        {
            fader.FadeToScene(sceneToLoad);
        }
        else
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
