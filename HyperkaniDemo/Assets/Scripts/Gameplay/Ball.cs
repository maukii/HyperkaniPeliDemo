using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 startPosition;

    public delegate void OnPlayerDeath();
    public event OnPlayerDeath OnPlayerDeathEvent;

    public delegate void OnWallHit(Vector3 point);
    public event OnWallHit OnWallHitEvent;


    private void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    public void AddForce(Vector2 force, ForceMode2D mode)
    {
        rb.velocity = Vector3.zero;
        rb.AddForce(force, mode);
    }

    public void AddTorque(float torque)
    {
        rb.AddTorque(torque);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Wall"))
        {
            OnWallHitEvent?.Invoke(collision.contacts[0].point);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Kill"))
        {
            OnPlayerDeathEvent?.Invoke();
        }
    }

    public void ResetBall()
    {
        transform.position = startPosition;
        rb.angularVelocity = 0f;
        rb.velocity = Vector3.zero;
    }
}
