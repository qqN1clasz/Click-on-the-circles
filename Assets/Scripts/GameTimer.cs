using System;
using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    [SerializeField] private float _maxTime;
    [SerializeField] private TMP_Text _timerText;
    [SerializeField] private CanvasGroup _canvasGroup;

    private float _currentTime;
    private bool _ended;

    public event Action End;
    public bool Ended => _ended;

    private void Start()
    {
        _currentTime = _maxTime;
        UpdateTimerText(_currentTime);
    }

    private void Update()
    {
        if(_currentTime > 0)
        {
            _currentTime -= Time.deltaTime;
            UpdateTimerText(_currentTime);
        }
        else
        {
            _ended = true;
            End?.Invoke();
            DisableGroup();
        }
    }

    private void UpdateTimerText(float currentTime)
    {
        _timerText.text = "Time: " + Mathf.Round(currentTime);
    }

    private void DisableGroup()
    {
        _canvasGroup.alpha = 0f;
    }
}
