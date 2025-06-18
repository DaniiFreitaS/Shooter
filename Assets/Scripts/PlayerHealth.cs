using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int Health = 3;
    private HUDPontuacao hud;
    private int currentHealth;

    private AudioMannager AudioMannager;

    void Start()
    {
        currentHealth = Health;
        hud = FindAnyObjectByType<HUDPontuacao>();
        AudioMannager = FindAnyObjectByType<AudioMannager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BulletEnemy"))
        {
            TakeDamage(1);
            Destroy(other.gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        AudioMannager.PlaySFX(AudioMannager.playerHit);
        hud.AtualizarVida(currentHealth);

        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        
    }

}
