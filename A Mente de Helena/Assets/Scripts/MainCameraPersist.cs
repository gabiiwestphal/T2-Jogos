using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraPersist : MonoBehaviour
{
    private static MainCameraPersist instance;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
