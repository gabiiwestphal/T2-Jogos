using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PuzzleLanternManager : MonoBehaviour
{
    private List<string> ordemCorreta = new List<string> { "Amarela", "Branca", "Vermelha" };
    private List<string> lanternasAcesasEmOrdem = new List<string>();
    private PortaPuzzle porta;

    public void NotificarMudanca(string cor, bool acesa)
    {
        // Remove se já existe (para reposicionar corretamente)
        lanternasAcesasEmOrdem.Remove(cor);

        if (acesa)
        {
            lanternasAcesasEmOrdem.Add(cor); // Sempre adiciona no final
            Debug.Log("🔆 Acesa: " + cor);
        }
        else
        {
            Debug.Log("💤 Apagada: " + cor);
        }

        Debug.Log("🔍 Ordem atual: " + string.Join(" -> ", lanternasAcesasEmOrdem));
        VerificarSequencia();
    }


    private void VerificarSequencia()
    {
        if (lanternasAcesasEmOrdem.Count != ordemCorreta.Count)
            return;

        for (int i = 0; i < ordemCorreta.Count; i++)
        {
            if (!lanternasAcesasEmOrdem[i].Equals(ordemCorreta[i], System.StringComparison.OrdinalIgnoreCase))
            {
                Debug.Log("❌ Ordem incorreta!");
                GameManager.instancia?.AdicionarPontos(-15); // 👈 Penaliza
                return;
            }
        }

        Debug.Log("✅ Ordem correta! Puzzle resolvido!");
        GameManager.instancia?.AdicionarPontos(100); // 👈 Premia
        porta?.AtivarPorta();
    }

    void Start()
    {
        porta = FindObjectOfType<PortaPuzzle>();
    }

}



