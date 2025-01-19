using UnityEngine;

public class DoorController : MonoBehaviour

{
    public Animator animator;
    public Collider2D collider2D;
    public bool fence;
    public int id;
    private bool hasOpened = false; // Flag to track if the animation has already playe
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenDoor()
    {
        // Check if the door has already been opened
        if (!hasOpened)
        {
            hasOpened = true; // Set the flag to true
            animator.SetTrigger("Open"); // Trigger the animation
            collider2D.enabled = false;
        }
    }

    public void OpenFence()
    {
        Destroy(gameObject);
    }
}
