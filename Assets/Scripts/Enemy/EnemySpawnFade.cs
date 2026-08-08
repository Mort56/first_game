using System.Collections;
using UnityEngine;

public class EnemySpawnFade : MonoBehaviour
{
    [SerializeField] protected SpriteRenderer spriteRenderer;
    private float _fadeDuration = 1f;
    private bool _isSpawned = false;
    public bool IsSpawned => _isSpawned;

    private void OnEnable()
    {
        StartCoroutine(EnemySpawnAnimationCoroutine());
    }

    private IEnumerator EnemySpawnAnimationCoroutine()
    {
        _isSpawned = false;
        float elapsed = 0f;
        Color color = new Color(1f, 1f, 1f, 0f);
        spriteRenderer.color = color;

        while (_fadeDuration > elapsed)
        {
            elapsed += Time.deltaTime;
            color.a = Mathf.Clamp01(elapsed / _fadeDuration);
            spriteRenderer.color = color;
            yield return null;
        }
        _isSpawned = true;
    }

    private void OnDisable()
    {
        _isSpawned = false;
    }
}
