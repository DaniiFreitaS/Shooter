using System.Collections.Generic;
using UnityEngine;

public class SpawnInimigos : MonoBehaviour
{
    public GameObject inimigoPrefab;
    public int linhas;
    public int colunas;
    public float espacamento;
    public float delaytiro;
    private float clock;
    private List<InimigoController> inimigosVivos = new List<InimigoController>();
    private List<InimigoController> inimigosUltimaLinha = new List<InimigoController>();
    void Start()
    {
        InstanciarInimigos();
    }

    private void Update()
    {
        clock -= Time.deltaTime;
        if (clock < 0)
        {
            clock = delaytiro;
            Atirar();
        }
    }


    void InstanciarInimigos()
    {
        for (int i = 0; i < linhas; i++)
        {
            for (int j = 0; j < colunas; j++)
            {
                Vector3 posicao = new Vector3(j * espacamento, 0, -i * espacamento);
                GameObject inimigo = Instantiate(inimigoPrefab,transform.position + posicao, Quaternion.identity);
                InimigoController inimigoController = inimigo.GetComponent<InimigoController>();
                inimigoController.posicaoLinha = i+1;
                inimigosVivos.Add(inimigoController);
                if(i + 1 == linhas) inimigosUltimaLinha.Add(inimigoController);
                inimigoController.Falecimento += InimigoDestruido;
            }
        }
    }

    void InimigoDestruido(InimigoController inimigo)
    {
        if (inimigosVivos.Contains(inimigo))
        {
            inimigosVivos.Remove(inimigo);
        }
        if (inimigosVivos.Count == 0)
        {
            Invoke("InstanciarInimigos", 2f);
            
        }
    }

    void Atirar()
    {
        int rand = Random.Range(0, inimigosUltimaLinha.Count);
        EnemyShooter e = inimigosUltimaLinha[rand].GetComponent<EnemyShooter>();
        e.Shoot();
    }
}
