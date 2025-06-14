using System.Collections.Generic;
using UnityEngine;

public class SpawnInimigos : MonoBehaviour
{
    //grid inimigos
    public GameObject inimigoPrefab;
    public int linhas;
    public int colunas;
    public float espacamento;
    public float delaytiro;

    //movimentacao grid
    public Transform limiteEsq;
    public Transform limiteDir;
    public Transform limiteInf;
    public float velocidade = 2f;
    private int direcao = 1;

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
        Movimentar();
    }


    void InstanciarInimigos()
    {
        for (int i = 0; i < linhas; i++)
        {
            for (int j = 0; j < colunas; j++)
            {
                Vector3 posicao = new Vector3(j * espacamento, 0, -i * espacamento);
                GameObject inimigo = Instantiate(inimigoPrefab,transform.position + posicao, Quaternion.identity);
                inimigo.transform.parent = this.transform;
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

    void Movimentar()
    {
        transform.Translate(Vector3.right * direcao * velocidade * Time.deltaTime);

        // Checa se algum inimigo saiu dos limites
        foreach (var inimigo in inimigosVivos)
        {
            if (inimigo.transform.position.z <= limiteInf.position.z) 
            {
                Time.timeScale = 0f;  //para quando chega no limite inferior, trocar para tela de derrota    
            }
            if (inimigo.transform.position.x <= limiteEsq.position.x || inimigo.transform.position.x >= limiteDir.position.x)
            {
                direcao *= -1;
                transform.position += Vector3.back * 0.5f;
                break;
            }
        }
    }
}
