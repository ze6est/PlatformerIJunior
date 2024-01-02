using Nomnom.RaycastVisualization;
using UnityEngine;
using UnityEngine.UIElements;




[RequireComponent(typeof(CapsuleCollider2D))]
public class JumpChecker : MonoBehaviour
{
    [SerializeField] private CapsuleCollider2D _collider;
    [SerializeField] private LayerMask _collisions;
    [SerializeField] private float _hightCast = 0.1f;
    [SerializeField] private float _distanse = 0.1f;
    [SerializeField] private float _sizeOffsetX = 0.2f; 
    
    private Vector2 _size;
    RaycastHit2D[] _results = new RaycastHit2D[1];
    private bool _isJump = false;

    public bool IsJump => _isJump;

    private void Awake()
    {        
        _size = new Vector2(_collider.size.x - _sizeOffsetX, _hightCast);        
    }

    private void Update()
    {
        Vector2 castPosition = new Vector2(transform.position.x, transform.position.y - _collider.size.y/2);
        int isJump = VisualPhysics2D.BoxCastNonAlloc(castPosition, _size, 0, Vector3.down, _results, _distanse, _collisions);
        
        if (isJump >= 1)
            _isJump = true;
        else
            _isJump = false;
    }    
}