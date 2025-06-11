using UnityEngine;

public class ApplyForce : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 5f;
    private float fixedY;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        fixedY = transform.position.y;

        // Trava o movimento Y e rotação
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
    }

    void Update()
    {
        float moveInput = 0f;

        if (Input.GetKey(KeyCode.D))
            moveInput = 1f;
        else if (Input.GetKey(KeyCode.A))
            moveInput = -1f;

        Vector3 move = new Vector3(moveInput * speed * Time.deltaTime, 0f, 0f);
        rb.MovePosition(rb.position + move);
    }
}
