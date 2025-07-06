using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TilemapDoor : MonoBehaviour
{
    public string sceneToLoad; 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Entrou na porta!");

            // Para e destrói a música antes de trocar de cena
            GameObject musica = GameObject.Find("AmbientMusic");
            if (musica != null)
            {
                Destroy(musica);
            }

            // Troca de cena
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
