using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    private static readonly int HorizontalHash = Animator.StringToHash("horizontal");
    private static readonly int VerticalHash = Animator.StringToHash("vertical");
    private static readonly int GetUpHash = Animator.StringToHash("getUp");
    private static readonly int SpeedHash = Animator.StringToHash("speed");
    [SerializeField] private float defaultSpeed = 5f;
    [SerializeField] private float speedMultiplier = 1.4f;
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private WeaponController activeWeapon;
    [SerializeField] private Health health;
    [SerializeField] private float damage;
    private bool _isCanMove = false;
    private Vector2 _lastDirection;
    private Vector2 _movement;
    private float _speed;

    public float Damage => damage;
    public Vector2 LastDirection => _lastDirection;
    public Health PlayerHealth => health;
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
        animator.SetFloat(HorizontalHash, _lastDirection.x);
        animator.SetFloat(VerticalHash, _lastDirection.y);
        rb.linearVelocity = _movement.normalized * _speed;
        if ((_movement.sqrMagnitude >= 0.01f) && (_speed <= defaultSpeed))
            animator.SetFloat(SpeedHash, 1);
        else if ((_movement.sqrMagnitude >= 0.01f) && (_speed > defaultSpeed))
            animator.SetFloat(SpeedHash, 2);
        else
            animator.SetFloat(SpeedHash, 0);
    }

    private IEnumerator CoroutineGetUpAnimation()
    {
        animator.SetTrigger(GetUpHash);
        yield return new WaitForSeconds(1.5f);
        _isCanMove = true;
    }
}
