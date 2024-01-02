using UnityEngine;
using UnityEngine.Events;

public class AnimationsChecker : MonoBehaviour
{
    public event UnityAction Attacked;
    public event UnityAction AttackEnded;

    private void OnAttack()
    {
        Attacked?.Invoke();
    }

    private void OnAttackEnded()
    {
        AttackEnded?.Invoke();
    }
}