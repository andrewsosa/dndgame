using UnityEngine;
using UnityEngine.Events;

public class MovementControllerIso : MonoBehaviour
{
    [Range(0, 1000f)] [SerializeField] private float m_MoveSpeed = 10f * 40f;
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;  // How much to smooth out the movement

    private Rigidbody2D m_Rigidbody2D;
    private bool m_FacingRight = true;  // For determining which way the player is currently facing.
    private Vector3 m_Velocity = Vector3.zero;


    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {

    }


    public void Move(float movementHorizontal, float movementVertical)
    {

        // Move the character by finding the target velocity
        Vector3 targetVelocity = new Vector2(
            movementHorizontal * m_MoveSpeed,
            movementVertical * m_MoveSpeed
        );

        // And then smoothing it out and applying it to the character
        m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

        // If the input is moving the player right and the player is facing left...
        if (movementHorizontal > 0 && !m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (movementHorizontal < 0 && m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }


    }


    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
