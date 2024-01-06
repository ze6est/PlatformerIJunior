using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SmoothBarHUD : HealthHUD
{
    [SerializeField] Slider _slider;
    [SerializeField] float _step;

    private Coroutine _currentCoroutine;

    private void Start()
    {
        _slider.maxValue = MaxHealth;
        _slider.value = MaxHealth;        
    }

    protected override void OnHealthChanged(int health)
    {
        if (_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);

        _currentCoroutine = StartCoroutine(ChangeHealth(health));
    }

    private IEnumerator ChangeHealth(int health)
    {
        while (_slider.value != health)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, health, _step * Time.deltaTime);
            yield return null;
        }
    }
}