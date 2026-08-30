using UnityEngine;

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
    [SerializeField] private float luck;
    private bool _ñanMove = false;
    private Vector2 _lastDirection;
    private Vector2 _movement;
    private float _speed;

    public float Damage => damage;
    public float Luck => luck;
    public Health PlayerHealth => health;
    public static Player Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        _speed = defaultSpeed;
        if (_ñanMove)
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

        if (Input.anyKeyDown && !_ñanMove)
            animator.SetTrigger(GetUpHash);
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

    public void EnableMovement()
    {
        _ñanMove = true;
    }
}
