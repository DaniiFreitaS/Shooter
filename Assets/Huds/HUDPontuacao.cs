using TMPro;
using UnityEngine;

public class HUDPontuacao : MonoBehaviour
{
    public TextMeshProUGUI pontuacaoText;
    public TextMeshProUGUI highScoreText;

    private int pontuacao = 0;
    private int highScore = 0;

    void Start()
    {
        // Carrega a maior pontuação salva
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        AtualizarHUD();
    }

    public void AdicionarPontos(int valor)
    {
        pontuacao += valor;

        // Verifica se bateu recorde
        if (pontuacao > highScore)
        {
            highScore = pontuacao;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }

        AtualizarHUD();
    }

    public void ResetarPontuacao()
    {
        pontuacao = 0;
        AtualizarHUD();
    }

    void AtualizarHUD()
    {
        pontuacaoText.text = "Pontuação: " + pontuacao;
        highScoreText.text = "Recorde: " + highScore;
    }
}