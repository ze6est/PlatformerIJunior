using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private PlayerAnimations _animations;
    [SerializeField] private int _max = 5;

    [SerializeField] private int _current;

    private void Start()
    {
        _current = _max;
    }

    public void ChangeHealth(int health)
    {
        if (_current <= 0)
            return;

        _current += health;
        _animations.PlayHit();
    }
}