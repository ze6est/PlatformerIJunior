using TMPro;
using UnityEngine;

public class TextHUD : HealthHUD
{
    [SerializeField] private TextMeshProUGUI _currentHealth;
    [SerializeField] private TextMeshProUGUI _maxHealth;

    private void Start()
    {
        _maxHealth.text = MaxHealth.ToString();        
    }

    protected override void OnHealthChanged(int health) => 
        _currentHealth.text = health.ToString();
}