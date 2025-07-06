using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetarJogador : MonoBehaviour
{
    private Vector3 playerStartPos;
    private LuzSeguidora[] luzes;
    private AmbientMusicController musica;
    private PlayerController playerCtrl;
    private Rigidbody2D playerRb;
    private bool morto = false;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            playerStartPos = player.transform.position;
            playerCtrl = player.GetComponent<PlayerController>();
            playerRb = player.GetComponent<Rigidbody2D>();
        }

        musica = FindObjectOfType<AmbientMusicController>();
        musica?.PlayMusic();

        luzes = FindObjectsOfType<LuzSeguidora>();
        foreach (var luz in luzes)
            luz.SaveStartPosition();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (morto || !other.CompareTag("Player")) return;
        morto = true;

        musica?.StopMusic();

        // Bloqueia o controle temporariamente
        playerCtrl.enabled = false;
        playerRb.velocity = Vector2.zero;

        StartCoroutine(Resetar());
    }

    private IEnumerator Resetar()
    {
        yield return new WaitForSeconds(0.3f); // pequena pausa para efeito visual

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = playerStartPos;
        playerCtrl.enabled = true;

        foreach (var luz in luzes)
            luz.Resetar();

        musica?.PlayMusic();

        morto = false;
    }
}



