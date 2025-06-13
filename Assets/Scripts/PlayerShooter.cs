using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public GameObject prefab;          
    public float shootCooldown = 1f; 
    private float cooldownTimer = 0f;

    void Update()
    {
        cooldownTimer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && cooldownTimer <= 0f)
        {
            Shoot();
            cooldownTimer = shootCooldown; 
        }
    }

    void Shoot()
    {
        Instantiate(prefab, transform.position, transform.rotation);
    }
}
