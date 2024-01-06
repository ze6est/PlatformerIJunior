using UnityEngine;

public abstract class HealthHUD : MonoBehaviour
{
    [SerializeField] private Health _health;

    protected int MaxHealth;

    private void Awake() => 
        MaxHealth = _health.Max;

    private void OnEnable() => 
        _health.HealthChanged += OnHealthChanged;

    private void OnDisable() => 
        _health.HealthChanged -= OnHealthChanged;

    protected abstract void OnHealthChanged(int health);
}