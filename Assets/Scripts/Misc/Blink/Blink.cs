using System.Collections;
using UnityEngine;

public class Blink : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float blinkDuration = 0.15f;
    [SerializeField] private Material blinkMaterial;
    [SerializeField] private Health health;
    private Material _defaultMaterial;
    private WaitForSeconds _waitBlinkDuration;

    private void Awake()
    {
        _waitBlinkDuration = new WaitForSeconds(blinkDuration);
        _defaultMaterial = spriteRenderer.material;
    }

    private void OnEnable()
    {
        health.onHealthDown += Health_onTakeHit;
    }

    private void OnDisable()
    {
        health.onHealthDown -= Health_onTakeHit;
    }

    private void Health_onTakeHit(object sender, System.EventArgs e)
    {
        StartCoroutine(ObjectBlinkAnimationCoroutine());
    }

    private IEnumerator ObjectBlinkAnimationCoroutine()
    {
        spriteRenderer.material = blinkMaterial;
        yield return _waitBlinkDuration;
        spriteRenderer.material = _defaultMaterial;
    }
}
