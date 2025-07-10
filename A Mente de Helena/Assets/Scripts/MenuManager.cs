using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public TMP_InputField apelidoInput;
    public GameObject rankingPanel;
    public GameObject sobrePanel;

    public GameObject menuUI;

    public TMP_Text mensagemText;

    public TMP_Text rankingText;

    void Start()
    {
        apelidoInput.text = "";
        mensagemText.text = "";
    }

    public void NovoJogo()
    {
        string apelido = apelidoInput.text;
        if (string.IsNullOrEmpty(apelido))
        {
            mensagemText.text = "Insira um apelido para jogar!";
            return;
        }

        mensagemText.text = ""; // Limpa mensagem
        PlayerPrefs.SetString("Apelido", apelido);
        PlayerPrefs.DeleteKey("Checkpoint");
        PlayerPrefs.SetInt("LoadFromCheckpoint", 0);
        SceneManager.LoadScene("LoaderScene");
    }

    public void CarregarJogo()
    {
        string apelido = apelidoInput.text;
        if (string.IsNullOrEmpty(apelido))
        {
            mensagemText.text = "Insira um apelido para carregar!";
            return;
        }

        if (PlayerPrefs.HasKey("Checkpoint"))
        {
            mensagemText.text = "";
            PlayerPrefs.SetString("Apelido", apelido);
            PlayerPrefs.SetInt("LoadFromCheckpoint", 1);
            SceneManager.LoadScene("LoaderScene");
        }
        else
        {
            mensagemText.text = "Nenhum checkpoint salvo.";
        }
    }

    public void AbrirSobre()
    {
        sobrePanel.SetActive(true);
        menuUI.SetActive(false);
    }

    public void FecharPainel(GameObject painel)
    {
        painel.SetActive(false);
        menuUI.SetActive(true);
    }

    public void AbrirRanking()
    {
        rankingPanel.SetActive(true);
        menuUI.SetActive(false);
        MostrarRanking();
        rankingPanel.SetActive(true);
    }

   public void MostrarRanking()
    {
        // Salva a última pontuação antes de mostrar, se tiver dados
        string apelido = PlayerPrefs.GetString("Apelido", "");
        int pontuacao = PlayerPrefs.GetInt("Pontuacao", -1);

        if (!string.IsNullOrEmpty(apelido) && pontuacao >= 0)
        {
            RankingUtils.SalvarRanking(apelido, pontuacao);

            // Zera para evitar duplicata em próxima abertura do ranking
            PlayerPrefs.DeleteKey("Pontuacao");
        }

        // Abaixo segue a lógica atual de exibição
        string path = Application.persistentDataPath + "/ranking.json";
        if (System.IO.File.Exists(path))
        {
            string json = System.IO.File.ReadAllText(path);
            RankingList ranking = JsonUtility.FromJson<RankingList>(json);
            if (ranking != null && ranking.entries.Count > 0)
            {
                string texto = "<b>Nome - Pontuação</b>\n";
                int pos = 1;
                foreach (var entry in ranking.entries)
                {
                    texto += $"{entry.apelido,-2} - {entry.pontuacao} pontos\n";
                    pos++;
                }
                rankingText.text = texto;
            }
            else
            {
                rankingText.text = "Nenhum ranking salvo ainda.";
            }
        }
        else
        {
            rankingText.text = "Nenhum ranking salvo ainda.";
        }
    }


    
}
