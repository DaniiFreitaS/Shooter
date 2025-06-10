using UnityEngine;

public class TestePontuacao : MonoBehaviour
{
    public HUDPontuacao hud;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            hud.AdicionarPontos(10);
        }
    }
}