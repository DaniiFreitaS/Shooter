using UnityEngine;
//using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int Health = 3;
    //public TextMeshProUGUI livesText;
    private int currentHealth;

    private AudioMannager AudioMannager;

    void Start()
    {
        currentHealth = Health;
        //UpdateLivesText();
        AudioMannager = FindObjectOfType<AudioMannager>();
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

        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            //UpdateLivesText();
        }
    }

    /*
    void UpdateLivesText()
    {
        livesText.text = "Vidas: " + currentHealth;
    }
    */
}
