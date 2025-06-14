using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public int vida = 1;
    public HUDPontuacao hud;
    public InimigoController inimigo;

    void Start()
    {
        inimigo = gameObject.GetComponent<InimigoController>();
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
        inimigo.Morrer();
        //Destroy(gameObject);
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
