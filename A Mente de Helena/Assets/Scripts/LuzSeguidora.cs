using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzSeguidora : MonoBehaviour
{
    public Transform alvo;
    public float velocidadeMin = 1.5f;
    public float velocidadeMax = 3.5f;
    public LayerMask obstaculosMask;

    private Rigidbody2D rb;
    private float velocidade;
    private float delayAntesDeMover;
    private System.Random rng;

    private Vector3 posicaoInicial;
    private float velocidadeOriginal;
    private float delayOriginal;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Inicializa variáveis aleatórias únicas por instância
        rng = new System.Random(GetInstanceID());
        velocidade = Random.Range(velocidadeMin, velocidadeMax);
        delayAntesDeMover = Random.Range(0f, 0.5f);
    }

    void FixedUpdate()
    {
        if (alvo == null || Time.timeSinceLevelLoad < delayAntesDeMover) return;

        Vector2 origem = rb.position;

        // Adiciona imprecisão na mira
        Vector2 alvoComDesvio = (Vector2)alvo.position + Random.insideUnitCircle * 0.5f;
        Vector2 direcao = (alvoComDesvio - origem).normalized;
        float distancia = velocidade * Time.fixedDeltaTime;

        Vector2 origemRay = origem + direcao * 0.1f;
        bool bloqueado = Physics2D.Raycast(origemRay, direcao, distancia, obstaculosMask);

        if (!bloqueado)
        {
            rb.MovePosition(origem + direcao * distancia);
        }
        else
        {
            // Tentativas de contorno (embaralhadas)
            Vector2[] tentativas = { Vector2.up, Vector2.down, Vector2.right, Vector2.left };

            for (int i = 0; i < tentativas.Length; i++)
            {
                int j = rng.Next(i, tentativas.Length);
                (tentativas[i], tentativas[j]) = (tentativas[j], tentativas[i]);
            }

            foreach (Vector2 tentativa in tentativas)
            {
                Vector2 tentativaOrigem = origem + tentativa * 0.1f;
                bool obstaculo = Physics2D.Raycast(tentativaOrigem, tentativa, distancia, obstaculosMask);

                if (!obstaculo)
                {
                    rb.MovePosition(origem + tentativa * distancia);
                    break;
                }
            }
        }
    }

    public void SaveStartPosition()
    {
    posicaoInicial = transform.position;
    velocidadeOriginal = Random.Range(velocidadeMin, velocidadeMax);
    delayOriginal = Random.Range(0f, 0.5f);
    velocidade = velocidadeOriginal;
    delayAntesDeMover = delayOriginal;
    }

    public void Resetar()
    {
    transform.position = posicaoInicial;
    velocidade = velocidadeOriginal;
    delayAntesDeMover = delayOriginal;
    }
}



