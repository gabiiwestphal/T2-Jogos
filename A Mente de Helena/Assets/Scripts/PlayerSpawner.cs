using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawner : MonoBehaviour
{
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Sala2")
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            GameObject spawn = GameObject.Find("PlayerSpawnSala2");

            if (player != null && spawn != null)
            {
                player.transform.position = spawn.transform.position;
            }
        }
    }
}
