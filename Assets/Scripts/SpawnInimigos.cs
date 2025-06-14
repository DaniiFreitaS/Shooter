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
    private Vector3 posicaoInicial;
    public Transform limiteEsq;
    public Transform limiteDir;
    public Transform limiteInf;
    public float velocidade = 2f;
    private float aceleracao = 0f;
    private int direcao = 1;
    private bool trocaDirecao = false;

    private float clock;
    private List<InimigoController> inimigosVivos = new List<InimigoController>();
    private List<InimigoController> inimigosUltimaLinha = new List<InimigoController>();
    void Start()
    {
        posicaoInicial = transform.position;
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
        trocaDirecao = false;
    }


    void InstanciarInimigos()
    {
        transform.position = posicaoInicial;
        inimigosVivos.Clear();
        inimigosUltimaLinha.Clear();
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
        if (inimigosUltimaLinha.Contains(inimigo))
        {
            inimigosUltimaLinha.Remove(inimigo);
        }
        if(inimigosUltimaLinha.Count == 0){
            int novaUltimaLinha = 0;
            foreach (var i in inimigosVivos)
            {
                if (i.posicaoLinha > novaUltimaLinha)
                    novaUltimaLinha = i.posicaoLinha;
            }
            inimigosUltimaLinha = inimigosVivos.FindAll(i => i.posicaoLinha == novaUltimaLinha);
        }
        if (inimigosVivos.Count == 0)
        {
            aceleracao = 0f;//aceleracao volta a 0 quando para nao ficar rapido demais
            velocidade += 1f;//aumenta a velocidade quando todos os inimigos morrem
            Invoke("InstanciarInimigos", 2f);

        }
    }

    void Atirar()
    {
        if(inimigosUltimaLinha.Count > 0)
        {
            int rand = Random.Range(0, inimigosUltimaLinha.Count);
            EnemyShooter e = inimigosUltimaLinha[rand].GetComponent<EnemyShooter>();
            e.Shoot();
        }
    }

    void Movimentar()
    {
        transform.Translate(Vector3.right * direcao * (velocidade + aceleracao) * Time.deltaTime);

        // Checa se algum inimigo saiu dos limites
        foreach (var inimigo in inimigosVivos)
        {
            if (inimigo.transform.position.z <= limiteInf.position.z) 
            {
                Time.timeScale = 0f;  //para quando chega no limite inferior, trocar para tela de derrota    
            }
            if (!trocaDirecao && ( inimigo.transform.position.x <= limiteEsq.position.x || inimigo.transform.position.x >= limiteDir.position.x ))
            {
                direcao *= -1;
                aceleracao += 0.5f; //trocar aqui, nao esta no inspetor porque nao achei necessario alterar a aceleracao
                transform.position += Vector3.back * 0.5f;
                trocaDirecao = true;
                break;
            }
        }
    }
}
