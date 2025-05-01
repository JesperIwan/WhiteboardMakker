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

    //pressure
    float touchPressure;


    public float minJumpForce = 2f;
    public float maxJumpForce = 5f;
    public float maxPressure = 1.0f; // Adjust if your device supports higher

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

        //Debug.Log("Max possible pressure: " + Input.GetTouch(0).maximumPossiblePressure);
        //Debug.Log("Current pressure: " + Input.GetTouch(0).pressure);
        // Debug.Log(Input.touchPressureSupported);
        if (Input.touchCount > 0)
        {
            touchPressure = Input.GetTouch(0).pressure;
            Debug.Log("tryk pres  "+touchPressure);
        }

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
    /*float GetCurrentTouchPressure()
    {
       /* if (Input.touchCount > 0)
        {
            foreach (Touch t in Input.touches)
            {
                if (t.phase == TouchPhase.Began || t.phase == TouchPhase.Stationary || t.phase == TouchPhase.Moved)
                {
                    Debug.Log(t.pressure);
                    return t.pressure;
                }
            }
        }

        return 1.0f; // fallback if pressure data is unavailable
    }*/
    bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    // UI Button methods
    public void OnMoveLeftDown() => moveLeft = true;
    public void OnMoveLeftUp() => moveLeft = false;

    public void OnMoveRightDown() => moveRight = true;
    public void OnMoveRightUp() => moveRight = false;

    public void OnJumpButton()
    {
        if (IsGrounded())
        {
            //float pressure = GetCurrentTouchPressure();
            float pressure = touchPressure;
            Debug.Log("tryk ved knap:  " +  pressure);
            // Clamp and normalize pressure
            float normalizedPressure = Mathf.Clamp01(pressure / maxPressure);
            Debug.Log("tryk ved knap:  " + normalizedPressure);
            jumpForce = Mathf.Lerp(minJumpForce, maxJumpForce, normalizedPressure);

            jump = true;
        }
    }
    public void OnJumpButtonUp() => jump = false;
}
