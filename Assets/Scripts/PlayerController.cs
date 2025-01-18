using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;

    private bool isMoving;

    private Vector2 input;

    private Animator animator;

    private LayerMask solidObjectsLayer;

    private void Awake() {
        animator = GetComponent<Animator>();
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(solidObjectsLayer);
        if (!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");
            // Debug.Log("Input x: " + input.x);
            // Debug.Log("Input y: " + input.y);



            if (input != Vector2.zero)
            {
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);

                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                if (IsWalkable(targetPos)) {
                    StartCoroutine(Move(targetPos));
                }
            }
        }

        animator.SetBool("isMoving", isMoving);
        
    }

    IEnumerator Move(Vector3 targetPos) {
        isMoving = true;
        while ((targetPos - transform.position).sqrMagnitude > float.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;
        isMoving = false;
    }

    private bool IsWalkable(Vector3 targetPos) {
        
        if (Physics2D.OverlapCircle(targetPos, 0.2f, solidObjectsLayer) != null) {
            Debug.Log("Unable to walk!");
            return false;
        } 
        return true;
    } 
}


