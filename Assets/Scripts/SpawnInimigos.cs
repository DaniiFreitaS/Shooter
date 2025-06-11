using System.Collections.Generic;
using UnityEngine;

public class SpawnInimigos : MonoBehaviour
{
    public GameObject inimigoPrefab;

    public int linhas;
    public int colunas;
    public float espacamento;

    public List<InimigoController> inimigosVivos = new List<InimigoController>();
    void Start()
    {
        InstanciarInimigos();
    }

    private void Update()
    {
        
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
                inimigosVivos.Add(inimigoController);
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
}
