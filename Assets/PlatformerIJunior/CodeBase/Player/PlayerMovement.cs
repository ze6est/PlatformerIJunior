using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);    

    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private PlayerAnimations _animations;
    [SerializeField] private JumpChecker _jumpChecker;    

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;    

    private void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        float direction = Input.GetAxis(Horizontal);        

        if (direction == 0)
            return;
        else if (direction < 0)
            _spriteRenderer.flipX = true;
        else
            _spriteRenderer.flipX = false;

        float distance = direction * _moveSpeed * Time.deltaTime;
        transform.Translate(distance * Vector3.right);

        _animations.PlayMove(Mathf.Abs(direction));
    }

    private void Jump()
    {
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) && _jumpChecker.IsJump)        
            _rigidbody2D.AddForce(Vector3.up * _jumpForce);
    }
}