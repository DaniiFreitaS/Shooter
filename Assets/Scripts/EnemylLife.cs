using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public int vida = 1;
    private HUDPontuacao hud;
    private InimigoController inimigoController;


    void Start()
    {
        hud = FindAnyObjectByType<HUDPontuacao>();

        inimigoController = GetComponent<InimigoController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerProjetil"))


        {
            vida--;



            if (vida <= 0)
            {
                if (hud != null) 
                {
                    hud.AdicionarPontos(10);   
                }
                if (inimigoController != null)
                {
                    inimigoController.Morrer();
                }
            }




            Destroy(other.gameObject);
        }
    }
}