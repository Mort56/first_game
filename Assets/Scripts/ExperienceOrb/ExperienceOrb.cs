using System;
using System.Collections;
using UnityEngine;

public class ExperienceOrb : AbstractProjectileMovement
{
    [SerializeField] private float timeBetweenChaseChecks = 0.5f;
    [SerializeField] private float orbSpawnTime = 2f;
    [SerializeField] private float maxChaseDistance = 5f;
    [SerializeField] private float durationToSpeedPickUp = 2f;

    public static event EventHandler onTakeOrb;

    private WaitForSeconds _waitTimeBetweenChaseChecks;
    private WaitForSeconds _waitOrbSpawnTime;

    private Coroutine _changeInSpeedCoroutine;
    private float _defaultSpeed;

    private enum OrbState 
    { 
        Spawning, 
        Idle, 
        Chasing 
    }

    private OrbState _state;

    private void Awake()
    {
        _waitTimeBetweenChaseChecks = new WaitForSeconds(timeBetweenChaseChecks);
        _waitOrbSpawnTime = new WaitForSeconds(orbSpawnTime);
        _defaultSpeed = speed;
    }

    public void StartSpawnAnimation()
    {
        _state = OrbState.Spawning;
        _direction = GetRandomDir();
        StartCoroutine(OrbSpawnCoroutine());
    }

    private Vector2 GetRandomDir()
    {
        return new Vector2(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)).normalized;
    }

    private IEnumerator OrbSpawnCoroutine()
    {
        RestartSpeedChange(true);
        yield return _waitOrbSpawnTime;
    }

    public void ChasingPlayer()
    {
        if (_state != OrbState.Idle)
            return;

        _state = OrbState.Chasing;
        RestartSpeedChange(false);
        StartCoroutine(SmoothChaseCoroutine());
    }

    private IEnumerator SmoothChaseCoroutine()
    {
        while (_state == OrbState.Chasing)
        {
            GetTargetVector(Player.Instance.transform.position, 0);
            yield return _waitTimeBetweenChaseChecks;

            float distance = ((Vector2)Player.Instance.transform.position - (Vector2)transform.position).magnitude;
            if (distance > maxChaseDistance)
            {
                _state = OrbState.Idle;
                RestartSpeedChange(true);
            }
        }
    }

    private void RestartSpeedChange(bool slowdown=true)
    {
        if (_changeInSpeedCoroutine != null)
            StopCoroutine(_changeInSpeedCoroutine);
        _changeInSpeedCoroutine = StartCoroutine(ChangeInSpeedCoroutine(slowdown));
    }

    private IEnumerator ChangeInSpeedCoroutine(bool slowdown=true)
    {
        var elapsed = 0f;
        while (elapsed < durationToSpeedPickUp)
        {
            elapsed += Time.deltaTime;
            var progress = Mathf.Clamp01(elapsed / durationToSpeedPickUp);
            speed = slowdown ? Mathf.Lerp(_defaultSpeed, 0f, progress) : Mathf.Lerp(speed, _defaultSpeed, progress);
            yield return null;
        }

        if (slowdown)
        {
            _direction = Vector2.zero;
            _state = OrbState.Idle;
        }

        _changeInSpeedCoroutine = null;
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _direction = Vector2.zero;
            _isNeedDestroy = true;
        }
        else
            _isNeedDestroy = false;

        if (_isNeedDestroy)
        {
            ExperienceOrbSpawner.Instance.ReturnItem(this);
            onTakeOrb?.Invoke(this, EventArgs.Empty);
        }
    }
}