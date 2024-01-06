using UnityEngine;

public class PlayerAnimations : Animations
{    
    private readonly int Speed = Animator.StringToHash("Speed");

    public void PlayMove(float speed)
    {
        Animator.SetFloat(Speed, speed);
    }    
}
