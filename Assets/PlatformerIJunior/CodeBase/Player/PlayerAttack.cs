using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private int _damage;    

    private bool _damageIsDone = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out EnemieHealth health) && !_damageIsDone)
        {            
            _damageIsDone = true;
            health.TakeDamage(_damage);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out EnemieHealth health) && !_damageIsDone)
        {
            _damageIsDone = false;
        }
    }
}