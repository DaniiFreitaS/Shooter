using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenu;
    private bool pausado = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausado)
                Continuar();
            else
                Pausar();
        }
    }

    public void Pausar()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        pausado = true;
    }

    public void Continuar()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        pausado = false;
    }

    public void SairParaMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuInicial"); // Troque pelo nome da sua cena do menu
    }
}
