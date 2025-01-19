using Unity.VisualScripting;
using UnityEngine;

public class KeyAlertController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Collider2D collider2D;
    public GameObject door;
    private int id = 1;
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject player = other.gameObject;
        if (player.GetComponent<PlayerController>().hasKey == true)
        {
            if (door.GetComponent<DoorController>().fence == false)
            {
                door.GetComponent<DoorController>().OpenDoor();
            }
            else
            {
                door.GetComponent<DoorController>().OpenFence();
            }
            player.GetComponent<PlayerController>().hasKey = false;
            Destroy(gameObject);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
