using UnityEngine;
using UnityEngine.UI;

public class BarHUD : HealthHUD
{
    [SerializeField] private Slider _slider;

    private void Start() => 
        _slider.maxValue = MaxHealth;

    protected override void OnHealthChanged(int health) => 
        _slider.value = health;
}