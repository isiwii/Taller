using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovemet : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;
    Vector2 movementInput;
    Rigidbody2D rb;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    Animator animator; // Reference to the Animator component

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); // Get the Animator component
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (movementInput != Vector2.zero)
        {
            int count = rb.Cast(
                movementInput,
                movementFilter,
                castCollisions,
                moveSpeed * Time.fixedDeltaTime + collisionOffset);

            if (count == 0)
            {
                rb.MovePosition(rb.position + movementInput * moveSpeed * Time.fixedDeltaTime);
            }

            // Determine the direction of movement and set appropriate trigger
            if (movementInput.x < 0)
            {
                animator.SetTrigger("walkLeft");
            }
            else if (movementInput.x > 0)
            {
                animator.SetTrigger("walkRight");
            }
            
        }
        else
        {
            // Set the stop trigger when there is no movement input
            animator.SetTrigger("idle");
        }
    }

    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }
}