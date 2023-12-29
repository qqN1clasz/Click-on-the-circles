using UnityEngine;

public class Circle : MonoBehaviour, IClickable
{
    [SerializeField] private int _killValue;
    [SerializeField] private Animator _animator;

    public void Initialize(int killValue)
    {
        _killValue = killValue;
    }
    
    public int GivePoints()
    {
        DisableObject();
        PlayDeathAnimation();
        return _killValue;
    }

    private void DisableObject()
    {
        gameObject.SetActive(false);
    }

    private void PlayDeathAnimation()
    {
        _animator.SetTrigger("Died");
    }
}