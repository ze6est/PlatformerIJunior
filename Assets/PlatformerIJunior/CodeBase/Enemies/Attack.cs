using System.Linq;
using Nomnom.RaycastVisualization;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private EnemiesAnimations _animator;
    [SerializeField] private AnimationsChecker _animationsChecker;
    [SerializeField] private LayerMask _collisions;
    [SerializeField] private int _damage = 1;
    [SerializeField] private float _attackCooldown = 2.5f;
    [SerializeField] private float _offsetX = 0.5f;
    [SerializeField] private float _offsetY = 0.2f;
    [SerializeField] private float _radius = 1f;

    private Collider2D[] _hits = new Collider2D[1];
    private float _currentAttackCooldown;
    private bool _isAttacking;
    private bool _attackIsActive;

    private void OnEnable()
    {
        _animationsChecker.Attacked += OnAttacked;
        _animationsChecker.AttackEnded += OnAttackEnded;
    }

    private void Start()
    {
        _currentAttackCooldown = _attackCooldown;
    }

    private void OnDisable()
    {
        _animationsChecker.Attacked -= OnAttacked;
        _animationsChecker.AttackEnded -= OnAttackEnded;
    }

    private void Update()
    {
        if(_currentAttackCooldown >= 0)
            _currentAttackCooldown -= Time.deltaTime;

        if(_attackIsActive && !_isAttacking && _currentAttackCooldown <= 0)
            StartAttack();        
    }

    private void OnAttacked()
    {
        if (Hit(out Collider2D hit))
        {
            hit.transform.GetComponent<PlayerHealth>().ChangeHealth(-_damage);
        }
    }

    private void OnAttackEnded()
    {
        _currentAttackCooldown = _attackCooldown;
        _isAttacking = false;
    }

    public void Enable()
    {
        _attackIsActive = true;
    }

    public void Disable()
    {
        _attackIsActive = false;
    }

    private void StartAttack()
    {
        _animator.PlayAttack();
        _isAttacking = true;
    }   

    private bool Hit(out Collider2D hit)
    {        
        float positionX = transform.position.x + _offsetX * -transform.localScale.x;
        float positionY = transform.position.y + _offsetY;
        Vector2 hitPoint = new Vector2(positionX, positionY);

        int hitsCount = VisualPhysics2D.OverlapCircleNonAlloc(hitPoint, _radius, _hits, _collisions);
        hit = _hits.FirstOrDefault();

        return hitsCount > 0;
    }
}