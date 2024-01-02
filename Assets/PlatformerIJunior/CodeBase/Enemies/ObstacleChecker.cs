using Nomnom.RaycastVisualization;
using UnityEngine;

public class ObstacleChecker : MonoBehaviour
{
    [SerializeField] private LayerMask _collisions;
    [SerializeField] private float _distance = 1f;

    private RaycastHit2D[] _hit = new RaycastHit2D[1];
    private bool _isNotObstacle = true;

    public bool IsNotObstacle => _isNotObstacle;

    private void Update()
    {
        Vector2 direction = new Vector2(-transform.localScale.x, 0);

        int hitCount = VisualPhysics2D.RaycastNonAlloc(transform.position, direction, _hit, _distance, _collisions);

        if (hitCount > 0)
            _isNotObstacle = false;
        else
            _isNotObstacle = true;
    }    
}