using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public int Score => score;
    private int score;

    private Flicker flicker;

    public delegate void OnScoreChanged(int score);
    public event OnScoreChanged OnScoreChangedEvent;


    private void Awake()
    {
        flicker = FindObjectOfType<Flicker>();
    }

    private void OnEnable()
    {
        flicker.BallHitEvent += AddScore;
    }

    private void AddScore(Vector3 point)
    {
        score++;
        OnScoreChangedEvent?.Invoke(score);
    }

    public void ResetScore() => score = 0;

    private void OnDisable()
    {
        flicker.BallHitEvent -= AddScore;
    }
}
