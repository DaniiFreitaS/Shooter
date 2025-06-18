using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void ResetFase()
    {
        SceneManager.LoadScene(1);
    }

    public void MenuInicial() 
    {
        SceneManager.LoadScene(0);
    }
}
