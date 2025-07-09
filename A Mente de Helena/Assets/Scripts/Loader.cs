using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    public GameObject gameSessionPrefab;

    void Start()
    {
        if (FindObjectOfType<GameSession>() == null && gameSessionPrefab != null)
        {
            Instantiate(gameSessionPrefab);
        }

        bool loadCheckpoint = PlayerPrefs.GetInt("LoadFromCheckpoint", 0) == 1;

        string cenaAlvo = loadCheckpoint
        ? PlayerPrefs.GetString("Checkpoint", "SampleScene")
        : "SampleScene";

        PlayerPrefs.DeleteKey("LoadFromCheckpoint"); 

        //string cena = PlayerPrefs.GetString("Checkpoint", "SampleScene");
        SceneManager.LoadScene(cenaAlvo);
    }
}

