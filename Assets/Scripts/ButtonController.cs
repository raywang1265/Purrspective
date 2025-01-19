using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public Animator animator;
    public GameObject barrier;
    private bool isPressed = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isPressed)
        {
            isPressed = true; // Set the state to pressed
            animator.SetTrigger("Pressed");
            barrier.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (isPressed)
        {
            isPressed = false; // Reset the state
            animator.ResetTrigger("Pressed");
            barrier.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
