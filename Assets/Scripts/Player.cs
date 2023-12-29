using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerUI _playerUI;
    [SerializeField] private Camera _camera;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;
    private int _score = 0;
    public int Score => _score;

    private void Update()
    {
        ClickOnCircle();
    }

    private void ClickOnCircle()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Vector2 touchPosition = _camera.ScreenToWorldPoint(Input.GetTouch(0).position);
            RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector2.zero);
            if(hit.collider != null)
            {
                if(hit.collider.TryGetComponent(out IClickable clickable))
                {
                    PlayClickClip();
                    _score += clickable.GivePoints();
                    _playerUI.UpdateUI(_score);
                }
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.collider.TryGetComponent(out IClickable clickable))
                {
                    PlayClickClip();
                    _score += clickable.GivePoints();
                    _playerUI.UpdateUI(_score);
                }
            }
        }
    }

    private void PlayClickClip()
    {
        _audioSource.PlayOneShot(_audioClip);
    }
}