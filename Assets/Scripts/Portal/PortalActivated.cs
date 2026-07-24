using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(IInteractable))]
public class PortalActivated : MonoBehaviour, IInteractable
{
    private static readonly int StartGameHash = Animator.StringToHash("StartGame"); 
    [SerializeField] private Animator portalAnimator;
    private string _gameScene = "Game";
    
    public void Interact()
    {
        portalAnimator.SetTrigger(StartGameHash);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(_gameScene);
    }
}
