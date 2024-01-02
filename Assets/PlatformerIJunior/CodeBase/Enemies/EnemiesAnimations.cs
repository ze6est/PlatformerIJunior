using UnityEngine;

public class EnemiesAnimations : MonoBehaviour
{
    private readonly int Run = Animator.StringToHash("Run");
    private readonly int Attack = Animator.StringToHash("Attack");

    [SerializeField] private Animator _animator;    

    public void PlayMove(bool isMove)
    {
        _animator.SetBool(Run, isMove);
    }

    public void PlayAttack()
    {
        _animator.SetTrigger(Attack);
    }
}