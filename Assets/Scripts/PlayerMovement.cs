using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    public bool isJumping;
    public bool isGrounded;
    private bool isRightJumping;
    public bool isRightWalled;
    private bool isLeftJumping;
    public bool isLeftWalled;
    private bool AuthorizedRightJW;
    private bool AuthorizedLeftJW;

    public Transform GroundCheckLeft;
    public Transform GroundCheckRight;
    public Transform WallJumpRight1;
    public Transform WallJumpRight2;
    public Transform WallJumpLeft1;
    public Transform WallJumpLeft2;

    public Animator animator;
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;

    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }

        if (Input.GetButtonDown("Jump") && isRightWalled && AuthorizedRightJW && !isGrounded)
        {
            isRightJumping = true;
        }

        if (Input.GetButtonDown("Jump") && isLeftWalled && AuthorizedLeftJW && !isGrounded)
        {
            isLeftJumping = true;
        }

        if (isGrounded)//quand player est au sol il peut ensuite wall jump à gauche ou à droite;
        {
            AuthorizedLeftJW = true;
            AuthorizedRightJW = true;
        }

        Flip(rb.velocity.x);
        float characterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed", characterVelocity);
        animator.SetFloat("Yforce", rb.velocity.y);
        animator.SetBool("isGrounded", isGrounded);
    }


    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapArea(GroundCheckLeft.position, GroundCheckRight.position);
        isRightWalled = Physics2D.OverlapArea(WallJumpRight1.position, WallJumpRight2.position);
        isLeftWalled = Physics2D.OverlapArea(WallJumpLeft1.position, WallJumpLeft2.position);

        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        MovePlayer(horizontalMovement);
                              
    }

    void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, 0.05f);

        if (isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
            isGrounded = false;
        }
        if (isRightJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            rb.AddForce(new Vector2(-300f, 0f));
            AuthorizedRightJW = false;
            AuthorizedLeftJW = true;
            isRightJumping = false;
            }
        if (isLeftJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            rb.AddForce(new Vector2(300f, 0f));
            AuthorizedLeftJW = false;
            AuthorizedRightJW = true;
            isLeftJumping = false;
        }

    }

    void Flip(float _speed)
    {
        if (_speed > 0.1f)
        {
            spriteRenderer.flipX = false;
        } else if (_speed < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }

 

}
