using UnityEngine;

public abstract class Animations : MonoBehaviour
{
    protected readonly int Hit = Animator.StringToHash("Hit");

    [SerializeField] protected Animator Animator;

    public void PlayHit()
    {
        Animator.SetTrigger(Hit);
    }
}