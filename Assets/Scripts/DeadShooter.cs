using UnityEngine;

public class DeadShooter : MonoBehaviour
{
    public GameObject inimigo; 

    void Update()
    {
        if (inimigo == null)
        {
            Destroy(gameObject);
        }
    }
}
