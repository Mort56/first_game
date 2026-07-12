using System.Collections;
using UnityEngine;

public class StartLevel : MonoBehaviour, IInteractable
{
    static readonly int IsActivatedHash = Animator.StringToHash("isActivated"); 
    [SerializeField] private Animator levelAnimator;
    private bool _isLevelActivated = false;
    private float _changeLevelAnimationTime = 0f;
    
    public void Interact()
    {
        _isLevelActivated = !_isLevelActivated;
        levelAnimator.SetBool(IsActivatedHash, _isLevelActivated);
        StartCoroutine(CoroutineAnimationStart());
    }

    private IEnumerator CoroutineAnimationStart()
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