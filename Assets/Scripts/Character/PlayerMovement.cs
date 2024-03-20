using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    [SerializeField] private Transform _leftTransform;
    [SerializeField] private Transform _midTransform;
    [SerializeField] private Transform _rightTransform;

    private Transform _currentTransform;
    private Vector3 _targetPosition;
    private bool _isJumping = false;

    private void Awake()
    {
        gameObject.transform.position = _midTransform.position;
    }

    private void Start()
    {
        _currentTransform = _midTransform;
        _targetPosition = _midTransform.position;
    }

    private void Update()
    {
        Debug.Log(IsGrounded());
        Move();
        if (!_isJumping)
        {
            transform.position = Vector3.Lerp(transform.position, _targetPosition, Time.deltaTime * _speed);
        }
        if (Input.GetKeyDown(KeyCode.Space)&&IsGrounded())
        {
            Jump();
        }
    }

    
    private void Move()
    {
        if (!_isJumping && (Input.GetKeyDown(KeyCode.A)))
        {
            if (_currentTransform == _rightTransform)
            {
                _currentTransform = _midTransform;
                _targetPosition = _midTransform.position;
            }
            else if (_currentTransform == _midTransform)
            {
                _currentTransform = _leftTransform;
                _targetPosition = _leftTransform.position;
            }
        }
        else if (!_isJumping && (Input.GetKeyDown(KeyCode.D)))
        {
            if (_currentTransform == _leftTransform)
            {
                _currentTransform = _midTransform;
                _targetPosition = _midTransform.position;
            }
            else if (_currentTransform == _midTransform)
            {
                _currentTransform = _rightTransform;
                _targetPosition = _rightTransform.position;
            }
        }
    }

    private void Jump()
    {
        _isJumping = true;
        _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        Invoke("ResetJump", 1.0f); 
    }

    
    private void ResetJump()
    {
        _isJumping = false;
    }
    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 0.1f, _groundLayer);
    }
}
