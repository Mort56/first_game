using System.Collections;
using UnityEngine;

public class Blink : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Material blinkMaterial;
    [SerializeField] private Health health;
    private Material _defaultMaterial;
    private float blinkTime = 0.15f;

    private void Awake()
    {
        _defaultMaterial = spriteRenderer.material;
    }

    private void OnEnable()
    {
        health.onTakeHit += Health_onTakeHit;
    }

    private void OnDisable()
    {
        health.onTakeHit -= Health_onTakeHit;
    }

    private void Health_onTakeHit(object sender, System.EventArgs e)
    {
        StartCoroutine(ObjectBlinkAnimationCoroutine());
    }

    private IEnumerator ObjectBlinkAnimationCoroutine()
    {
        spriteRenderer.material = blinkMaterial;
        yield return new WaitForSeconds(blinkTime);
        spriteRenderer.material = _defaultMaterial;
    }
}
