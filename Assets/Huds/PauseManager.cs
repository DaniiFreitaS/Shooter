using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public AudioMannager audioMannager;
    public GameObject settingsPanel;
    public GameObject pauseMenu;
    private bool pausado = false;
    public Slider sliderMaster;
    public Slider sliderMusic;
    public Slider sliderSFX;
    public AudioMixer mainMixer;

    private void Start()
    {
        pauseMenu.SetActive(false);
        audioMannager.PlayMusic(audioMannager.Music);

        // Recarrega os valores REAIS do AudioMixer e aplica aos sliders
        sliderMaster.value = GetLinearVolume("MasterVolume");
        sliderMusic.value = GetLinearVolume("MusicVolume");
        sliderSFX.value = GetLinearVolume("SFXVolume");


    }

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
    float GetLinearVolume(string parametro)
    {
        float dB;
        if (mainMixer.GetFloat(parametro, out dB))
        {
            return Mathf.Pow(10f, dB / 20f); // converte de dB para valor linear (0~1)
        }
        return 1f; // padrão
    }

    public void Pausar()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        pausado = true;
    }
    public void Settings()
    {
        settingsPanel.SetActive(true);
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
