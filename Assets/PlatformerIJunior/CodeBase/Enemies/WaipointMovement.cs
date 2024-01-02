using UnityEngine;

public class WaipointMovement : MonoBehaviour
{
    [SerializeField] private Transform _pathContainer;
    [SerializeField] private EnemiesAnimations _animations;
    [SerializeField] private float _speed;

    private Vector3[] _points;
    private int _currentPoint = 0;
    private Vector3 _target;

    private void Awake()
    {
        _pathContainer.parent = null;

        int pointsCount = _pathContainer.childCount;

        _points = new Vector3[pointsCount];

        for (int i = 0; i < pointsCount; i++)
            _points[i] = _pathContainer.GetChild(i).position;
    }

    private void OnEnable()
    {
        SetDirectionMovement();
    }

    private void Start()
    {
        SetTarget();
        SetDirectionMovement();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 targetPositionX = new Vector3(_target.x, transform.position.y);

        Vector3 direction = Vector3.MoveTowards(transform.position, targetPositionX, _speed * Time.deltaTime);

        transform.position = new Vector3(direction.x, transform.position.y);        

        if (transform.position.x == _target.x)
            MoveToNextTarget();

        _animations.PlayMove(true);
    }

    private void MoveToNextTarget()
    {
        _currentPoint++;

        if (_currentPoint == _points.Length)
            _currentPoint = 0;

        SetTarget();
        SetDirectionMovement();
    }

    private void SetDirectionMovement()
    {
        float direction = transform.position.x - _target.x;

        if (direction > 0)
            transform.localScale = Vector3.one;
        else
            transform.localScale = new Vector3(-1, 1, 1);
    }

    private void SetTarget() =>
        _target = _points[_currentPoint];
}