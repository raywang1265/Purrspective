using System.Collections;
using UnityEngine;
using Unity.Netcode; // Or Mirror namespace

public class PlayerControllerServer : NetworkBehaviour
{

    [SerializeField] private Camera playerCamera;

    public Rigidbody2D rb;

    public bool hasKey = false;

    public bool dead = false;


    public float moveSpeed;

    private Vector2 input;

    private Animator animator;

    private float randomFloat;

    public LayerMask solidObjectsLayer;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        System.Random random = new System.Random();
        randomFloat = (float)random.NextDouble(); 

        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        if (IsServer && IsClient)
        {
            transform.position = new Vector3(28.5f, -40.5f, -1);
        }
        else if (IsClient)
        {
            transform.position = new Vector3(-7.5f, 8.5f, -1);
        }
    }

    void Update()
    {

        if (!IsOwner) {
            playerCamera.gameObject.SetActive(true);
            return;
        } else {
            playerCamera.gameObject.SetActive(false);

        }
        // Get player input
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        if (input != Vector2.zero)
        {
            // randomly switch the x and y axis
            // if (randomFloat < 0.1) {    
            //     animator.SetFloat("moveX", input.y);
            //     animator.SetFloat("moveY", input.x);
            // } else {
            //     animator.SetFloat("moveX", input.x);
            //     animator.SetFloat("moveY", input.y);
            // }
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


// public class PlayerControllerServer : NetworkBehaviour
// {
//     public float moveSpeed;

//     private bool isMoving;

//     private Vector2 input;

//     private Animator animator;

//     private LayerMask solidObjectsLayer;

//     private void Awake() {
//         animator = GetComponent<Animator>();
//     }


//     // Start is called once before the first execution of Update after the MonoBehaviour is created
//     void Start()
//     {
        
//     }

//     // Update is called once per frame
//     void Update()
//     {

//         if (!IsOwner) {
//             return;
//         }

//         if (!isMoving)
//         {
//             input.x = Input.GetAxisRaw("Horizontal");
//             input.y = Input.GetAxisRaw("Vertical");
//             // Debug.Log("Input x: " + input.x);
//             // Debug.Log("Input y: " + input.y);



//             if (input != Vector2.zero)
//             {
//                 // MoveServerRpc(input);
//                 animator.SetFloat("moveX", input.x);
//                 animator.SetFloat("moveY", input.y);

//                 var targetPos = transform.position;
//                 targetPos.x += input.x;
//                 targetPos.y += input.y;

//                 if (IsWalkable(targetPos)) {
//                     StartCoroutine(Move(targetPos));
//                 }
//             }
//         }

//         animator.SetBool("isMoving", isMoving);
        
//     }

//     IEnumerator Move(Vector3 targetPos) {
//         isMoving = true;
//         while ((targetPos - transform.position).sqrMagnitude > float.Epsilon)
//         {
//             transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
//             yield return null;
//         }
//         transform.position = targetPos;
//         isMoving = false;
//     }

//     [ServerRpc]
//     void MoveServerRpc(Vector2 input)
//     {
//         var targetPos = transform.position;
//         targetPos.x += input.x;
//         targetPos.y += input.y;

//         if (IsWalkable(targetPos))
//         {
//             StartCoroutine(Move(targetPos));
//         }
//     }

//     private bool IsWalkable(Vector3 targetPos) {
        
//         if (Physics2D.OverlapCircle(targetPos, 0.2f, solidObjectsLayer) != null) {
//             return false;
//         } 
//         return true;
//     } 
// }


