using UnityEngine;

public class EnemiesAnimations : Animations
{
    private readonly int Run = Animator.StringToHash("Run");
    private readonly int Attack = Animator.StringToHash("Attack");

    public void PlayMove(bool isMove)
    {
        Animator.SetBool(Run, isMove);
    }

    public void PlayAttack()
    {
        Animator.SetTrigger(Attack);
    }    
}