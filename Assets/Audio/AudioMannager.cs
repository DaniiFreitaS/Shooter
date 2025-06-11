using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioMannager : MonoBehaviour
{
    public static AudioMannager instance;

    [Header("Mixer Principal")]
    public AudioMixer mainMixer;

    [Header("Fontes de Áudio")]
    public AudioSource musicSource;
    public AudioSource sfxSource;
    public AudioSource masterSource;

    [Header("Músicas")]
    public AudioClip menuMusic;
    public AudioClip gameplayMusic;

    [Header("Efeitos Sonoros")]
    public AudioClip playerShoot;
    public AudioClip enemyShoot;
    public AudioClip playerHit;
    public AudioClip enemyHit;
    public Slider sliderMusic;
    public Slider sliderSFX;
    public Slider sliderMaster;

    private void Start()
    {
        sliderMaster.value = GetLinearVolume("MasterVolume");
        sliderMusic.value = GetLinearVolume("MusicVolume");
        sliderSFX.value = GetLinearVolume("SFXVolume");
        if (AudioMannager.instance != null)
        {
            AudioMannager.instance.PlayMusic(AudioMannager.instance.menuMusic);
        }
    }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // <- Isso aqui faz a persistência
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Tenta achar sliders na nova cena
        Slider masterSlider = GameObject.Find("MasterVolume")?.GetComponent<Slider>();
        Slider musicSlider = GameObject.Find("MusicVolume")?.GetComponent<Slider>();
        Slider sfxSlider = GameObject.Find("SFXVolume")?.GetComponent<Slider>();

        if (masterSlider != null)
        {
            float val = GetLinearVolume("MasterVolume");
            masterSlider.value = val;
            SetVolumeGeral(val);
        }

        if (musicSlider != null)
        {
            float val = GetLinearVolume("MusicVolume");
            musicSlider.value = val;
            SetVolumeMusica(val);
        }

        if (sfxSlider != null)
        {
            float val = GetLinearVolume("SFXVolume");
            sfxSlider.value = val;
            SetVolumeSFX(val);
        }
    }

    float GetLinearVolume(string parametro)
    {
        float dB;
        if (mainMixer.GetFloat(parametro, out dB))
        {
            return Mathf.InverseLerp(-80f, 0f, dB); // de -80 dB a 0 dB → 0 a 1
        }
        return 0.7f; // valor padrão se não encontrar
    }

    public void SetVolume(string parametro, float valor)
    {
        // Evita log de 0 e suaviza curva
        valor = Mathf.Clamp(valor, 0.0001f, 1f);

        float dB = Mathf.Log10(valor) * 20f;
        mainMixer.SetFloat(parametro, dB);
    }

    public void SetVolumeGeral(float value)
    {
        SetVolume("MasterVolume", sliderMaster.value);
    }

    public void SetVolumeMusica(float value)
    {
        SetVolume("MusicVolume", sliderMusic.value);
    }

    public void SetVolumeSFX(float value)
    {
        SetVolume("SFXVolume", sliderSFX.value);
    }

    // Tocar música (loop automático)
    public void PlayMusic(AudioClip music)
    {
        if (music != null && musicSource != null)
        {
            if (musicSource.clip == music && musicSource.isPlaying)
                return; // já está tocando

            musicSource.clip = music;
            musicSource.loop = true;
            musicSource.Play();
        }
    }

    // Tocar efeito sonoro único
    public void PlaySFX(AudioClip sfx)
    {
        if (sfx != null && sfxSource != null)
        {
            sfxSource.PlayOneShot(sfx);
        }
    }
}