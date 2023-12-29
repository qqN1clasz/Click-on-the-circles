using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private GameTimer _gameTimer;
    [SerializeField] private Animator _animator;

    private void OnEnable()
    {
        _gameTimer.End += OnTimeEnded;
    }

    private void OnDisable()
    {
        _gameTimer.End -= OnTimeEnded;
    }

    public void UpdateUI(int score)
    {
        ScoreChangedAnimation();
        _scoreText.text = "Score: " + score;       
    }

    private void OnTimeEnded()
    {
        _canvasGroup.alpha = 0;
    }

    private void ScoreChangedAnimation()
    {
        _animator.Play("ScoreChanged");
    }
}