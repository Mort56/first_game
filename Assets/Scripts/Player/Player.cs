using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static readonly int Horizontal = Animator.StringToHash("horizontal");
    private static readonly int Vertical = Animator.StringToHash("vertical");
    private static readonly int GetUp = Animator.StringToHash("getUp");
    private static readonly int Speed = Animator.StringToHash("speed");
    [SerializeField] private float defaultSpeed = 5f;
    [SerializeField] private float speedMultiplier = 1.4f;
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private WeaponController activeWeapon;
    private bool _isCanMove = false;
    private Vector2 _lastDirection;
    private Vector2 _movement;
    private float _speed;
    public Vector2 LastDirection => _lastDirection;
    public static Player Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        _speed = defaultSpeed;
        if (_isCanMove)
        {
            _movement.x = Input.GetAxisRaw("Horizontal");
            _movement.y = Input.GetAxisRaw("Vertical");
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            _speed *= speedMultiplier;
        }

        if (_movement.sqrMagnitude > 0f)
        {
            _lastDirection = _movement.normalized;
            activeWeapon.ChangeTransform(_lastDirection);
        }

        if (Input.anyKeyDown && !_isCanMove)
            StartCoroutine(CoroutineGetUpAnimation());
    }

    private void FixedUpdate()
    {
        animator.SetFloat(Horizontal, _lastDirection.x);
        animator.SetFloat(Vertical, _lastDirection.y);
        rb.linearVelocity = _movement.normalized * _speed;
        if ((_movement.sqrMagnitude >= 0.01f) && (_speed <= defaultSpeed))
            animator.SetFloat(Speed, 1);
        else if ((_movement.sqrMagnitude >= 0.01f) && (_speed > defaultSpeed))
            animator.SetFloat(Speed, 2);
        else
            animator.SetFloat(Speed, 0);
    }

    private IEnumerator CoroutineGetUpAnimation()
    {
        animator.SetTrigger(GetUp);
        yield return new WaitForSeconds(2);
        _isCanMove = true;
    }
}
