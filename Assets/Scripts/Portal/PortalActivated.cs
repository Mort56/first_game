using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(IInteractable))]
public class PortalActivated : MonoBehaviour, IInteractable
{
    private static readonly int StartGameHash = Animator.StringToHash("StartGame"); 
    [SerializeField] private Animator portalAnimator;
    private string _gameScene = "Game";
    private float _animationTime = 3.7f;
    
    public void Interact()
    {
        portalAnimator.SetTrigger(StartGameHash);
        StartCoroutine(StartGameCoroutine());
    }

    private IEnumerator StartGameCoroutine()
    {
        yield return new WaitForSeconds(_animationTime);
        SceneManager.LoadScene(_gameScene);
    }
}
