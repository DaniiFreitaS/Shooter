using UnityEngine;
//using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int Health = 3;
    //public TextMeshProUGUI livesText;
    private int currentHealth;

    void Start()
    {
        currentHealth = Health;
        //UpdateLivesText();
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
