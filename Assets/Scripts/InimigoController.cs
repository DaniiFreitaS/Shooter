using UnityEngine;
using System;

public class InimigoController : MonoBehaviour
{
    public Transform areaDisparo;
    public event Action<InimigoController> Falecimento;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Morrer()
    {
        Falecimento?.Invoke(this);
        Destroy(gameObject);
    }
}
