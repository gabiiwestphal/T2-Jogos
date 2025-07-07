using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bootstrapper : MonoBehaviour
{
    public GameObject gameSessionPrefab;

    void Start()
    {
        if (FindObjectOfType<GameSession>() == null)
        {
            Instantiate(gameSessionPrefab);
        }

        string cena = PlayerPrefs.GetString("Checkpoint", "SampleScene");
        SceneManager.LoadScene(cena);
    }
}
