using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _exitButton;

    private void OnEnable()
    {
        _playButton.onClick.AddListener(NextScene);
        _exitButton.onClick.AddListener(Exit);
    }

    private void OnDisable() 
    {
        _playButton.onClick.RemoveListener(NextScene);
        _exitButton.onClick.RemoveListener(Exit);
    }

    private void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void Exit()
    {
        Application.Quit();
    }
}
