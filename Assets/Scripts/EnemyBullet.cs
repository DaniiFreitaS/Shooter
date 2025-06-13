using UnityEngine;

public class Enemybullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 20f;
    private void Start()
    {
        DestroyObject(gameObject, lifetime);
    }

    void Update()
    {
        transform.position += Vector3.back * speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
