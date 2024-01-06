using UnityEngine;
using UnityEngine.Events;

public abstract class Health : MonoBehaviour
{
    [SerializeField] private Animations _animations;
    [SerializeField] private int _max = 5;

    protected int Current;

    public int Max => _max;

    public event UnityAction<int> HealthChanged;

    private void Start()
    {
        Current = _max;

        HealthChanged?.Invoke(Current);
    }

    public void Heal(int health)
    {
        if (Current > _max)
        {
            Current = _max;
            HealthChanged?.Invoke(Current);
            return;
        }

        if (Current == _max && health > 0)
            return;

        ChangeHealth(health);
    }

    public virtual void TakeDamage(int health)
    {
        _animations.PlayHit();
        ChangeHealth(-health);
    }

    private void ChangeHealth(int health)
    {
        if (Current <= 0)
        {
            Current = 0;
            HealthChanged?.Invoke(Current);            
            return;
        }

        Current += health;

        HealthChanged?.Invoke(Current);        
    }
}