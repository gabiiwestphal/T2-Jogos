using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawner : MonoBehaviour
{
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        
        if (player == null) return;

        string lastScene = PlayerPrefs.GetString("Checkpoint", "");

        // Só move o player se a cena atual for a mesma do checkpoint
        if (SceneManager.GetActiveScene().name == lastScene)
        {
            GameObject spawn = GameObject.Find("PlayerSpawnSala2");
            if (spawn != null)
            {
                player.transform.position = spawn.transform.position;
            }
        }
    }
}