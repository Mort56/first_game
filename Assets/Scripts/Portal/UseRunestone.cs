using System.Collections;
using UnityEngine;

public class UseRunestone : MonoBehaviour, IInteractable
{
    static readonly int IsActivatedHash = Animator.StringToHash("isActivated"); 
    [SerializeField] private Animator levelAnimator;
    private bool _isLevelActivated = false;
    private float _changeLevelAnimationTime = 0f;
    
    public void Interact()
    {
        _isLevelActivated = !_isLevelActivated;
        levelAnimator.SetBool(IsActivatedHash, _isLevelActivated);
        StartCoroutine(StartAnimationCoroutine());
    }

    private IEnumerator StartAnimationCoroutine()
    {
        levelAnimator.SetBool(IsActivatedHash, _isLevelActivated);
        while (_changeLevelAnimationTime > 0f)
        {
            _changeLevelAnimationTime -= Time.deltaTime;
            yield return null;
        }
        _changeLevelAnimationTime = 0f;
        yield return null;
    }
}