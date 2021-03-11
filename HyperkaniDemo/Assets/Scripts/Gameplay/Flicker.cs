using UnityEngine;

public class Flicker : MonoBehaviour
{
    [SerializeField] private float force = 10f;
    [SerializeField] private float torque = 90f;
    [SerializeField] private float verticalHelp = 1f;

    private Camera cam;

    public delegate void HitBall(Vector3 point);
    public event HitBall BallHitEvent;


    private void Awake()
    {
        // Save reference
        cam = Camera.main;
    }

    private void Update()
    {
        // Works with mobile as well
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(cam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                Ball ball = hit.collider.GetComponent<Ball>();
                if (ball)
                {
                    // Get direction from hit point to ball
                    Vector2 direction = ((Vector2)ball.transform.position - hit.point).normalized;                    

                    ball.AddForce(direction * force, ForceMode2D.Impulse);
                    ball.AddTorque(Random.Range(-torque, torque));

                    BallHitEvent?.Invoke(hit.point);
                }
            }
        }
    }
}
