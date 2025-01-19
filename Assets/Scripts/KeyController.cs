using Unity.VisualScripting;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Rigidbody2D rb;
    public Collider2D collider2D;
    void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        GameObject player = collision.gameObject;
        player.GetComponent<PlayerControllerServer>().hasKey = true;
        // Set gravity scale to 1
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 3);
        rb.gravityScale = 1;

        // Disable all collisions
        collider2D.enabled = false;
    }

    void OnCollisionExit2D(UnityEngine.Collision2D collision)
    {
        Debug.Log("collision exit");
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -100) {
            Destroy(gameObject);
        }
    }
}
