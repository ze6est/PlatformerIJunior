using System;
using UnityEngine;

public class AttackRangeChecker : MonoBehaviour
{
    [SerializeField] private Attack _attack;
    [SerializeField] private TriggerObserver _triggerObserver;

    private void OnEnable()
    {
        _triggerObserver.TriggerEntered += OnTriggerEntered;
        _triggerObserver.TriggerExited += OnTriggerExited;

        _attack.Disable();
    }

    private void OnDisable()
    {
        _triggerObserver.TriggerEntered -= OnTriggerEntered;
        _triggerObserver.TriggerExited -= OnTriggerExited;
    }

    private void OnTriggerEntered(Collider2D arg0)
    {
        _attack.Enable();
    }

    private void OnTriggerExited(Collider2D arg0)
    {
        _attack.Disable();
    }
}