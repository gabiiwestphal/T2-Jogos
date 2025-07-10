using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortaPuzzle : MonoBehaviour
{
    private bool podeEntrar = false;

    [SerializeField] private string sceneToLoad = "Labirinto";

    public void AtivarPorta()
    {
        podeEntrar = true;
        Debug.Log("🚪 Porta ativada!");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (podeEntrar && other.CompareTag("Player"))
        {
            PlayerPrefs.SetString("Checkpoint", sceneToLoad);
            Debug.Log("➡️ Entrando na próxima cena!");
            SceneManager.LoadScene(sceneToLoad); // ID da sua cena
        }
    }
}

