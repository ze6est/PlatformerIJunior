using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{    
    private readonly int Speed = Animator.StringToHash("Speed");
    private readonly int Hit = Animator.StringToHash("Hit");

    [SerializeField] private Animator _animator;

    public void PlayMove(float speed)
    {
        _animator.SetFloat(Speed, speed);
    }

    public void PlayHit()
    {
        _animator.SetTrigger(Hit);
    }
}
