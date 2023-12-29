using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class EndPanel : MonoBehaviour
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _mainMenuButton;
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private GameTimer _gameTimer;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private Player _player;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;
    
    private void OnEnable()
    {
        _restartButton.onClick.AddListener(RestartGame);
        _mainMenuButton.onClick.AddListener(ToMainMenu);
        _gameTimer.End += OnTimeEnded;
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(RestartGame);
        _mainMenuButton.onClick.RemoveListener(ToMainMenu);     
    }

    private void OnTimeEnded()
    {
        _canvasGroup.alpha = 1;
        _canvasGroup.interactable = true;
        PlayEndedSound();
        ShowPlayerText();
        _gameTimer.End -= OnTimeEnded;
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void ToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    private void ShowPlayerText()
    {
        _scoreText.text = "YOUR SCORE IS " + _player.Score;
    }

    private void PlayEndedSound()
    {
        if (!_audioSource.isPlaying)
            _audioSource.PlayOneShot(_audioClip);
    }
}
