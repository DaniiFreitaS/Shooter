using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;

    private Transform paiInimigo;

    void Start()
    {
        paiInimigo = transform.parent;
    }

    void Update()
    {
        if (paiInimigo == null)
        {
            Destroy(gameObject);
        }
    }

    public void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
    }
}
