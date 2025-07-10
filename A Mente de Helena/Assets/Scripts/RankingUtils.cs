// Adicione os usings necessários
using System.IO;
using UnityEngine;

public static class RankingUtils
{
    public static void SalvarRanking(string apelido, int pontuacao)
    {
        string path = Application.persistentDataPath + "/ranking.json";
        RankingList ranking;

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            ranking = JsonUtility.FromJson<RankingList>(json);
            if (ranking == null) ranking = new RankingList();
        }
        else
        {
            ranking = new RankingList();
        }

        ranking.entries.Add(new RankingEntry { apelido = apelido, pontuacao = pontuacao });
        ranking.entries.Sort((a, b) => b.pontuacao.CompareTo(a.pontuacao));
        string novoJson = JsonUtility.ToJson(ranking, true);
        File.WriteAllText(path, novoJson);
    }
}