using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;

    public float moveSpeed;

    private Vector2 input;

    private Animator animator;

    public LayerMask solidObjectsLayer;

    public bool hasKey = false;

    public bool dead = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }

    void Update()
    {
        // Get player input
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        if (input != Vector2.zero)
        {
            animator.SetFloat("moveX", input.x);
            animator.SetFloat("moveY", input.y);

            // Check if the target position is walkable
            Vector2 targetPos = rb.position + input.normalized * moveSpeed * Time.fixedDeltaTime;
            if (!IsWalkable(targetPos))
            {
                input = Vector2.zero; // Stop movement if the target position is blocked
            }
        }

        animator.SetBool("isMoving", input != Vector2.zero);
    }

    private void FixedUpdate()
    {
        // Apply velocity for movement
        rb.linearVelocity = input.normalized * moveSpeed;
    }

    private bool IsWalkable(Vector2 targetPos)
    {
        // Check for solid objects at the target position
        return Physics2D.OverlapCircle(targetPos, 0.2f, solidObjectsLayer) == null;
    }
}
