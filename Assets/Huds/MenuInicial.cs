using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuInicial : MonoBehaviour
{
    public GameObject painelHighscore;            // Painel que aparece com a pontuação
    public TextMeshProUGUI textoHighscore;        // Texto que exibirá a pontuação

    private void Start()
    {
        painelHighscore.SetActive(false);
    }

    public void Jogar()
    {
        SceneManager.LoadScene("SpaceInvPlay");
    }

    public void Highscore()
    {
        int highscore = PlayerPrefs.GetInt("HighScore", 0);
        textoHighscore.text = "Recorde Atual: " + highscore;
        painelHighscore.SetActive(true);
    }

    public void FecharPainelHighscore()
    {
        painelHighscore.SetActive(false);
    }

    public void Sair()
    {
        Application.Quit();
        Debug.Log("Saiu do jogo.");
    }
}
