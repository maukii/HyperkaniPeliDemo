using UnityEngine;
using TMPro;
using DG.Tweening;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private float rotationAngle = 15f;

    private ScoreCounter scoreCounter;
    private bool left = false;


    private void Awake()
    {
        scoreCounter = FindObjectOfType<ScoreCounter>();
        InvokeRepeating(nameof(RotateScoreUI), 0.0f, 1.0f);
    }

    private void OnEnable()
    {
        scoreCounter.OnScoreChangedEvent += UpdateScoreUI;
    }

    private void RotateScoreUI()
    {
        scoreText.transform.DORotateQuaternion(Quaternion.Euler(Vector3.forward * rotationAngle * (left ? 1 : -1)), 1.0f);
        left = !left;
    }

    public void UpdateScoreUI(int score)
    {
        scoreText.SetText($"Score: {scoreCounter.Score}");
        if (score == 0) return;

        if (score % 5 == 0)
        {
            // Position change
            scoreText.transform.DOShakePosition(1.5f);

            // Scale change
            scoreText.transform.DOShakeScale(1.5f);
        }
    }

    private void OnDisable()
    {
        scoreCounter.OnScoreChangedEvent -= UpdateScoreUI;
    }
}
