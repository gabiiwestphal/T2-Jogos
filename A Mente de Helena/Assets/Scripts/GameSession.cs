using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    private static GameSession instance;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject); // Evita duplicar em cenas futuras
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}

