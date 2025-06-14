using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public int vida = 1;
    private HUDPontuacao hud;

    void Start()
    {
        hud = FindObjectOfType<HUDPontuacao>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerProjetil"))
        {
            vida--;

            if (vida <= 0)
            {
                if (hud != null)
                    hud.AdicionarPontos(10);

                Destroy(gameObject);
            }

            Destroy(other.gameObject);
        }
    }
}
