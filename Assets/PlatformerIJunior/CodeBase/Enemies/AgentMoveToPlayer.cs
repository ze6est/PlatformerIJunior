using UnityEngine;

public class AgentMoveToPlayer : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private ObstacleChecker _obstacleChecker;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _minimalDistance = 0.5f;

    private void Update()
    {
        if(PlayerNotReached())
        {
            SetDirectionMovement();

            if (_obstacleChecker.IsNotObstacle)
            {
                Vector2 playerPosition = new Vector2(_playerTransform.position.x, transform.position.y);
                transform.position = Vector2.MoveTowards(transform.position, playerPosition, _speed * Time.deltaTime);
            }            
        }
    }

    private bool PlayerNotReached() =>
        Vector2.Distance(transform.position, _playerTransform.position) >= _minimalDistance;

    private void SetDirectionMovement()
    {
        float direction = transform.position.x - _playerTransform.position.x;

        if (direction > 0)
            transform.localScale = Vector3.one;
        else
            transform.localScale = new Vector3(-1, 1, 1);
    }
}