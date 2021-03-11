using UnityEngine;
using DG.Tweening;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private float duration = 0.2f;
    [SerializeField] private float strength = 1f;
    [SerializeField] private int vibrato = 10;
    [SerializeField] private float randomness = 90.0f;

    private Camera cam;
    private Ball ball;
    private Flicker flicker;



    private void Awake()
    {
        cam = Camera.main;
        ball = FindObjectOfType<Ball>();
        flicker = FindObjectOfType<Flicker>();
    }

    private void OnEnable()
    {
        ball.OnWallHitEvent += Shake;
        flicker.BallHitEvent += Shake;
    }

    private void Shake(Vector3 point)
    {
        cam.DOShakePosition(duration, strength, vibrato, randomness);
    }

    private void OnDisable()
    {
        ball.OnWallHitEvent -= Shake;
        flicker.BallHitEvent -= Shake;
    }
}
