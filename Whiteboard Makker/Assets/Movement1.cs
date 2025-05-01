using UnityEngine;
using UnityEngine.EventSystems;

public class Movement1 : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private Rigidbody2D rb;

    private bool moveLeft;
    private bool moveRight;
    private bool jump;

    public Animator animator;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Keyboard movement
        moveLeft = Input.GetKey(KeyCode.A) || moveLeft;
        moveRight = Input.GetKey(KeyCode.D) || moveRight;

        if (Input.GetKeyDown(KeyCode.Space))
            jump = true;

    }

    void FixedUpdate()
    {
        float moveDirection = 0f;
        if (moveLeft)
            moveDirection -= 1f;

        if (moveRight)
            moveDirection += 1f;

        animator.SetBool("isWalking", moveDirection != 0);
        rb.linearVelocity = new Vector2(moveDirection * moveSpeed, rb.linearVelocity.y);


        if (jump && IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            animator.SetBool("isJumping", true);

        }
        else
        {
            animator.SetBool("isJumping", false);
        }

        jump = false; // Reset jump after applying it

    }

    bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    // UI Button methods
    public void OnMoveLeftDown() => moveLeft = true;
    public void OnMoveLeftUp() => moveLeft = false;

    public void OnMoveRightDown() => moveRight = true;
    public void OnMoveRightUp() => moveRight = false;

    public void OnJumpButton() => jump = true;
    public void OnJumpButtonUp() => jump = false;
}
