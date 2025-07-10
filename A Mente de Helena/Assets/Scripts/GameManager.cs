using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instancia;

    public int pontuacaoAtual = 0;

    private void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AdicionarPontos(int valor)
    {
        pontuacaoAtual += valor;
        PlayerPrefs.SetInt("Pontuacao", pontuacaoAtual); // ← Salva no PlayerPrefs
        Debug.Log("Pontuação atual: " + pontuacaoAtual);
    }


    public int ObterPontuacao()
    {
        return pontuacaoAtual;
    }
}
