using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public int vida = 1;
    private HUDPontuacao hud;

    void Start()
    {
        hud = FindObjectOfType<HUDPontuacao>();
    }

    public void TakeDamage(int dano)
    {
        vida -= dano;

        if (vida <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (hud != null)
        {
            hud.AdicionarPontos(10);
        }

        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("PlayerProjetil"))
        {
            TakeDamage(1);
            Destroy(other.gameObject);
        }
    }
}
