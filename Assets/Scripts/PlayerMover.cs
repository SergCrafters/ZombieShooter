using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class PlayerMover : MonoBehaviour
{
    private const float Gravity = 19.6f;


    [SerializeField] private InputReader _inputReader;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private LayerMask _groundLayer;

    private CharacterController _controller;
    private Vector3 _velocity;
    private bool _isJumping = false;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        _inputReader.Moved += Move;
        _inputReader.Jumped += Jump;
    }

    private void Update()
    {

        if (CheckGround())
        {
            if(_isJumping == false && _velocity.y < 0)
            {
            _velocity.y = -1;
            }
        }
        else
        {
            _velocity.y -= Gravity * Time.deltaTime;
        }
        _controller.Move(_velocity * Time.deltaTime);
    }

    private void OnDisable()
    {
        _inputReader.Moved -= Move;
        _inputReader.Jumped -= Jump;
    }

    private void Move(float horizontal, float vertical)
    {
        Vector3 direction = transform.forward * vertical + transform.right * horizontal;
        direction.Normalize();
        _controller.Move(direction * _speed * Time.deltaTime);
    }

    private bool CheckGround()
    {
        if (Physics.CheckSphere(transform.position, _controller.radius, _groundLayer))
        {
            _isJumping = false;
            return true;
        }

        return false;
    }

    private void Jump()
    {
        _velocity.y = _jumpForce;
        _isJumping = true;  
    }
}
