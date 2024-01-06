using UnityEngine;

public class EnemieHealth : Health
{
    public override void TakeDamage(int health)
    {
        base.TakeDamage(health);

        if (Current <= 0)
            Destroy(gameObject.transform.parent.parent.gameObject);
    }
}
