using UnityEngine;
using System;

public class InimigoController : MonoBehaviour
{
    public int posicaoLinha;
    public event Action<InimigoController> Falecimento;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Teste para ver se os inimigos aparecem infinitamente
        //Invoke("Morrer", 2f);
    }

    public void Morrer()
    {
        Falecimento?.Invoke(this);
        Destroy(gameObject);
    }
}
