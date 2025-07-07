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

    public void NovoJogo()
    {
        string apelido = apelidoInput.text;
        if (string.IsNullOrEmpty(apelido))
        {
            Debug.Log("Insira um apelido.");
            return;
        }

        PlayerPrefs.SetString("Apelido", apelido);
        PlayerPrefs.DeleteKey("Checkpoint");
        SceneManager.LoadScene("SampleScene");
    }

    public void CarregarJogo()
    {
        if (PlayerPrefs.HasKey("Checkpoint"))
        {
            string cenaCheckpoint = PlayerPrefs.GetString("Checkpoint");
            SceneManager.LoadScene(cenaCheckpoint);
        }
        else
        {
            Debug.Log("Nenhum checkpoint salvo.");
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

    public void AbrirRanking() => rankingPanel.SetActive(true);
}
