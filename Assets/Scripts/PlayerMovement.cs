using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10F;
    public bool isGrounded;

    public Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;
    private Vector2 movement;

    void Update()
    {
        if (Pause.paused)
        {
            return;
        }
        Flip(rb.velocity.x);
    }

    void FixedUpdate()
    {
        if (Pause.paused) 
        {
            return;
        }
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float verticalMovement = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        MovePlayer(horizontalMovement, verticalMovement);
    }

    void MovePlayer(float _horizontalMovement, float _verticalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, _verticalMovement);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .01f);

        // movement.x = Input.GetAxisRaw("Horizontal");
        // movement.y = Input.GetAxisRaw("Vertical");
    }

    void Flip(float _speed)
    {
        if (_speed > 0.1f)
        {
            // spriteRenderer.flipX = false;
        } else if (_speed < -0.1f)
        {
            // spriteRenderer.flipX = true;
        }
    }
}
