using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private Camera _mainCam;
    private Rigidbody2D _rb;
    
    [SerializeField] private float maxSpeed = 250f;
    [SerializeField] private float acceleration = 100f;
    [SerializeField] private float deceleration = 100f;
    
    private float _currentSpeed;
    private Vector2 _moveDirection;
    private bool _isMouseDown;

    private void Start()
    {
        _mainCam = Camera.main;
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        GetInputs();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    /// <summary>
    /// Get the player inputs
    /// </summary>
    private void GetInputs()
    {
        // Check if the left mouse button is down or up
        if (Input.GetMouseButtonDown(0)) _isMouseDown = true;
        else if (Input.GetMouseButtonUp(0)) _isMouseDown = false;

        if (_isMouseDown)
        {
            // Get the move direction from player to cursor position
            var mousePos = (Vector2)_mainCam.ScreenToWorldPoint(Input.mousePosition);
            var playerPos = (Vector2)transform.position;
            _moveDirection = (mousePos - playerPos).normalized;
        }
    }

    /// <summary>
    /// Move the player
    /// </summary>
    private void MovePlayer()
    {
        // Don't move the player if he is too close to the cursor
        var mousePos = (Vector2)_mainCam.ScreenToWorldPoint(Input.mousePosition);
        var distToCursor = Vector2.Distance(transform.position, mousePos);
        if (distToCursor < 0.5f)
        {
            _currentSpeed -= deceleration * Time.deltaTime;
            _currentSpeed = Mathf.Clamp(_currentSpeed, 0f, maxSpeed);
            _rb.velocity = _moveDirection * (_currentSpeed * Time.deltaTime);
            return;
        }
        
        // Handle acceleration and deceleration
        if (_isMouseDown)
        {
            _currentSpeed += acceleration * Time.deltaTime;
        }
        else
        {
            _currentSpeed -= deceleration * Time.deltaTime;
        }
        _currentSpeed = Mathf.Clamp(_currentSpeed, 0f, maxSpeed);
        
        // Apply velocity to the player
        var movement = _moveDirection * (_currentSpeed * Time.deltaTime);
        _rb.velocity = movement;
    }
}
