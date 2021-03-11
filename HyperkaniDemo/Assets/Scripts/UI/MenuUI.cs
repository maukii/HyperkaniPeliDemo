using UnityEngine;
using TMPro;
using DG.Tweening;
using System;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private GameObject UI;
    [SerializeField] private GameObject startScreen;
    [SerializeField] private TMP_Text headerText;
    [SerializeField] private GameObject loseScreen;
    [SerializeField] private TMP_Text scoreText;

    private Ball ball;
    private ScoreCounter counter;


    private void Awake()
    {
        ball = FindObjectOfType<Ball>();
        counter = FindObjectOfType<ScoreCounter>();
    }

    private void OnEnable()
    {
        ball.OnPlayerDeathEvent += Lose;
    }

    private void Start()
    {
        UI.SetActive(true);
        startScreen.SetActive(true);
        loseScreen.SetActive(false);

        AnimateHeaderText();
    }

    private void AnimateHeaderText()
    {
        headerText.transform.DOLocalRotate(headerText.transform.forward * 16f, 1.0f).SetEase(Ease.InOutQuad).SetLoops(-1, LoopType.Yoyo);
        headerText.transform.DOScale(1.2f, 0.4f).SetEase(Ease.InOutQuad).SetLoops(-1, LoopType.Yoyo);
    }

    public void Lose()
    {
        UI.SetActive(true);
        startScreen.SetActive(false);
        loseScreen.SetActive(true);

        scoreText.SetText(counter.Score.ToString());
    }

    public void Play()
    {
        UI.SetActive(false);
        startScreen.SetActive(false);
        loseScreen.SetActive(false);
    }

    public void PlayAgain()
    {
        UI.SetActive(false);
        startScreen.SetActive(false);
        loseScreen.SetActive(false);

        counter.ResetScore();
        ball.ResetBall();
    }

    private void OnDisable()
    {
        ball.OnPlayerDeathEvent -= Lose;
    }
}
