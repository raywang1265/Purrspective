using UnityEngine;

public class SquareControl : MonoBehaviour
{
    public float movSpeed;
    Vector2 velocity;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        velocity.Normalize();
        rb.linearVelocity = velocity * movSpeed;
    }
}
