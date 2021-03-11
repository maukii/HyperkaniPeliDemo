using UnityEngine;

public class EffectManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem onBallHitParticle;

    private Ball ball;
    private Flicker flicker;
    

    private void Awake()
    {
        flicker = FindObjectOfType<Flicker>();
        ball = FindObjectOfType<Ball>();
    }

    private void OnEnable()
    {
        ball.OnPlayerDeathEvent += PlayerDeath;
        flicker.BallHitEvent += BallHit;
    }

    private void BallHit(Vector3 point)
    {
        Instantiate(onBallHitParticle, point, Quaternion.identity);
    }

    private void PlayerDeath()
    {
        // TODO:: Some death particles
    }

    private void OnDisable()
    {
        ball.OnPlayerDeathEvent -= PlayerDeath;
        flicker.BallHitEvent -= BallHit;
    }
}
