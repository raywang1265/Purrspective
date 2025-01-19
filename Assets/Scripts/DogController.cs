using UnityEngine;

public class DogController : MonoBehaviour
{
    [Header("Movement Settings")]
    public Vector3 verticalStart;
    public Vector3 verticalEnd;
    public Vector3 horizontalStart;
    public Vector3 horizontalEnd;
    public float speed = 2f;

    [Header("Animation Settings")]
    public string verticalUpAnimation = "DogMoveUp";
    public string verticalDownAnimation = "DogMoveDown";
    public string horizontalAnimation = "DogMoveSide";

    public bool movingVertically = true;
    public bool movingForward = true;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<PlayerController>().dead = true;
        //do shit to restart game
    }

    void Start()
    {

        if (animator == null)
        {
            Debug.LogError("Animator component not found on the object.");
        }

        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer component not found on the object.");
        }

        if (!movingVertically) {
            PlayAnimation(horizontalAnimation);
        }
    }

    void Update()
    {
        if (movingVertically)
        {
            MoveVertical();
        }
        else
        {
            MoveHorizontal();
        }
    }

    void MoveVertical()
    {
        //PlayAnimation(verticalUpAnimation);
        // Determine target position based on direction
        Vector3 targetPosition = movingForward ? new Vector3(verticalEnd.x, verticalEnd.y, -1f) : new Vector3(verticalStart.x, verticalStart.y, -1f);

        // Move the object towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Ensure the z value is set to -1
        transform.position = new Vector3(transform.position.x, transform.position.y, -1f);

        // Check if the object reached the target position
        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            // Reverse direction
            movingForward = !movingForward;

            // Play different animations based on the direction
            if (movingForward)
            {
                PlayAnimation(verticalUpAnimation);  // Animation for moving forward
            }
            else
            {
                PlayAnimation(verticalDownAnimation); // Animation for moving backward
            }
        }
    }

    void MoveHorizontal()
    {
        PlayAnimation("DogMoveSideLeft");
        // Determine target position based on direction
        Vector3 targetPosition = movingForward ? new Vector3(horizontalEnd.x, horizontalEnd.y, -1f) : new Vector3(horizontalStart.x, horizontalStart.y, -1f);

        // Move the object towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Ensure the z value is set to -1
        transform.position = new Vector3(transform.position.x, transform.position.y, -1f);

        // Check if the object reached the target position
        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            // Reverse direction
            movingForward = !movingForward;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;

            // Play different animations based on the direction
            if (movingForward)
            {
                PlayAnimation(horizontalAnimation);  // Animation for moving forward
            }
            else
            {
                PlayAnimation("DogMoveSideLeft"); // Replace this with your backward animation
            }
        }
    }

    void PlayAnimation(string animationName)
    {
            animator.Play(animationName);
    }
}
